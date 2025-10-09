using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Pages
{
    public class Start : Page
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;

        public override void Activate()
        {
            _startButton = PageRoot.Q<Button>("StartButton");
            _startButton.clicked += ToGame;

            _settingsButton = PageRoot.Q<Button>("SettingsButton");
            _settingsButton.clicked += ToSettings;

            _exitButton = PageRoot.Q<Button>("ExitButton");
            _exitButton.clicked += ToExit;
        }

        public override void Deactivate()
        {
            _startButton.clicked -= ToGame;
            _settingsButton.clicked -= ToSettings;
            _exitButton.clicked -= ToExit;
        }

        private void ToGame()
        {
            Debug.Log("Start Game");
        }

        private void ToSettings()
        {
            PageSelector.NavigateToPage<Settings>();
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