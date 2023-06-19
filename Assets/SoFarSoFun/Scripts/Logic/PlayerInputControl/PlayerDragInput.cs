using UnityEngine;

namespace Logic.PlayerInputControl
{
    public class PlayerDragInput : MonoBehaviour
    {
        [SerializeField] private float _sensativity = 1;
        private Vector3 _lastMousePosition;

        public Vector3 Delta { get; private set; }

        private bool IsBeginDrag => Input.GetMouseButtonDown(0);

        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;

            if (IsBeginDrag)
                _lastMousePosition = mousePosition;

            Delta = (RefreshDelta(mousePosition) / Screen.width) * _sensativity;

            _lastMousePosition = mousePosition;
        }

        private Vector3 RefreshDelta(Vector3 mousePosition) =>
            Input.GetMouseButton(0)
                ? mousePosition - _lastMousePosition
                : Vector3.zero;
    }
}