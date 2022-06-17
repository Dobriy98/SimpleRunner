using System;
using GameCore;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class CoinsCounterUI : MonoBehaviour
    {
        private Text _textComponent;
        private int _coinsTaked;

        private void Awake()
        {
            _textComponent = GetComponent<Text>();
        }

        private void Start()
        {
            _coinsTaked = 0;
            
            EventsHolder.OnPlayerPickUpCoin += ChangeCoinValueText;
        }

        private void ChangeCoinValueText(int coinsCount)
        {
            _coinsTaked += coinsCount;
            _textComponent.text = _coinsTaked.ToString();
        }

        private void OnDestroy()
        {
            EventsHolder.OnPlayerPickUpCoin -= ChangeCoinValueText;
        }
    }
}
