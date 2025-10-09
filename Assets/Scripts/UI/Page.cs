using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public abstract class Page : MonoBehaviour
    {
        public VisualTreeAsset pageAsset;
        
        protected VisualElement PageRoot;
        protected PagesSelector PageSelector;

        public virtual void Initialize(VisualElement root, PagesSelector pagesSelector)
        {
            PageRoot = root;
            PageSelector = pagesSelector;
        }
        
        public abstract void Activate();
        
        public abstract void Deactivate();
    }
}
