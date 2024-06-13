using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

// From https://stackoverflow.com/questions/54370336/from-unity-to-ios-how-to-perfectly-automate-frameworks-settings-and-plist/54370793#54370793
public class BuildPostProcessor
{
    [PostProcessBuild]
    public static void ChangeXcodePlist(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {

            string plistPath = path + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            PlistElementDict rootDict = plist.root;

            // example of changing a value:
            // rootDict.SetString("CFBundleVersion", "6.6.6");

            // example of adding a boolean key...
            // < key > ITSAppUsesNonExemptEncryption </ key > < false />
            rootDict.SetString("NSBluetoothAlwaysUsageDescription", "Required for AR");

            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}