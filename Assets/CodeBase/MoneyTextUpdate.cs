using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class MoneyTextUpdate : MonoBehaviour
    {
        private Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
            TDPlayer.OnGoldUpdate += UpdateText;
        }

        private void UpdateText(int gold)
        {
            m_Text.text = gold.ToString();
        }
    }
}