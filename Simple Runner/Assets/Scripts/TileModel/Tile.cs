using System;
using PlayerModel;
using Spawnable;
using TilesGeneration;
using UnityEngine;
using Utils;

namespace TileModel
{
    public class Tile : MonoBehaviour, IBindTrigger
    {
        public Transform floorTransform;
        [SerializeField] private SpawnableFactory spawnableFactory;
        [SerializeField] private int spawnObjectCount = 3;
        
        private TileGenerator _tileGenerator;
        protected TileSpawner Spawner;
        public void Init(TileGenerator tileGenerator, bool firstTile)
        {
            _tileGenerator = tileGenerator;

            if(!firstTile) InitSpawner();
        }

        public void EnterTriggerSignal(Collider receivedCollider)
        {
            if (receivedCollider.CompareTag("Player") && _tileGenerator != null)
            {
                _tileGenerator.CreateTile();
            }
        }

        private void InitSpawner()
        {
            Spawner = new TileSpawner(spawnableFactory, floorTransform);
            Spawner.Spawn(spawnObjectCount);
        }

        public void ExitTriggerSignal(Collider receivedCollider) { }
    }
}