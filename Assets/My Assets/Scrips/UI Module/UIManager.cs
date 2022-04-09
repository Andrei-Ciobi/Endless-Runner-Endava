using My_Assets.Scrips.Input_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.UI_Module
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public bool IsGamePaused => isGamePaused;
        [SerializeField] private BaseMenuUI pauseMenu;
        [SerializeField] private EndGameMenuUI endGameMenu;

        private bool isGamePaused;
        private void Awake()
        {
            InitializeMonoSingleton();
        }

        public void SwitchPauseGame()
        {
            if (isGamePaused)
            {
                pauseMenu.gameObject.SetActive(false);
                UnpauseGame();
            }
            else
            {
                PauseGame();
                pauseMenu.gameObject.SetActive(true);
            }
        }

        public void OnEndGame()
        {
            endGameMenu.gameObject.SetActive(true);
            endGameMenu.OnEndGame();
            PauseGame();
        }

        private void PauseGame()
        {
            isGamePaused = true;
            Time.timeScale = 0f;
            GameInputManager.Instance.DisablePlayerActionMap();
            
        }

        private void UnpauseGame()
        {
            GameInputManager.Instance.EnablePlayerActionMap();
            isGamePaused = false;
            Time.timeScale = 1f;
        }
    }
}
