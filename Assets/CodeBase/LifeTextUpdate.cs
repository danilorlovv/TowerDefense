using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class LifeTextUpdate : MonoBehaviour
    {
        private Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
            TDPlayer.OnLifeUpdate += UpdateText;
        }

        private void UpdateText(int life)
        {
            m_Text.text = life.ToString();
        }
    }
}