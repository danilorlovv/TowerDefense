using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {
        [Header("Visual")]
        public Color m_Color = Color.white;
        public float m_SizeScale = 1.0f;
        public RuntimeAnimatorController m_AnimatorController;
        public float m_ColliderRadius = 0.2f;

        [Header("Stats")]
        public float m_Speed = 1.0f;
        public int m_Health = 10;
        public int m_Score = 1;

    }
}