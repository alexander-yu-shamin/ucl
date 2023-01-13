using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCL.Assets.Editor.CommandPalette.Indexers
{
    public class AssetSearchableElement : ISearchableElement
    {
        public string PrimaryContents { get; }
        public string SecondaryContents { get; }
        public float Priority { get; }
        public Texture2D Icon { get; }
        public string Title { get; }
        public string Description { get; }
        public bool SupportDrag { get; }
        public Object DragObject { get; }
        public void Select()
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
