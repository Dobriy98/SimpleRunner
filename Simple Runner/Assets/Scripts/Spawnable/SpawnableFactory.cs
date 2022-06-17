using GameCore;
using UnityEngine;

namespace Spawnable
{
    [CreateAssetMenu]
    public class SpawnableFactory : GameObjectFactory
    {
        [SerializeField] private Coin coinPrefab;
        [SerializeField] private ObstacleCube obstacleCubePrefab;

        public SpawnableObject Get(SpawnableType type)
        {
            switch (type)
            {
                case SpawnableType.Coin:
                    return GetGameObjectInstance(coinPrefab);
                case SpawnableType.Obstacle:
                    return GetGameObjectInstance(obstacleCubePrefab);
                default:
                    return GetGameObjectInstance(coinPrefab);
            }
        }
    }

    public enum SpawnableType
    {
        Coin, Obstacle
    }
}
