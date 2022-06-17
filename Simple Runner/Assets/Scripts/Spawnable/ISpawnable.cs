using UnityEngine;

namespace Spawnable
{
    public interface ISpawnable
    {
        public void SpawnToParentPosition(Vector3 position);
    }
}