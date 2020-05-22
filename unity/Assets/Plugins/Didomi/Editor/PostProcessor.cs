﻿using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public static class PostProcessor
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
    {
        Debug.Log("OnPostProcessBuild for " + buildTarget);
        if (buildTarget == BuildTarget.iOS)
        {
            // So PBXProject.GetPBXProjectPath returns wrong path, we need to construct path by ourselves instead
            // var projPath = PBXProject.GetPBXProjectPath(buildPath);
            var projPath = buildPath + "/Unity-iPhone.xcodeproj/project.pbxproj";
            var proj = new PBXProject();
            proj.ReadFromFile(projPath);

            var targetGuid = proj.GetUnityMainTargetGuid();

            //// Configure build settings
            proj.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");
            proj.SetBuildProperty(targetGuid, "SWIFT_OBJC_BRIDGING_HEADER", "Libraries/Plugins/IOS/UnitySwift-Bridging-Header.h");
            proj.SetBuildProperty(targetGuid, "SWIFT_OBJC_INTERFACE_HEADER_NAME", "Didomi-Swift.h");
            proj.SetBuildProperty(targetGuid, "SWIFT_VERSION", "4.2");

            proj.AddBuildProperty(targetGuid, "DEFINES_MODULE", "YES");
            proj.AddBuildProperty(targetGuid, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");

            proj.AddBuildProperty(targetGuid, "LD_RUNPATH_SEARCH_PATHS", "@executable_path/Frameworks");
            proj.AddBuildProperty(targetGuid, "FRAMERWORK_SEARCH_PATHS", "$(inherited) $(PROJECT_DIR) $(PROJECT_DIR)/Frameworks");
            proj.AddBuildProperty(targetGuid, "DYLIB_INSTALL_NAME_BASE", "@rpath");
            proj.AddBuildProperty(targetGuid, "LD_DYLIB_INSTALL_NAME", "@executable_path/../Frameworks/$(EXECUTABLE_PATH)");

            CopyDidomiConfigFileToIOSFolder(proj, targetGuid, buildPath);

            proj.WriteToFile(projPath);
        }
        else if (buildTarget == BuildTarget.Android)
        {
            AndroidPostProcess(buildPath);
        }
    }

    private static void CopyDidomiConfigFileToIOSFolder(PBXProject project, string targetGuid, string path)
    {
        var configFile = "didomi_config_ios.json";
        var configFileTarget = "didomi_config.json";

        var sourceFile = Application.dataPath + @"\Plugins\Editor\" + configFile;
        var newCopyFile = @"Data\Resources\" + configFileTarget;
        var newCopyFileAbsolutePath = Path.Combine(path, newCopyFile);

        File.Copy(sourceFile, newCopyFileAbsolutePath, true);
        var fileGuid = project.AddFile(newCopyFile, newCopyFile);
        project.AddFileToBuild(targetGuid, fileGuid);
    }

    private static void AndroidPostProcess(string path)
    {
        UpdateUnityPlayerActivity(path);
        UpdateUnityLibraryDependencies(path);
        CopyDidomiConfigFileToAssetFolder(path);
        UpdateStylesThemeToAppCompat(path);
        UpdateThemeAppCompatInAndroidManifestFile(path);
    }

    private static void UpdateThemeAppCompatInAndroidManifestFile(string path)
    {
        var unityAndroidmManifestFile = @"unityLibrary\src\main\AndroidManifest.xml";
        var unityAndroidmManifestFileAbsolutePath = Path.Combine(path, unityAndroidmManifestFile);

        var lines = File.ReadAllLines(unityAndroidmManifestFileAbsolutePath);
        var builder = new StringBuilder();

        var oldValue = @"android:theme=""@style/UnityThemeSelector""";
        var newValue = @"android:theme=""@style/DidomiTheme""";
        foreach (var line in lines)
        {
            if (line.Contains(oldValue))
            {
                builder.AppendLine(line.Replace(oldValue, newValue));
            }
            else
            {
                builder.AppendLine(line);
            }
        }

        File.WriteAllText(unityAndroidmManifestFileAbsolutePath, builder.ToString());
    }

    private static void UpdateStylesThemeToAppCompat(string path)
    {
        var unityPlayerFile = @"unityLibrary\src\main\res\values\styles.xml";
        var unityPlayerFileAbsolutePath = Path.Combine(path, unityPlayerFile);
        var oldValue = @"</resources>";
        var newValue = @"<style name=""DidomiTheme"" parent =""Theme.AppCompat.Light.DarkActionBar"" />

</resources>";

        ReplaceLineInFile(unityPlayerFileAbsolutePath, oldValue, newValue);
    }

    private static void CopyDidomiConfigFileToAssetFolder(string path)
    {
        var configFile = "didomi_config.json";

        var sourceFile = Application.dataPath + @"\Plugins\Editor\" + configFile;
        var newCopyFile = @"unityLibrary\src\main\assets\" + configFile;
        var newCopyFileAbsolutePath = Path.Combine(path, newCopyFile);

        File.Copy(sourceFile, newCopyFileAbsolutePath, true);
    }

    private static void UpdateUnityLibraryDependencies(string path)
    {
        var unityPlayerFile = @"unityLibrary\build.gradle";
        var unityPlayerFileAbsolutePath = Path.Combine(path, unityPlayerFile);
        var oldValue = "dependencies {";
        var newValue = @"dependencies {
    implementation 'com.android.support:appcompat-v7:27.1.1'
    implementation 'com.android.support:design:27.1.1'
    implementation 'com.google.android.gms:play-services-ads:15.0.1'
    implementation ""android.arch.lifecycle:extensions:1.1.0""
    implementation 'android.arch.lifecycle:viewmodel:1.1.0'
    // Force customtabs 27.1.1 as com.google.android.gms:play-services-ads:15.0.1 depends on 26.0.1 by default
    // See https://stackoverflow.com/questions/50009286/gradle-mixing-versions-27-1-1-and-26-1-0
    implementation 'com.android.support:customtabs:27.1.1'
    api 'com.iab.gdpr_android:gdpr_android:1.0.1'
    api 'com.google.code.gson:gson:2.8.5'
    api 'com.rm:rmswitch:1.2.2'";
        ReplaceLineInFile(unityPlayerFileAbsolutePath, oldValue, newValue);
    }

    private static void UpdateUnityPlayerActivity(string path)
    {
        var unityPlayerFile = @"unityLibrary\src\main\java\com\unity3d\player\UnityPlayerActivity.java";
        var unityPlayerFileAbsolutePath = Path.Combine(path, unityPlayerFile);
        var oldValue = "public class UnityPlayerActivity extends Activity implements IUnityPlayerLifecycleEvents";
        var newValue = $"import android.support.v7.app.AppCompatActivity;{System.Environment.NewLine}{System.Environment.NewLine}public class UnityPlayerActivity extends AppCompatActivity implements IUnityPlayerLifecycleEvents";
        ReplaceLineInFile(unityPlayerFileAbsolutePath, oldValue, newValue);
    }

    private static void ReplaceLineInFile(string path, string oldValue, string newValue)
    {
        string text = File.ReadAllText(path);
        text = text.Replace(oldValue, newValue);
        File.WriteAllText(path, text);
    }
}

