using UnityEngine;
using System;
using SpaceShooter;
using UnityEngine.UIElements;

namespace TowerDefense
{
    public class TDPlayer : Player
    {

        public static new TDPlayer Instance
        {
            get
            {
                return Player.Instance as TDPlayer;
            }
        }


        private static event Action<int> OnGoldUpdate;
        public static void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_Gold);
        }

        private static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.m_NumLives);
        }

        [SerializeField] private int m_Gold = 0;
        public int Gold => m_Gold;

        private void Start()
        {
            OnGoldUpdate(m_Gold);
            OnLifeUpdate(m_NumLives);
        }

        public void TakeDamage(int damage)
        {
            if (m_NumLives - damage > 0)
                m_NumLives -= damage;
            else
                m_NumLives = 0;

            OnLifeUpdate(m_NumLives);
            //LevelSequenceController.Instance.FinishCurrentLevel(false);
        }

        public void ChangeGold(int change)
        {
            m_Gold += change;
            OnGoldUpdate(m_Gold);
        }

        [SerializeField] private Tower m_TowerPrefab;

        public void TryBuild(TowerAsset m_TowerAsset, Transform m_BuildSite)
        {
            ChangeGold(-m_TowerAsset.Cost);
            var tower = Instantiate(m_TowerPrefab, m_BuildSite.position, Quaternion.identity);
            tower.GetComponentInChildren<SpriteRenderer>().sprite = m_TowerAsset.TowerSprite;
            Destroy(m_BuildSite.gameObject);
        }
    }
}