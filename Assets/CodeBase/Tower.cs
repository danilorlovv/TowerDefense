using UnityEditor;
using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float m_Radius;

        private Turret[] m_Turrets;
        private Destructible m_Target;

        private void Start()
        {
            m_Turrets = GetComponentsInChildren<Turret>();
        }

        private void Update()
        {
            if (m_Target)
            {
                Vector2 targetVector = (m_Target.transform.position - transform.position);
                if (targetVector.magnitude > m_Radius)
                {
                    m_Target = null;
                    return;
                }

                foreach (var turret in m_Turrets)
                {
                    turret.transform.up = targetVector;
                    turret.Fire();
                }
            }
            else
            {
                var enter = Physics2D.OverlapCircle(transform.position, m_Radius);
                if (enter)
                    m_Target = enter.transform.root.GetComponent<Destructible>();
            }
        }

#if UNITY_EDITOR
        private static readonly Color GizmoColor = new Color(0, 1, 0, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Handles.color = GizmoColor;
            Handles.DrawSolidDisc(transform.position, transform.forward, m_Radius);
        }
#endif
    }
}