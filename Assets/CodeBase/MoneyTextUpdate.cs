using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class MoneyTextUpdate : MonoBehaviour
    {
        private Text m_Text;

        private void Start()
        {
            m_Text = GetComponent<Text>();
            TDPlayer.GoldUpdateSubscribe(UpdateText);
        }

        private void UpdateText(int gold)
        {
            m_Text.text = gold.ToString();
        }
    }
}