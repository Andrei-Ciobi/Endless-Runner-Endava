using My_Assets.Scrips.Game_module;
using UnityEngine;

namespace My_Assets.Scrips.UI_Module
{
    public class BaseMenuUI : MonoBehaviour
    {
        public void ResumeGame()
        {
            UIManager.Instance.SwitchPauseGame();
        }

        public void GoToMainMenu()
        {
            UIManager.Instance.LoadMenuScene();
        }

        public void Restart()
        {
            UIManager.Instance.LoadGameScene();
        }

        public void StartGame()
        {
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}