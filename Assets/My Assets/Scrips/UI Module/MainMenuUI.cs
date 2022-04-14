using UnityEngine;

namespace My_Assets.Scrips.UI_Module
{
    public class MainMenuUI : BaseMenuUI
    {
        public void PlayGame()
        {
            UIManager.Instance.LoadGameScene();
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        
    }
}