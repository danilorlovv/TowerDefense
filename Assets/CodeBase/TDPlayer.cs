using UnityEngine;
using System;
using SpaceShooter;

namespace TowerDefense
{
    public class TDPlayer : Player
    {
        public static event Action<int> OnGoldUpdate;
        public static event Action<int> OnLifeUpdate;

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
    }
}