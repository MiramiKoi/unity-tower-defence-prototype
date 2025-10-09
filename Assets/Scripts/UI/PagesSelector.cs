using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class PagesSelector : MonoBehaviour
    {
        [SerializeField] private List<Page> pagesList;
        [SerializeField] private UIDocument uiDocument;
        
        private Page _currentPage;

        // Поиск и переход на новую страницу интерфейса
        public void NavigateToPage<T>() where T : Page
        {
            var page = pagesList.Find(p => p is T);

            if (page == null)
            {
                Debug.LogError($"Страницы {typeof(T).Name} не существует!");
                return;
            }
           
            SelectPage(page);
        }
        
        private void SelectPage(Page page)
        {
            DeselectPage();
            
            _currentPage = page;
            
            uiDocument.visualTreeAsset = _currentPage.pageAsset;
            
            _currentPage.Initialize(uiDocument.rootVisualElement, this);
            _currentPage.Activate();
        }
        
        private void DeselectPage()
        {
            _currentPage?.Deactivate();
            _currentPage = null;
        }
    }
}
