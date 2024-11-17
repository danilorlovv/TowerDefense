using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerBuyControl : MonoBehaviour
    {
        [SerializeField] private TowerAsset m_TowerAsset;

        private Text m_Text;
        [SerializeField] private Button m_Button;

        private void Awake()
        {
            m_Text = GetComponentInChildren<Text>();
            m_Text.text = m_TowerAsset.Cost.ToString();

            
            m_Button.GetComponent<Image>().sprite = m_TowerAsset.TowerIcon;

            TDPlayer.OnGoldUpdate += GoldStatusUpdate;
        }

        private void GoldStatusUpdate(int gold)
        {
            if (gold >= m_TowerAsset.Cost != m_Button.interactable)
            {
                m_Button.interactable = !m_Button.interactable;
                m_Text.color = m_Button.interactable ? Color.white : Color.red;
            }
        }
    }
}