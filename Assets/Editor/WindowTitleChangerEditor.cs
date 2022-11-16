using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCL.Assets.Editor
{
    [InitializeOnLoad]
    internal class WindowTitleChangerEditor : MonoBehaviour
    {
        static WindowTitleChangerEditor()
        {
            EditorApplication.update += SetWindowTitle;
        }

        private static string GetText()
        {
            return
                $"{Application.productName} - " +
                $"{Application.version} - " +
                $"{SceneManager.GetActiveScene().name} - " +
                $"{EditorUserBuildSettings.activeBuildTarget} - " +
                $"{Application.unityVersion} - " +
                $"{Application.dataPath}";
        }

#if UNITY_EDITOR_WIN

        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        public static extern bool SetWindowText(IntPtr hwnd, string lpString);

        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        private static void SetWindowTitle()
        {
            IntPtr windowPtr = GetActiveWindow();
            SetWindowText(windowPtr, GetText());
        }

#else
        private static void SetWindowTitle()
        {
    
        }
#endif
    }
}
