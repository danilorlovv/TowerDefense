using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    public class Enemy : MonoBehaviour
    {
        public void Use(EnemyAsset asset)
        {
            transform.GetComponentInChildren<SpriteRenderer>().color = asset.m_Color;
        }
    }
}