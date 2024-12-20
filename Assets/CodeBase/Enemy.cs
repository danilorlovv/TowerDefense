using UnityEngine;
using SpaceShooter;
using UnityEditor;
using UnityEngine.UIElements;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int m_Damage = 1;
        [SerializeField] private int m_Gold = 1;

        public void Use(EnemyAsset asset)
        {
            GetComponentInChildren<SpriteRenderer>().color = asset.m_Color;
            transform.Find("VisualModel").localScale = new Vector2(1.0f, 1.0f) * asset.m_SizeScale;
            GetComponentInChildren<Animator>().runtimeAnimatorController = asset.m_AnimatorController;
            GetComponentInChildren<CircleCollider2D>().radius = asset.m_ColliderRadius;

            GetComponent<SpaceShip>().Use(asset);

            m_Damage = asset.m_Damage;
            m_Gold = asset.m_Gold;
        }

        public void DamagePlayer()
        {
            (Player.Instance as TDPlayer).TakeDamage(m_Damage);
        }

        public void GoldReward()
        {
            (Player.Instance as TDPlayer).ChangeGold(m_Gold);
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(Enemy))]
        public class EnemyInspector : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                EnemyAsset enemyAsset = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;
                if (enemyAsset)
                {
                    (target as Enemy).Use(enemyAsset);
                }
            }
        }
#endif
    }
}