using UnityEngine;

namespace UCL.Assets.Editor.IconHelper
{
    public static class IconHelper 
    {
        public static Texture2D GetIconForFile(string filename)
        {
            return UnityEditorInternal.InternalEditorUtility.FindIconForFile(filename);
        }
    }
}
