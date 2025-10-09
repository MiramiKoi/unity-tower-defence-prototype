using UnityEngine.UIElements;

namespace UI.Pages
{
    public class Settings : Page
    {
        private Button _backButton;
        private Button _exitButton;
        
        public override void Activate()
        {
            _backButton = PageRoot.Q<Button>("BackButton");
            _backButton.clicked += ToStart;
            
            _exitButton = PageRoot.Q<Button>("ExitButton");
            _exitButton.clicked += ToExit;
        }

        public override void Deactivate()
        {
            _backButton.clicked -= ToStart;
            _exitButton.clicked -= ToExit;
        }

        private void ToStart()
        {
            PageSelector.NavigateToPage<Start>();
        }

        private void ToExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}