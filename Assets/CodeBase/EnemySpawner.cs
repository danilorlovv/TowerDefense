using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy m_EntityPrefab;
        [SerializeField] private EnemyAsset[] m_EnemyAsset;
        [SerializeField] private Path m_Path;

        protected override GameObject GenerateSpawnedEntity()
        {
            var e = Instantiate(m_EntityPrefab);

            e.Use(m_EnemyAsset[Random.Range(0, m_EnemyAsset.Length)]);
            e.GetComponent<TDPatrolController>().SetPath(m_Path);

            return e.gameObject;
        }
    }
}