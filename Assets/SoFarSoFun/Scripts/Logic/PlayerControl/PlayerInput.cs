using System;
using UnityEngine;

namespace Logic.PlayerControl
{

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float _delta = 0.1f;
        
        private Vector3 _startPos;

        public event Action<Vector3> Clicked;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if ((Input.mousePosition - _startPos).magnitude < _delta)
                {
                    Clicked?.Invoke(Input.mousePosition);
                }
            }
        }

    }

}