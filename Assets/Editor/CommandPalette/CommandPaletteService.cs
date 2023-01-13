using System.Collections.Generic;
using UCL.Assets.Editor.CommandPalette.Indexers;
using UCL.Assets.Scripts.Components.DesignPatterns.CreationalPatterns;
using UnityEditor;

namespace UCL.Assets.Editor.CommandPalette
{
    [InitializeOnLoad]
    public class CommandPaletteService : Singleton<CommandPaletteService>
    {
        private readonly List<SearchIndexerBase> _indexers = new List<SearchIndexerBase>();

        protected override void Initialize()
        {
            base.Initialize();
            _indexers.Clear();
            //_indexers.Add();
        }
    }

}
