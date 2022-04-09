using My_Assets.Scrips.Game_module;
using TMPro;
using UnityEngine;

namespace My_Assets.Scrips.UI_Module
{
    public class EndGameMenuUI : BaseMenuUI
    {
        [SerializeField] private TextMeshProUGUI scoreValue;
        [SerializeField] private TextMeshProUGUI scoreText;


        public void OnEndGame()
        {
            SetScoreText(GameInventoryManager.Instance.NewHighScore() ? "New score record" : "Your score");
            SetScoreValue(GameInventoryManager.Instance.GetCurrentRunScore());
        }

        private void SetScoreValue(float value)
        {
            scoreValue.text = value.ToString("F2");
        }

        private void SetScoreText(string text)
        {
            scoreText.text = text;
        }
    }
}