using UnityEngine;

namespace Spawnable
{
    public class SpawnableObject : MonoBehaviour
    {
        private readonly float _halfLocalParentScale = 0.5f;
        public void SpawnToParentPosition(Transform parent, float positionZ)
        {
            transform.SetParent(parent);
            Vector3 localPosition = GetRandomLocalPosition(parent);
            localPosition.z = positionZ - _halfLocalParentScale;
            transform.localPosition = localPosition;
        }
        
        private Vector3 GetRandomLocalPosition(Transform parent)
        {
            Vector3 randomPosition = Vector3.zero;
            Vector3 objectScale = transform.localScale;
            randomPosition.x = Random.Range(-_halfLocalParentScale + objectScale.x/2, _halfLocalParentScale - objectScale.x/2);
            randomPosition.y = parent.lossyScale.y;
            return randomPosition;
        }
    }
}