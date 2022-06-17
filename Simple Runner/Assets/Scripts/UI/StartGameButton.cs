using System;
using GameCore;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class StartGameButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            EventsHolder.StartGameEvent();
        }
    }
}
