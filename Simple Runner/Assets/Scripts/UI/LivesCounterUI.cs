using System.Net.Mime;
using GameCore;
using PlayerModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class LivesCounterUI : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        
        private Text _textComponent;
        private int _livesDestroyed;

        private void Awake()
        {
            _textComponent = GetComponent<Text>();
        }

        private void Start()
        {
            _livesDestroyed = playerSettings.lives;
                
            EventsHolder.OnPlayerHitObstacle += ChangeLivesValueText;
            SetText(_livesDestroyed.ToString());
        }

        private void ChangeLivesValueText(int livesCount)
        {
            _livesDestroyed -= livesCount;
            if(_livesDestroyed >= 0)
            {
                SetText(_livesDestroyed.ToString());
            }
        }

        private void SetText(string text)
        {
            _textComponent.text = text;
        }
    }
}
