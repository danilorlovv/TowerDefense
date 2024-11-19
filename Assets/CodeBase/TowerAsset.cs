using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public class TowerAsset : ScriptableObject
    {
        public Sprite TowerIcon;
        public Sprite TowerSprite;

        public int Cost = 25;
    }
}