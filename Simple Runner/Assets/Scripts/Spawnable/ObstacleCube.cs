using GameCore;
using UnityEngine;
using Utils;

namespace Spawnable
{
    public class ObstacleCube: SpawnableObject, IBindTrigger
    {
        [SerializeField] private int livesDestroy = 1;
        public void EnterTriggerSignal(Collider receivedCollider)
        {
            if (receivedCollider.CompareTag("Player"))
            {
                EventsHolder.PlayerHitObstacleEvent(livesDestroy);
                Destroy(gameObject);
            }
        }

        public void ExitTriggerSignal(Collider receivedCollider) { }
    }
}