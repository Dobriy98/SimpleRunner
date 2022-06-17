using GameCore;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class InputPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private InputPanelState _state;
        public void OnDrag(PointerEventData eventData)
        {
            _state.value = (eventData.position-eventData.pressPosition)*0.01f;
            _state.value = Vector2.ClampMagnitude(_state.value,1);
            EventsHolder.RaiseInputPanelState(_state);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _state.value = Vector2.zero;
            EventsHolder.RaiseInputPanelState(_state);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _state.value = Vector2.zero;
            EventsHolder.RaiseInputPanelState(_state);
        }
    }
}
