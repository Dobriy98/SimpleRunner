using UnityEngine;

namespace Utils
{
    public interface IBindTrigger
    {
        void EnterTriggerSignal(Collider receivedCollider);
        void ExitTriggerSignal(Collider receivedCollider);
    }
}
