using System;
using UnityEngine;

namespace PlayerModel
{
    [Serializable]
    public struct PlayerSpeedUpCondition
    {
        public int coinsToSpeedUp;
        public float speedUpFactor;
    }
}
