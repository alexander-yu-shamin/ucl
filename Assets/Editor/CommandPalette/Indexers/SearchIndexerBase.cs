using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCL.Assets.Editor.CommandPalette.Indexers
{
    public abstract class SearchIndexerBase
    {
        public abstract List<ISearchableElement> GetElements();

        public abstract void OnOpen();

        public abstract void Initialize();

        public abstract void OnQuery(string query);

    }
}
