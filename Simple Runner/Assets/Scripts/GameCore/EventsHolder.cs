using System;
using UI;

namespace GameCore
{
    public static class EventsHolder
    {
        public static event Action<InputPanelState> InputPanelChanged;
        public static event Action<int> OnPlayerPickUpCoin;
        public static event Action<int> OnPlayerHitObstacle;

        public static event Action OnStartGame;
        public static event Action OnEndGame;

        public static void RaiseInputPanelState(InputPanelState inputPanel)
        {
            InputPanelChanged?.Invoke(inputPanel);
        }
        
        public static void PickUpCoinEvent(int coinCount)
        {
            OnPlayerPickUpCoin?.Invoke(coinCount);
        }
        public static void PlayerHitObstacleEvent(int livesCount)
        {
            OnPlayerHitObstacle?.Invoke(livesCount);
        }

        public static void StartGameEvent()
        {
            OnStartGame?.Invoke();
        }
        
        public static void EndGameEvent()
        {
            OnEndGame?.Invoke();
        }
    }
}
