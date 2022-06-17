using System;
using Spawnable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TileModel
{
    public class TileSpawner
    {
        private readonly SpawnableFactory _factory;
        private readonly Transform _tileTransform;

        private float _oneLocalStepZ;
        private float _localScaleFactor = 1;
        
        public TileSpawner(SpawnableFactory factory, Transform tileTransform)
        {
            _factory = factory;
            _tileTransform = tileTransform;

            _oneLocalStepZ = 0;
        }
        
        public void Spawn(int countSpawnableObjects)
        {
            int spawnableLength = Enum.GetNames(typeof(SpawnableType)).Length;
            _oneLocalStepZ = _localScaleFactor / countSpawnableObjects;
            for (int i = 0; i < countSpawnableObjects; i++)
            {
                var randomObject = (SpawnableType)Random.Range(0, spawnableLength);
                SpawnableObject spawnedObject = _factory.Get(randomObject);
                
                if(spawnedObject != null)
                {
                    float positionZ = i * _oneLocalStepZ;
                    spawnedObject.SpawnToParentPosition(_tileTransform, positionZ);
                }
            }
        }
    }
}