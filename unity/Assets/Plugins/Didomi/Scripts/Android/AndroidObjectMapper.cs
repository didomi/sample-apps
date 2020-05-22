﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IO.Didomi.SDK.Android
{
    class AndroidObjectMapper
    {
        public static bool ConvertToBoolean(AndroidJavaObject obj)
        {
            if (obj != null)
            {
                var retval = new HashSet<Purpose>();

                var boolString = obj.Call<string>("toString");

                return bool.Parse(boolString); 
            }
            else
            {
                return false;
            }
        }

        public static ISet<Purpose> ConvertToSetPurpose(AndroidJavaObject obj)
        {
            if (obj != null)
            {
                var retval = new HashSet<Purpose>();

                var iteratorJavaObject = obj.Call<AndroidJavaObject>("iterator");

                while (iteratorJavaObject.Call<bool>("hasNext"))
                {
                    var purposeJavaObject = iteratorJavaObject.Call<AndroidJavaObject>("next");

                    retval.Add(ConvertToPurpose(purposeJavaObject));
                }

                return retval;
            }

            return null;
        }

        public static Purpose ConvertToPurpose(AndroidJavaObject obj)
        {
            var purpose = new Purpose(
                GetMethodStringValue(obj, "getId"),
                GetMethodStringValue(obj, "getIabId"),
                GetMethodStringValue(obj, "getName"),
                GetMethodStringValue(obj, "getDescription"));

            return purpose;
        }

        public static ISet<Vendor> ConvertToSetVendor(AndroidJavaObject obj)
        {
            if (obj != null)
            {
                var retval = new HashSet<Vendor>();

                var iteratorJavaObject = obj.Call<AndroidJavaObject>("iterator");

                while (iteratorJavaObject.Call<bool>("hasNext"))
                {
                    var vendorJavaObject = iteratorJavaObject.Call<AndroidJavaObject>("next");

                    retval.Add(ConvertToVendor(vendorJavaObject));
                }

                return retval;
            }

            return null;
        }

        public static Vendor ConvertToVendor(AndroidJavaObject obj)
        {
            var vendor = new Vendor(
               GetMethodStringValue(obj, "getId"),
               GetMethodStringValue(obj, "getName"),
               GetMethodStringValue(obj, "getPrivacyPolicyUrl"),
               GetMethodStringValue(obj, "getNamespace"),
               GetMethodListString(obj, "getPurposeIds"),
               GetMethodListString(obj, "getLegIntPurposeIds"),
               GetMethodStringValue(obj, "getIabId"));

            return vendor;

        }

        public static ISet<string> ConvertToSetString(AndroidJavaObject obj)
        {
            if (obj != null)
            {
                var retval = new HashSet<string>();

                var iteratorJavaObject = obj.Call<AndroidJavaObject>("iterator");

                while (iteratorJavaObject.Call<bool>("hasNext"))
                {
                    retval.Add(iteratorJavaObject.Call<string>("next"));
                }

                return retval;
            }

            return null;
        }

        public static AndroidJavaObject ConvertFromHasSetStringToSetAndroidJavaObject(ISet<string> objSet)
        {
            if (objSet != null)
            {
                var hashSetJavaObject = new AndroidJavaObject("java.util.HashSet");

                //IntPtr methodPut = AndroidJNIHelper.GetMethodID(
                //    hashSetJavaObject.GetRawClass(),
                //    "add",
                //    "(Ljava/lang/String)Ljava/lang/Boolean;");

                IntPtr methodPut = AndroidJNIHelper.GetMethodID(
                   hashSetJavaObject.GetRawClass(),
                   "add",
                   "(Ljava/lang/String);");

                foreach (var item in objSet)
                {
                    
                    var itemJavaObject = new AndroidJavaObject("java.lang.String", item);

                    var args = new object[1];
                    args[0] = itemJavaObject;

                    AndroidJNI.CallBooleanMethod(hashSetJavaObject.GetRawObject(), methodPut, AndroidJNIHelper.CreateJNIArgArray(args));
                }


                return hashSetJavaObject;
            }

            return null;
        }

        public static IDictionary<string, string> ConvertToDictionary(AndroidJavaObject obj)
        {
            if (obj != null)
            {
                var retval = new Dictionary<string, string>();

                var setJavaObject = obj.Call<AndroidJavaObject>("keySet");

                var iteratorJavaObject = setJavaObject.Call<AndroidJavaObject>("iterator");

                while (iteratorJavaObject.Call<bool>("hasNext"))
                {
                    var key = iteratorJavaObject.Call<string>("next");
                    var val = obj.Call<string>("get");
                    retval.Add(key, val);
                }

                return retval;
            }

            return null;
        }

        public static string GetMethodStringValue(AndroidJavaObject obj, string methodName)
        {
            if (obj != null)
            {
                return obj.Call<string>(methodName);
            }

            return null;
        }

        public static IList<string> GetMethodListString(AndroidJavaObject obj, string methodName)
        {
            if (obj != null)
            {
                var androidJavaListObject = obj.Call<AndroidJavaObject>(methodName);
                if (androidJavaListObject != null)
                {
                    var retval = new List<string>();

                    var size=androidJavaListObject.Call<int>("size");

                    for (int i = 0; i < size; i++)
                    {
                        retval.Add(androidJavaListObject.Call<string>("get", i));
                    }

                    return retval;
                }
            }

            return null;
        }
    }
}
