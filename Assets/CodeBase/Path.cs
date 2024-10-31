using UnityEngine;
using SpaceShooter;
using UnityEditor;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol[] m_Points;

        public int Length { get => m_Points.Length; }
        public AIPointPatrol this[int index] { get => m_Points[index]; }


#if UNITY_EDITOR
        private static readonly Color GizmoColor = Color.green;

        private void OnDrawGizmosSelected()
        {
            Handles.color = GizmoColor;
            if (m_Points != null)
            {
                foreach (var point in m_Points)
                {
                    Handles.DrawSolidDisc(point.transform.position, transform.forward, point.Radius);
                }
            }
        }
#endif
    }
}