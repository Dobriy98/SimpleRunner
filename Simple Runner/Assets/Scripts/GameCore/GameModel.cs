using GameCore;
using PlayerModel;
using UnityEngine;

namespace GameCore
{
    public class GameModel : MonoBehaviour
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private CameraFollow cameraFollow;
        private void Start()
        {
            var sceneController = new SceneController();
            var player = CreatePlayer();
            cameraFollow.State.target = player.transform;
        }

        private Player CreatePlayer()
        {
            return Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
