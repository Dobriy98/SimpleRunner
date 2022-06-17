using GameCore;
using UI;
using UnityEngine;

namespace PlayerModel
{
    public class PlayerMovement
    {
        private readonly Rigidbody _playerRb;
        private Vector3 _moveDirection;
        
        public PlayerMovement(Rigidbody playerRb)
        {
            if(playerRb == null) Debug.LogError("No rigidbody on the player");
            _playerRb = playerRb;
            _moveDirection = Vector3.forward;
            
            EventsHolder.InputPanelChanged += ChangeDirectionX;
        }
        
        public void Move(float speed)
        {
            Vector3 offset = _moveDirection.normalized * speed * Time.deltaTime;
            _playerRb.MovePosition(_playerRb.position + offset);
        }
        private void ChangeDirectionX(InputPanelState inputState)
        {
            _moveDirection.x = inputState.value.x;
        }
    }
}
