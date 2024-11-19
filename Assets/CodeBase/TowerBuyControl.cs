using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerBuyControl : MonoBehaviour
    {
        [SerializeField] private TowerAsset m_TowerAsset;
        [SerializeField] private Button m_Button;

        [SerializeField] private Transform m_BuildSite;
        public Transform BuildSite { set { m_BuildSite = value; } }

        private Text m_Text;

        private void Start()
        {
            m_Text = GetComponentInChildren<Text>();
            m_Text.text = m_TowerAsset.Cost.ToString();

            
            m_Button.GetComponent<Image>().sprite = m_TowerAsset.TowerIcon;

            TDPlayer.GoldUpdateSubscribe(GoldStatusUpdate);
        }

        private void GoldStatusUpdate(int gold)
        {
            if (gold >= m_TowerAsset.Cost != m_Button.interactable)
            {
                m_Button.interactable = !m_Button.interactable;
                m_Text.color = m_Button.interactable ? Color.white : Color.red;
            }
        }

        public void Buy()
        {
            TDPlayer.Instance.TryBuild(m_TowerAsset, m_BuildSite);
        }
    }
}