using GameCore;
using UnityEngine;
using Utils;

namespace Spawnable
{
    public class Coin : SpawnableObject, IBindTrigger
    {
        [SerializeField] private int coinValue = 1;
        
        public void EnterTriggerSignal(Collider receivedCollider)
        {
            if (receivedCollider.CompareTag("Player"))
            {
                EventsHolder.PickUpCoinEvent(coinValue);
                Destroy(gameObject);
            }
        }

        public void ExitTriggerSignal(Collider receivedCollider) { }
    }
}