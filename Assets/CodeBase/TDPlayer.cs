using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    public class TDPlayer : Player
    {
        private int m_Gold = 0;
        public int Gold => m_Gold;

        public void TakeDamage(int damage)
        {
            if (m_NumLives - damage > 0)
                m_NumLives -= damage;
            else
                m_NumLives = 0;
            //LevelSequenceController.Instance.FinishCurrentLevel(false);
        }

        public void ChangeGold(int change)
        {
            m_Gold += change;
        }
    }
}