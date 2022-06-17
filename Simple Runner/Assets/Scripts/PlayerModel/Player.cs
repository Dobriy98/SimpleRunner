using System;
using GameCore;
using UnityEngine;

namespace PlayerModel
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private PlayerSpeedUpConditions conditionsToSpeedUp;
        [SerializeField] private float initMovementSpeed = 2;

        private PlayerMovement _playerMovement;
        private Rigidbody _playerRb;
        private float _movementSpeed;
        private int _lives;

        private bool _startGame;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody>();
            _playerMovement = new PlayerMovement(_playerRb);
            PlayerSpeedUp playerSpeedUp = new PlayerSpeedUp(conditionsToSpeedUp, SpeedUp);
        }

        private void Start()
        {
            _lives = playerSettings.lives;
            Debug.Log(_lives + " Start");
            _movementSpeed = initMovementSpeed;

            EventsHolder.OnPlayerHitObstacle += DestroyLives;
            EventsHolder.OnStartGame += StartMove;
        }

        private void OnDestroy()
        {
            EventsHolder.OnPlayerHitObstacle -= DestroyLives;
            EventsHolder.OnStartGame -= StartMove;
        }

        private void FixedUpdate()
        {
            if(_startGame)
            {
                _playerMovement.Move(_movementSpeed);
            }
        }

        private void SpeedUp(float speedUpFactor)
        {
            _movementSpeed = initMovementSpeed * speedUpFactor;
        }

        private void DestroyLives(int livesCount)
        {
            if(_lives > 0)
            {
                _lives -= livesCount;
                Debug.Log(_lives);
            }
            else
            {
                Debug.Log("EndEvent");
                EventsHolder.EndGameEvent();
            }
        }

        private void StartMove()
        {
            _startGame = true;
        }
    }
}
