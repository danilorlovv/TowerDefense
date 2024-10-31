using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    public class TDPatrolController : AIController
    {
        private Path m_Path;
        private int m_PathIndex;

        public void SetPath(Path path)
        {
            m_Path = path;
            m_PathIndex = 0;

            SetPatrolBehaviour(m_Path[m_PathIndex]);
        }

        protected override void GetNewPoint()
        {
            m_PathIndex++;
            if (m_Path.Length > m_PathIndex)
                SetPatrolBehaviour(m_Path[m_PathIndex]);
            else
                Destroy(gameObject);
        }
    }
}