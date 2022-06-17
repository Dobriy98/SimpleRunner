using GameCore;
using UnityEngine;

namespace TileModel
{
    public class ObstacleWall : MonoBehaviour
    {
        [SerializeField] private int livesDestroy = 1;
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Player"))
            {
                EventsHolder.PlayerHitObstacleEvent(livesDestroy);
            }
        }
    }
}