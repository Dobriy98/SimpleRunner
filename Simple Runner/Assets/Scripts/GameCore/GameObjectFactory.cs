using UnityEngine;

namespace GameCore
{
    public class GameObjectFactory : ScriptableObject
    {
        protected T GetGameObjectInstance<T>(T prefab) where T : MonoBehaviour
        {
            T instance = Instantiate(prefab);
            return instance;
        }
    }
}