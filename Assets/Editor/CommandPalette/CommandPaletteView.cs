using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Xml;
using NUnit.Framework;
using UCL.Assets.Editor.CommandPalette.Indexers;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace UCL.Assets.Editor.CommandPalette
{
    public class CommandPaletteView : EditorWindow
    {
        public event Action OnCloseWindow;
        public event Action<string> OnQueryChanged; 
        public List<ISearchableElement> SearchableElements { get; set; } = new List<ISearchableElement>(7);


        [SerializeField] private GUISkin _skin;
        [SerializeField] private Texture2D _iconTexture;

        public int SelectedIndex { get; set; }

        private GUISkin Skin => _skin;
        // Screen Size
        private const float WIDTH = 700;
        private const float VISIBLE_RESULT_LINES = 8;
        private const float ELEMENT_HEIGHT = 40;
        private const float HEADER_HEIGHT = 20;
        private const float SEARCH_FIELD_HEIGHT = 50;
        private const float MARGIN_X = 5.0f;
        private const float MARGIN_Y = 1.0f;

        private static readonly Vector2 WINDOW_SIZE =
            new Vector2(WIDTH, VISIBLE_RESULT_LINES * ELEMENT_HEIGHT + HEADER_HEIGHT + SEARCH_FIELD_HEIGHT);

        private static readonly Rect WINDOW_RECT = new Rect(0, 0, WINDOW_SIZE.x, WINDOW_SIZE.y);

        private readonly string HelpText = "Escape -> close tab";
        private string _query = null;

        private string Query
        {
            get => _query;
            set
            {
                if (_query != value)
                {
                    _query = value;
                    OnQueryChanged?.Invoke(_query);
                }
            }
        }


        private void OnEnable()
        {
            SearchableElements.Clear();
            SearchableElements.Add(new AssetSearchableElement());
            SearchableElements.Add(new AssetSearchableElement());
            SearchableElements.Add(new AssetSearchableElement());
            SearchableElements.Add(new AssetSearchableElement());
            SearchableElements.Add(new AssetSearchableElement());
            SearchableElements.Add(new AssetSearchableElement());
            SearchableElements.Add(new AssetSearchableElement());
        }

        private void OnDisable()
        {
        }

        private void OnLostFocus()
        {
            CloseView();
        }

        private void OnGUI()
        {
            DrawGUI();
            ProcessKeyboardEvents();
        }

        private void DrawGUI()
        {
            var lastRect = DrawHead(Rect.zero);
            (lastRect, Query) = DrawSearchField(lastRect, Query);
            foreach (var searchableElement in SearchableElements)
            {
                lastRect = DrawSearchElement(lastRect, searchableElement, false, OnElementClick, OnElementDrag);
            }


        }

        private void OnElementClick(ISearchableElement elem)
        {
            var idx = SearchableElements.IndexOf(elem);
            if (idx < 0)
                return;

            SetSelectedIndex(idx);
            Repaint();
        }

        private void OnElementDrag(ISearchableElement elem)
        {
            if (!elem.SupportDrag || elem.DragObject == null)
                return;

            DragAndDrop.PrepareStartDrag();
            DragAndDrop.objectReferences = new[] { elem.DragObject };
            DragAndDrop.StartDrag("Dragging Object");

            //isDragging_ = true;
        }



        private Rect DrawSearchElement(Rect rect, ISearchableElement element, bool selected,
            Action<ISearchableElement> onMouseDown, Action<ISearchableElement> onMouseDrag)
        {
            var elementRect = new Rect(0f, rect.yMax, WIDTH, ELEMENT_HEIGHT);
            var isHover = elementRect.Contains(Event.current.mousePosition);

            var elementSkin = Skin.GetStyle("element_normal");
            if (isHover) elementSkin = Skin.GetStyle("element_hover");
            if (selected) elementSkin = Skin.GetStyle("element_selected");

            if (element.Icon == null)
            {
                var iconRect = new Rect(elementRect.x + MARGIN_X, elementRect.y, ELEMENT_HEIGHT, ELEMENT_HEIGHT);
                GUI.DrawTexture(iconRect, _iconTexture, ScaleMode.ScaleToFit);
            }

            var titleRect = new Rect(elementRect.x + 35f, elementRect.y + 2f, WIDTH, 25f);
            var titleStyle = Skin.GetStyle(selected ? "title_selected" : "title_normal");
            GUI.Label(titleRect, element.Title, titleStyle);

            var descRect = new Rect(elementRect.x + 35f, elementRect.y + 23f, WIDTH, 25f);
            var descStyle = Skin.GetStyle(selected ? "desc_selected" : "desc_normal");
            GUI.Label(descRect, element.Description, descStyle);



            return elementRect;
        }
        private (Rect, string) DrawSearchField(Rect rect, string searchText)
        {
            var searchRect = new Rect(0f, rect.yMax, WIDTH, SEARCH_FIELD_HEIGHT);
            var queryStyle = Skin.GetStyle("query_style");
            var query = GUI.TextField(searchRect, searchText, queryStyle);

            var icon = new Vector2(queryStyle.fontSize, queryStyle.fontSize);
            var iconRect = new Rect(searchRect.x, searchRect.yMin, icon.x, icon.y);
            GUI.DrawTexture(iconRect, _iconTexture, ScaleMode.StretchToFill);

            return (searchRect, query);
        }

        private Rect DrawHead(Rect rect)
        {
            var headRect = new Rect(0, 0, WIDTH, HEADER_HEIGHT);
            var headStyle = Skin.GetStyle("head_title");
            GUI.Label(headRect, "Command Palette", headStyle);

            var helpStyle = Skin.GetStyle("help");
            GUI.Label(headRect, HelpText, helpStyle);
            return headRect;
        }

        private void ProcessKeyboardEvents()
        {
            var evt = Event.current;
            var keyCode = evt.keyCode;

            switch (keyCode)
            {
                case KeyCode.Escape:
                {
                    CloseView();
                    evt.Use();
                    break;
                }

                case KeyCode.Return:
                {
                    SearchQuery();
                    evt.Use();
                    break;
                }

                case KeyCode.UpArrow:
                {
                    SetSelectedIndex(SelectedIndex - 1);
                    evt.Use();
                    break;
                }

                case KeyCode.DownArrow:
                {
                    SetSelectedIndex(SelectedIndex + 1);
                    evt.Use();
                    break;
                }

                case KeyCode.Tab:
                case KeyCode.RightArrow:
                {
                    Select();
                    evt.Use();
                    break;
                }
            }
        }

        private void Select()
        {
            throw new NotImplementedException();
        }

        private int SetSelectedIndex(int selectedIndex)
        {
            throw new NotImplementedException();
        }


        private void SearchQuery()
        {
            throw new NotImplementedException();
        }

        private void CloseView()
        {
            OnCloseWindow?.Invoke();
        }
    }
}