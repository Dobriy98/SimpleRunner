using System;
using GameCore;
using UnityEngine;

namespace PlayerModel
{
    public class PlayerSpeedUp
    {
        private PlayerSpeedUpConditions _speedUpConditions;
        private Action<float> _speedUpAction;
        private int _coinsTaken;
        private int _conditionIndex;
        public PlayerSpeedUp(PlayerSpeedUpConditions speedUpConditions, Action<float> speedUpAction)
        {
            _speedUpConditions = speedUpConditions;
            _speedUpAction = speedUpAction;
            _conditionIndex = 0;
            
            EventsHolder.OnPlayerPickUpCoin += CheckSpeed;
        }

        private void CheckSpeed(int coinCount)
        {
            _coinsTaken += coinCount;
            
            if (_conditionIndex >= _speedUpConditions.conditions.Length) return;
            
            PlayerSpeedUpCondition condition = _speedUpConditions.conditions[_conditionIndex];
            if (_coinsTaken >= condition.coinsToSpeedUp)
            {
                _speedUpAction?.Invoke(condition.speedUpFactor);
                _conditionIndex++;
            }
        }
    }
}