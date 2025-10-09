using UI.Pages;
using UnityEngine;

namespace UI
{
    public class StartMenuManager : MonoBehaviour
    {
        [SerializeField] private PagesSelector pagesSelector;

        private void Start()
        {
            pagesSelector.NavigateToPage<Start>();
        }
    }
}