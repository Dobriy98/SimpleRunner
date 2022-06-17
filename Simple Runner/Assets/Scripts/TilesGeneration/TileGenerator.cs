using System.Collections.Generic;
using TileModel;
using UnityEngine;

namespace TilesGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private Tile tilePrefab;

        private Queue<Tile> _tiles;
        private int _maxTilesCount = 2;
        private Vector3 _firstTilePosition;
        private Tile _lastTile;

        private bool CanDestroy => _tiles.Count > _maxTilesCount;
        private bool QueueIsEmpty => _tiles.Count == 0;
        private void Start()
        {
            _firstTilePosition = new Vector3(0, -1, -3);
            _tiles = new Queue<Tile>();
            CreateTiles(_maxTilesCount);
        }

        public void CreateTile()
        {
            DestroyTile();
            Vector3 tilePosition = CalculateTilePosition();
            var tile = CreateTileInstance(tilePosition, QueueIsEmpty);
            _lastTile = tile;
            _tiles.Enqueue(tile);
        }

        private Tile CreateTileInstance(Vector3 tilePosition, bool firstTile)
        {
            var tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
            tile.Init(this, firstTile);
            return tile;
        }

        public void CreateTiles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateTile();
            }
        }

        private void DestroyTile()
        {
            if (CanDestroy)
            {
                var tileToDestroy = _tiles.Dequeue();
                Destroy(tileToDestroy.gameObject);
            }
        }


        private Vector3 CalculateTilePosition()
        {
            if(QueueIsEmpty) return _firstTilePosition;
            
            float floorScaleZ = _lastTile.floorTransform.localScale.z;
            
            Vector3 positionToSpawn = _lastTile.transform.position;
            positionToSpawn.z += floorScaleZ;
            
            return positionToSpawn;
        }

    }
}
