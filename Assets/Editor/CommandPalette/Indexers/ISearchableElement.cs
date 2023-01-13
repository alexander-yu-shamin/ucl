using UnityEngine;

namespace UCL.Assets.Editor.CommandPalette.Indexers
{
    public interface ISearchableElement
    {
        string PrimaryContents { get; }
        string SecondaryContents { get; }
        float Priority { get; }

        Texture2D Icon { get; }
        string Title { get; }
        string Description { get; }
        bool SupportDrag { get; }
        Object DragObject { get; }

        void Select();

        void Execute();
    }

}
