using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

namespace UCL.Assets.Editor.CommandPalette.Indexers
{
    public class AssetIndexer : SearchIndexerBase
    {
        private readonly List<AssetSearchableElement> _elements = new List<AssetSearchableElement>(200);
        private static readonly Queue<AssetSearchableElement> _elementsQueue = new Queue<AssetSearchableElement>(500);


        public override List<ISearchableElement> GetElements()
        {
            throw new System.NotImplementedException();
        }

        public override void OnOpen()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize()
        {
            ReindexElements();
        }

        public override void OnQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        private void ReindexElements()
        {
            var thread = new Thread(CollectAssets);
            thread.Start(AssetDatabase.GetAllAssetPaths());
        }

        private void CollectAssets(object arg)
        {
            try
            {
                var assetPaths = arg as string[];
                lock (_elements)
                {
                    _elements.Clear();
                    foreach (var assetPath in assetPaths)
                    {
                        if (!assetPath.StartsWith("Assets/"))
                        {
                            continue;
                        }
                        //_elements.Add(assetPath);
                    }
                }
                

            }
            catch
            {
            }
        }
    }
}
