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
            
        }

        public void Restart()
        {
            
        }


    }
}