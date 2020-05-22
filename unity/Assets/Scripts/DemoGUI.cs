using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DemoGUI : MonoBehaviour
{
    private const string NotCallableForObjectiveC= "The function is not callable for IOS platform. Check IOS-SDK doc. Since Unity creates Objective-C, It is not callable.";
    private const string NullText = "null";

    GameObject labelResult;
    bool isDidomiInitialized = false;
    int group = 0;
    int x;
    int y;
    int buttonWidth = 300;
    int buttonHeight = 150;
    int yStep = 180;
    string message = "Message Pane";

    Rect GetMiddleRect1() { return new Rect(x - buttonWidth * 0.5f, 1 * yStep, buttonWidth, buttonHeight); }
    Rect GetMiddleRect2() { return new Rect(x - buttonWidth * 0.5f, 2 * yStep, buttonWidth, buttonHeight); }
    Rect GetMiddleRect3() { return new Rect(x - buttonWidth * 0.5f, 3 * yStep, buttonWidth, buttonHeight); }
    Rect GetMiddleRect4() { return new Rect(x - buttonWidth * 0.5f, 4 * yStep, buttonWidth, buttonHeight); }
    Rect GetMiddleRect5() { return new Rect(x - buttonWidth * 0.5f, 5 * yStep, buttonWidth, buttonHeight); }
    Rect GetMiddleRect6() { return new Rect(x - buttonWidth * 0.5f, 6 * yStep, buttonWidth, buttonHeight); }

    Rect GetRightRect1() { return new Rect(x + buttonWidth * 0.5f, 1 * yStep, buttonWidth, buttonHeight); }
    Rect GetRightRect2() { return new Rect(x + buttonWidth * 0.5f, 2 * yStep, buttonWidth, buttonHeight); }
    Rect GetRightRect3() { return new Rect(x + buttonWidth * 0.5f, 3 * yStep, buttonWidth, buttonHeight); }
    Rect GetRightRect4() { return new Rect(x + buttonWidth * 0.5f, 4 * yStep, buttonWidth, buttonHeight); }
    Rect GetRightRect5() { return new Rect(x + buttonWidth * 0.5f, 5 * yStep, buttonWidth, buttonHeight); }
    Rect GetRightRect6() { return new Rect(x + buttonWidth * 0.5f, 6 * yStep, buttonWidth, buttonHeight); }

    int leftX = 300;
    Rect GetLeftRect1() { return new Rect(x - buttonWidth * 1.5f, 1 * yStep, buttonWidth, buttonHeight); }
    Rect GetLeftRect2() { return new Rect(x - buttonWidth * 1.5f, 2 * yStep, buttonWidth, buttonHeight); }
    Rect GetLeftRect3() { return new Rect(x - buttonWidth * 1.5f, 3 * yStep, buttonWidth, buttonHeight); }
    Rect GetLeftRect4() { return new Rect(x - buttonWidth * 1.5f, 4 * yStep, buttonWidth, buttonHeight); }
    Rect GetLeftRect5() { return new Rect(x - buttonWidth * 1.5f, 5 * yStep, buttonWidth, buttonHeight); }
    Rect GetLeftRect6() { return new Rect(x - buttonWidth * 1.5f, 6 * yStep, buttonWidth, buttonHeight); }

    int xStep = 10;
    Rect GetFuncRect1() { return new Rect(x - leftX - xStep, 5 * yStep, buttonWidth, buttonHeight); }
    Rect GetFuncRect2() { return new Rect(x - leftX - xStep, 6 * yStep, buttonWidth, buttonHeight); }
    Rect GetFuncRect3() { return new Rect(x + xStep, 5 * yStep, buttonWidth, buttonHeight); }
    Rect GetFuncRect4() { return new Rect(x + xStep, 6 * yStep, buttonWidth, buttonHeight); }

    Rect GetFuncRectCenter() { return new Rect(x - buttonWidth * 0.5f, 5.5f * yStep, buttonWidth, buttonHeight); }

    void Start()
    {
        x = Screen.width / 2;
        y = Screen.height / 2;

        labelResult = GameObject.Find("Result");
        if (Application.platform == RuntimePlatform.Android)
        {
            buttonWidth = 300;
            buttonHeight = 150;
            yStep = 180;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            buttonWidth = 250;
            buttonHeight = 75;
            yStep = 90;
        }

        var array=JsonConvert.DeserializeObject<string[]>("[\n  \"analytics\",\n  \"content_personalization\",\n  \"cookies\",\n  \"geo_ads\",\n  \"geo_marketing_studies\",\n  \"ad_delivery\",\n  \"advertising_personalization\"\n]");
        Debug.Log("aaa aa " + array.Length);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        DisplayGroupButtons();

        if (group == 1)
        {
            Group1();
        }
        else if (group == 2)
        {
            Group2();
        }
        else if (group == 3)
        {
            Group3();
        }
        else if (group == 4)
        {
            Group4();
        }
        else if (group == 5)
        {
            Group5();
        }
        else if (group == 6)
        {
            Group6();
        }
        else if (group == 7)
        {
            Group7();
        }
        else if (group == 8)
        {
            Group8();
        }
        else if (group == 9)
        {
            Group9();
        }
        else if (group == 10)
        {
            Group10();
        }
        else if (group == 11)
        {
            Group11();
        }
        else if (group == 12)
        {
            Group12();
        }

        var style = new GUIStyle { font = GUI.skin.font, fontSize = 80 };
        style.normal.textColor = Color.white;

        var text = labelResult.GetComponent<Text>();
        text.text = message;

        //GUI.Label(new Rect(x, 7 * yStep, buttonWidth * 2, buttonHeight * 2), message, style);
    }

    void DisplayGroupButtons()
    {
        //if (!isDidomiInitialized)
        //{
        //    if (GUI.Button(GetFuncRectCenter(), "Initialize"))
        //    {
        //        Didomi.GetInstance().Initialize("c3cd5b46-bf36-4700-bbdc-4ee9176045aa",
        //             null,
        //             null,
        //             null,
        //             true,
        //             null);

        //        var didomiCallable = new DidomiCallable();
        //        didomiCallable.OnReady += DidomiCallable_OnReady;
        //        Didomi.GetInstance().OnReady(didomiCallable);
        //    }
        //}

        //GUI.enabled = isDidomiInitialized;
        RenderGroupButtons();
        GUI.enabled = true;
    }

    void RenderGroupButtons()
    {
        if (GUI.Button(GetLeftRect1(), "Group 1"))
        {
            group = 1;
        }

        if (GUI.Button(GetMiddleRect1(), "Group 2"))
        {
            group=2;
        }

        if (GUI.Button(GetRightRect1(), "Group 3"))
        {
            group = 3;
        }

        if (GUI.Button(GetLeftRect2(), "Group 4"))
        {
            group = 4;
        }

        if (GUI.Button(GetMiddleRect2(), "Group 5"))
        {
            group = 5;
        }

        if (GUI.Button(GetRightRect2(), "Group 6"))
        {
            group = 6;
        }

        if (GUI.Button(GetLeftRect3(), "Group 7"))
        {
            group = 7;
        }
        if (GUI.Button(GetMiddleRect3(), "Group 8"))
        {
            group = 8;
        }

        if (GUI.Button(GetRightRect3(), "Group 9"))
        {
            group = 9;
        }

        if (GUI.Button(GetLeftRect4(), "Group 10"))
        {
            group = 10;
        }

        if (GUI.Button(GetMiddleRect4(), "Group 11"))
        {
            group = 11;
        }
        if (GUI.Button(GetRightRect4(), "Group 12"))
        {
            group = 12;
        }
    }

    private void DidomiCallable_OnReady(object sender, EventArgs e)
    {
        isDidomiInitialized = true;
        message = "Ready";
    }

    string TextForISet<T>(ISet<T> set)
    {
        if (set == null)
        {
            return "Null Returned";
        }
        else
        {
            return  $"set returned with {set.Count}";
        }
    }

    string ToMessage(IList<string> list)
    {
        var messageBuilder = new StringBuilder();
        var seperator = ", ";

        foreach (var item in list)
        {
            messageBuilder.Append(item);
            messageBuilder.Append(seperator);
        }

        var message = messageBuilder.ToString();

        if (list.Count > 0)
        {
            message = message.Substring(0, message.Length - 2);
        }

        return message;
    }

    string ToMessage(Purpose purpose)
    {
        var id = purpose.GetId() ?? string.Empty;
        var iabId = purpose.GetIabId() ?? string.Empty;
        var name = purpose.GetName() ?? string.Empty;
        var description = purpose.GetDescription() ?? string.Empty;
        var isCustom = purpose.IsCustom();

        var nl = Environment.NewLine;

        return $"Purpose {nl} id: {id + nl} iabId: {iabId + nl} name: {name + nl} description: {description + nl} isCustom: {isCustom + nl}";
    }

    string ToMessage(Vendor vendor)
    {
        
        var id = vendor.GetId() ?? NullText;
        var name = vendor.GetName() ?? NullText;
        var privacyPolicyUrl = vendor.GetPrivacyPolicyUrl() ?? NullText;
        var @namespace = vendor.GetNamespace() ?? NullText;

        var purposeIds = NullText;
        var purposeIdList = vendor.GetPurposeIds();
        if (purposeIdList != null)
        {
            purposeIds = ToMessage(purposeIdList);
        }

        var legIntPurposeIds = NullText;
        var legIntPurposeIdList = vendor.GetLegIntPurposeIds();
        if (legIntPurposeIdList != null)
        {
            legIntPurposeIds = ToMessage(legIntPurposeIdList);
        }

        
        var iabId = vendor.GetIabId() ?? NullText;

        var nl = Environment.NewLine;

        return $"Purpose {nl} id: {id + nl} name: {name + nl} privacyPolicyUrl: {privacyPolicyUrl + nl} @namespace: {@namespace + nl} purposeIds: {purposeIds + nl} legIntPurposeIds: {legIntPurposeIds + nl} iabId: {iabId + nl}";
    }

    string ToMessage(IDictionary<string, string> dict)
    {
        var dictContent = new StringBuilder();

        foreach (var key in dict.Keys)
        {
            dictContent.AppendLine($"key {key} value {dict[key]}");
        }

        return $"Dictionary {Environment.NewLine} {dictContent.ToString()}";
    }

    string TextForObject(object obj)
    {

        if (obj == null)
        {
            return NullText;
        }
        else
        {
            var purposeSet = obj as ISet<Purpose>;

            if (purposeSet!=null)
            {
                return TextForISet(purposeSet);
            }

            var vendorSet = obj as ISet<Vendor>;

            if (vendorSet != null)
            {
                return TextForISet(vendorSet);
            }

            var stringSet = obj as ISet<string>;

            if (stringSet != null)
            {
                return TextForISet(stringSet);
            }

            var purpose = obj as Purpose;

            if (purpose != null)
            {
                return ToMessage(purpose);
            }

            var vendor = obj as Vendor;

            if (vendor != null)
            {
                return ToMessage(vendor);
            }

            return $"Value {obj} returned";
        }
    }

    string MessageForObject(object obj)
    {
        return $"{Environment.NewLine} {TextForObject(obj)}";
    }

    void Group1()
    {
        if (GUI.Button(GetFuncRect1(), "GetDisabledPurposes"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var retval = Didomi.GetInstance().GetDisabledPurposes();
                message += "GetDisabledPurposes" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect2(), "GetDisabledPurposeIds"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetDisabledPurposeIds();
            message += "GetDisabledPurposeIds" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect3(), "GetDisabledVendors"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var retval = Didomi.GetInstance().GetDisabledVendors();
                message += "GetDisabledVendors" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect4(), "GetDisabledVendorIds"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetDisabledVendorIds();
            message += "GetDisabledVendorIds" + MessageForObject(retval);
        }
    }

    void Group2()
    { 
        if (GUI.Button(GetFuncRect1(), "GetEnabledPurposes"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var retval = Didomi.GetInstance().GetEnabledPurposes();
                message += "GetEnabledPurposes" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect2(), "GetEnabledPurposeIds"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetEnabledPurposeIds();
            message += "GetEnabledPurposeIds" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect3(), "GetEnabledVendors"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var retval = Didomi.GetInstance().GetEnabledVendors();
                message += "GetEnabledVendors" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect4(), "GetEnabledVendorIds"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetEnabledVendorIds();
            message += "GetEnabledVendorIds" + MessageForObject(retval);
        }
    }

    void Group3()
    {
        if (GUI.Button(GetFuncRect1(), "GetRequiredPurposes"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var retval = Didomi.GetInstance().GetRequiredPurposes();
                message = "GetRequiredPurposes" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect2(), "GetRequiredPurposeIds"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetRequiredPurposeIds();
            message += "GetRequiredPurposeIds" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect3(), "GetRequiredVendors"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var retval = Didomi.GetInstance().GetRequiredVendors();
                message = "GetRequiredVendors" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect4(), "GetRequiredVendorIds"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetRequiredVendorIds();
            message += "GetRequiredVendorIds" + MessageForObject(retval);
        }
    }

    void Group4()
    { 
        if (GUI.Button(GetFuncRect1(), "GetJavaScriptForWebView"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().GetJavaScriptForWebView();
            message += "GetJavaScriptForWebView" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect2(), "GetPurpose"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var purposeId = GetFirstRequiredPurposeId();
                var retval = Didomi.GetInstance().GetPurpose(purposeId);
                message += "GetPurpose" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect3(), "GetUserConsentStatusForPurpose"))
        {
            message = string.Empty;
            var purposeId = GetFirstRequiredPurposeId();
            var retval = Didomi.GetInstance().GetUserConsentStatusForPurpose(purposeId);
            message += "GetUserConsentStatusForPurpose" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect4(), "GetUserConsentStatusForVendor"))
        {
            message = string.Empty;
            var vendorId = GetFirstRequiredVendorId();
            var retval = Didomi.GetInstance().GetUserConsentStatusForVendor(vendorId);
            message += "GetUserConsentStatusForVendor" + MessageForObject(retval);
        }
    }

    void Group5()
    {
        if (GUI.Button(GetFuncRect1(), "GetUserConsentStatusForVendorAndRequiredPurposes"))
        {
            message = string.Empty;
            var vendorId = GetFirstRequiredVendorId();
            var retval = Didomi.GetInstance().GetUserConsentStatusForVendorAndRequiredPurposes(vendorId);
            message += "GetUserConsentStatusForVendorAndRequiredPurposes" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect2(), "GetVendor"))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                message = string.Empty;
                var vendorId = GetFirstRequiredVendorId();
                var retval = Didomi.GetInstance().GetVendor(vendorId);
                message += "GetVendor" + MessageForObject(retval);
            }
            else
            {
                message = NotCallableForObjectiveC;
            }
        }

        if (GUI.Button(GetFuncRect3(), "IsConsentRequired"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().IsConsentRequired();
            message += "IsConsentRequired" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect4(), "IsUserConsentStatusPartial"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().IsUserConsentStatusPartial();
            message += "IsUserConsentStatusPartial" + MessageForObject(retval);
        }
    }

    void Group6()
    { 
        if (GUI.Button(GetFuncRect1(), "IsNoticeVisible"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().IsNoticeVisible();
            message += "IsNoticeVisible" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect2(), "IsPreferencesVisible"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().IsPreferencesVisible();
            message += "IsPreferencesVisible" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect3(), "IsReady"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().IsReady();
            message += "IsReady" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect4(), "Reset"))
        {
            message = string.Empty;
            Didomi.GetInstance().Reset();
            message += "Reset called";
        }
    }

    void Group7()
    { 
        if (GUI.Button(GetFuncRect1(), "SetUserAgreeToAll"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().SetUserAgreeToAll();
            message += "SetUserAgreeToAll" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect2(), "SetUserDisagreeToAll"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().SetUserDisagreeToAll();
            message += "SetUserDisagreeToAll" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect3(), "SetUserConsentStatus"))
        {
            message = string.Empty;
            var enabledPurposeIds = new string[] { "", "" };

            ISet<string> enabledPurposeIds = Didomi.GetInstance().GetRequiredPurposeIds();
            ISet<string> disabledPurposeIds = new HashSet<string>();
            ISet<string> enabledVendorIds = Didomi.GetInstance().GetRequiredVendorIds();
            ISet<string> disabledVendorIds = new HashSet<string>();

            var retval = Didomi.GetInstance().SetUserConsentStatus(
                enabledPurposeIds,
                disabledPurposeIds,
                enabledVendorIds,
                disabledVendorIds);

            Didomi.GetInstance().SetUserConsentStatus(
                enabledPurposeIds,
                disabledPurposeIds,
                enabledVendorIds,
                disabledVendorIds);

            message += "SetUserConsentStatus" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect4(), "ShouldConsentBeCollected"))
        {
            message = string.Empty;
            var retval = Didomi.GetInstance().ShouldConsentBeCollected();
            message += "ShouldConsentBeCollected" + MessageForObject(retval);
        }
    }

    void Group8()
    {
        if (GUI.Button(GetFuncRect1(), "AddEventListener"))
        {
            message = string.Empty;
            RegisterEventHandlers();
            message += "AddEventListener";
        }

        if (GUI.Button(GetFuncRect2(), "GetText"))
        {
            message = string.Empty;
            var key = "name";
            var dict = Didomi.GetInstance().GetText(key);
            message += "GetText" + MessageForObject(dict);
        }

        if (GUI.Button(GetFuncRect3(), "GetTranslatedText"))
        {
            message = string.Empty;

            var key = "name";
            var retval = Didomi.GetInstance().GetTranslatedText(key);

            message += "GetTranslatedText" + MessageForObject(retval);
        }

        if (GUI.Button(GetFuncRect4(), "UpdateSelectedLanguage"))
        {
            message = string.Empty;

            var languageCode = "fr";

            Didomi.GetInstance().UpdateSelectedLanguage(languageCode);

            message += "UpdateSelectedLanguage";
        }
    }

    void Group9()
    {
        if (GUI.Button(GetFuncRect1(), "HideNotice"))
        {
            message = string.Empty;
            Didomi.GetInstance().HideNotice();
            message += "HideNotice";
        }

        if (GUI.Button(GetFuncRect2(), "HidePreferences"))
        {
            message = string.Empty;
            Didomi.GetInstance().HidePreferences();
            message += "HidePreferences";
        }

        if (GUI.Button(GetFuncRect3(), "ShowNotice"))
        {
            message = string.Empty;
            Didomi.GetInstance().ShowNotice();
            message += "ShowNotice";
        }

        if (GUI.Button(GetFuncRect4(), "showPreferences"))
        {
            message = string.Empty;
            Didomi.GetInstance().ShowPreferences();
            message += "showPreferences";
        }
    }

    void Group10()
    {
        if (GUI.Button(GetFuncRect1(), "SetupUI"))
        {
            message = string.Empty;
            Didomi.GetInstance().SetupUI();
            message += "SetupUI";
        }

        if (GUI.Button(GetFuncRect2(), "OnReady"))
        {
            message = string.Empty;

            var didomiCallable = new DidomiCallable();
            didomiCallable.OnReady += DidomiCallable_OnReadyFired;
            Didomi.GetInstance().OnReady(didomiCallable);
        }

        if (GUI.Button(GetFuncRect3(), "Initialize"))
        {
            message = string.Empty;

            Didomi.GetInstance().Initialize(
                apiKey: "c3cd5b46-bf36-4700-bbdc-4ee9176045aa",
                localConfigurationPath: null,
                remoteConfigurationURL: null,
                providerId: null,
                disableDidomiRemoteConfig: true,
                languageCode: null);


            var didomiCallable = new DidomiCallable();
            didomiCallable.OnReady += DidomiCallable_OnReady;
            Didomi.GetInstance().OnReady(didomiCallable);
        }
    }

    private void DidomiCallable_OnReadyFired(object sender, EventArgs e)
    {
        message = "OnReady Event Fired.";
    }

    void Group11()
    {
        if (GUI.Button(GetFuncRectCenter(), "Automated Test"))
        {
            var didomiTests = new DidomiTests();
            message = didomiTests.RunAll();
        }
    }

    void Group12()
    {
    
    }

    private void RegisterEventHandlers()
    {
        EventListener eventListener = new EventListener();
        eventListener.ConsentChanged += EventListener_ConsentChanged;
        eventListener.HideNotice += EventListener_HideNotice;
        eventListener.Ready += EventListener_Ready;
        eventListener.NoticeClickAgree += EventListener_NoticeClickAgree;
        eventListener.NoticeClickMoreInfo += EventListener_NoticeClickMoreInfo;
        eventListener.PreferencesClickAgreeToAll += EventListener_PreferencesClickAgreeToAll;
        eventListener.PreferencesClickDisagreeToAll += EventListener_PreferencesClickDisagreeToAll;
        eventListener.PreferencesClickPurposeAgree += EventListener_PreferencesClickPurposeAgree;
        eventListener.PreferencesClickPurposeDisagree += EventListener_PreferencesClickPurposeDisagree;
        eventListener.PreferencesClickSaveChoices += EventListener_PreferencesClickSaveChoices;
        eventListener.PreferencesClickVendorAgree += EventListener_PreferencesClickVendorAgree;
        eventListener.PreferencesClickVendorDisagree += EventListener_PreferencesClickVendorDisagree;
        eventListener.PreferencesClickVendorSaveChoices += EventListener_PreferencesClickVendorSaveChoices;
        eventListener.PreferencesClickViewVendors += EventListener_PreferencesClickViewVendors;
        eventListener.ShowNotice += EventListener_ShowNotice;

        Didomi.GetInstance().AddEventListener(eventListener);
    }

    private void EventListener_Ready(object sender, Ready e)
    {
        message += "EventListener_ReadyEvent Fired.";
    }

    private void EventListener_ShowNotice(object sender, ShowNotice e)
    {
        message += "EventListener_ShowNoticeEvent Fired.";
    }

    private void EventListener_PreferencesClickViewVendors(object sender, PreferencesClickViewVendors e)
    {
        message += "EventListener_PreferencesClickViewVendorsEvent Fired.";
    }

    private void EventListener_PreferencesClickVendorSaveChoices(object sender, PreferencesClickVendorSaveChoices e)
    {
        message += "EventListener_PreferencesClickVendorSaveChoicesEvent Fired.";
    }

    private void EventListener_PreferencesClickVendorDisagree(object sender, PreferencesClickVendorDisagree e)
    {
        message += "EventListener_PreferencesClickVendorDisagreeEvent Fired.";
    }

    private void EventListener_PreferencesClickVendorAgree(object sender, PreferencesClickVendorAgree e)
    {
        message += "EventListener_PreferencesClickVendorAgreeEvent Fired.";
    }

    private void EventListener_PreferencesClickSaveChoices(object sender, PreferencesClickSaveChoices e)
    {
        message += "EventListener_PreferencesClickSaveChoicesEvent Fired.";
    }

    private void EventListener_PreferencesClickPurposeDisagree(object sender, PreferencesClickPurposeDisagree e)
    {
        message += "EventListener_PreferencesClickPurposeDisagreeEvent Fired.";
    }

    private void EventListener_PreferencesClickPurposeAgree(object sender, PreferencesClickPurposeAgree e)
    {
        message += "EventListener_PreferencesClickPurposeAgreeEvent Fired.";
    }

    private void EventListener_PreferencesClickDisagreeToAll(object sender, PreferencesClickDisagreeToAll e)
    {
        message += "EventListener_PreferencesClickDisagreeToAllEvent Fired.";
    }

    private void EventListener_PreferencesClickAgreeToAll(object sender, PreferencesClickAgreeToAll e)
    {
        message += "EventListener_PreferencesClickAgreeToAllEvent Fired.";
    }

    private void EventListener_NoticeClickMoreInfo(object sender, NoticeClickMoreInfo e)
    {
        message += "EventListener_NoticeClickMoreInfoEvent Fired.";
    }

    private void EventListener_NoticeClickAgree(object sender, NoticeClickAgree e)
    {
        message += "EventListener_NoticeClickAgreeEvent Fired.";
    }

    private void EventListener_HideNotice(object sender, HideNotice e)
    {
        message += "EventListener_HideNoticeEvent Fired.";
    }

    private void EventListener_ConsentChanged(object sender, ConsentChanged e)
    {
        message += "EventListener_ConsentChangedEvent Fired.";
    }

    private string GetFirstRequiredPurposeId()
    {
        var requiredPurposeIdSet = Didomi.GetInstance().GetRequiredPurposeIds();

        var purposeId = string.Empty;
        if (requiredPurposeIdSet.Count > 0)
        {
            purposeId = requiredPurposeIdSet.FirstOrDefault();
        }

        return purposeId;
    }

    private string GetFirstRequiredVendorId()
    {
        var requiredVendorIdSet = Didomi.GetInstance().GetRequiredVendorIds();

        var vendorId = string.Empty;
        if (requiredVendorIdSet.Count > 0)
        {
            vendorId = requiredVendorIdSet.FirstOrDefault();
        }

        return vendorId;
    }
}
