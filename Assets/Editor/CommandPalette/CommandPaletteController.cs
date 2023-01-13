using System;
using UnityEngine;
using UnityEditor;

namespace UCL.Assets.Editor.CommandPalette
{
    public static class CommandPaletteController
    {
        private static CommandPaletteView View = null;


        [MenuItem("Window/Command Palette %`")]
        private static void ToggleCommandPalette()
        {
            if (View == null)
            {
                ShowView();
            }
            else
            {
                CloseView();
            }
        }

        private static void ShowView()
        {
            if (View != null)
            {
                return;
            }

            View = ScriptableObject.CreateInstance<CommandPaletteView>();
            View.OnCloseWindow += CloseView;
            View.Show();
        }

        private static void CloseView()
        {
            if (View == null)
            {
                return;
            }

            View.OnCloseWindow -= CloseView;
            View.Close();
            View = null;
        }
    }
}
