using TMPro;
using UnityEngine;

namespace My_Assets.Scrips.UI_Module
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private TextMeshProUGUI coins;

        public void UpdateScore(float value)
        {
            var text = "Distance : " + value.ToString("F2") + "m";
            score.text = text;
        }

        public void UpdateCoins(int value)
        {
            coins.text = value.ToString();
        }
    }
}