using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PedroAurelio.MenuScreens
{
    [DisallowMultipleComponent]
    public class MenuController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private MenuPage initialPage;
        [SerializeField] private GameObject firstFocusItem;
        [SerializeField] private List<GameObject> exitButtons;

        [Header("Settings")]
        [SerializeField] private bool shouldAnimateFirst;

        private Stack<MenuPage> _pageStack = new Stack<MenuPage>();
        private bool _shouldAnimate;

        private void Start()
        {
            _shouldAnimate = shouldAnimateFirst;

            #if UNITY_WEBGL && !UNITY_EDITOR
                foreach (GameObject button in exitButtons)
                    button.SetActive(false);
            #endif

            if (firstFocusItem != null)
                EventSystem.current.SetSelectedGameObject(firstFocusItem);

            if (initialPage != null)
                PushPage(initialPage);
        }

        public void ExitGame() => Application.Quit();

        #region Bool Checks
        public bool IsPageInStack(MenuPage page)
        {
            return _pageStack.Contains(page);
        }

        public bool IsPageOnTopOfStack(MenuPage page)
        {
            return _pageStack.Count > 0 && page == _pageStack.Peek();
        }
        #endregion

        #region Stack Methods
        public void PushPage(MenuPage newPage)
        {
            if (!_shouldAnimate)
                _shouldAnimate = true;
            else
                newPage.Enter(true);

            if (_pageStack.Count > 0)
            {
                var currentPage = _pageStack.Peek();

                if (currentPage.ExitOnNewPagePush)
                    currentPage.Exit(true);
            }

            _pageStack.Push(newPage);
        }

        public void PopPage()
        {
            if (_pageStack.Count > 1)
            {
                var currentPage = _pageStack.Pop();
                currentPage.Exit(true);

                var newCurrentPage = _pageStack.Peek();

                if (newCurrentPage.ExitOnNewPagePush)
                    newCurrentPage.Enter(false);
            }
            else
                Debug.LogWarning($"Can't pop a page when it's the only one remaining.");
        }

        public void PopAllPages()
        {
            for (int i = 1; i < _pageStack.Count; i++)
            {
                PopPage();
            }
        }
        #endregion
    }
}