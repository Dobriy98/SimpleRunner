using System;
using UnityEngine;

    [Serializable]
    public class CameraState
    {
        public Transform target;
        public Vector3 positionOffset = Vector3.up;
        public Quaternion rotationOffset = Quaternion.identity;
        public float distance = 10;
        public float speed = 1;
    }
    
    public class CameraFollow : MonoBehaviour
    {

        public CameraState State;
        private Vector3 _focusPoint;
        private float _distance = 10;

        private void LateUpdate()
        {
            if (State?.target == null) return;
            var tm = Time.deltaTime * State.speed;

            transform.rotation = Quaternion.Lerp(transform.rotation,State.rotationOffset,tm);
            _focusPoint = Vector3.Lerp(_focusPoint, State.target.position + State.positionOffset, tm);
            _distance = Mathf.Lerp(_distance, State.distance,tm);
            transform.position  = _focusPoint - transform.forward * _distance; 
        }
    }
