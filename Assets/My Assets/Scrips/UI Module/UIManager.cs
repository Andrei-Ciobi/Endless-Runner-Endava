using My_Assets.Scrips.Input_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace My_Assets.Scrips.UI_Module
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public bool IsGamePaused => isGamePaused;
        [SerializeField] private BaseMenuUI pauseMenu;
        [SerializeField] private EndGameMenuUI endGameMenu;
        [SerializeField] private PlayerUI playerUI;

        private bool isGamePaused;
        private void Awake()
        {
            InitializeMonoSingleton();
            Time.timeScale = 1f;
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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            
            endGameMenu.gameObject.SetActive(true);
            playerUI.gameObject.SetActive(false);
            endGameMenu.OnEndGame();
            PauseGame();
        }

        public void OnStartGame()
        {
            playerUI.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync(1);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadSceneAsync(0);
        }

        public PlayerUI GetPlayerUI()
        {
            return playerUI;
        }

        private void PauseGame()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            
            isGamePaused = true;
            Time.timeScale = 0f;
            GameInputManager.Instance.DisablePlayerActionMap();
            
        }
        

        private void UnpauseGame()
        {
            GameInputManager.Instance.EnablePlayerActionMap();
            isGamePaused = false;
            Time.timeScale = 1f;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
