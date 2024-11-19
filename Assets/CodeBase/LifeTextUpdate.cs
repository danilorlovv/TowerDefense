using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class LifeTextUpdate : MonoBehaviour
    {
        private Text m_Text;

        private void Start()
        {
            m_Text = GetComponent<Text>();
            TDPlayer.LifeUpdateSubscribe(UpdateText);
        }

        private void UpdateText(int life)
        {
            m_Text.text = life.ToString();
        }
    }
}