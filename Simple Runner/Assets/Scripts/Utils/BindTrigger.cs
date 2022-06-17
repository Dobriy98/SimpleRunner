using UnityEngine;

namespace Utils
{
    public class BindTrigger : MonoBehaviour
    {
        private IBindTrigger _receiver;

        private void Awake()
        {
            _receiver = GetComponentInParent<IBindTrigger>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _receiver?.EnterTriggerSignal(other);
        }
        
        private void OnTriggerExit(Collider other)
        {
            _receiver?.ExitTriggerSignal(other);
        }
    }
}
