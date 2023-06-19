using System;
using Logic.PlayerInputControl;
using UnityEngine;

namespace Logic.PlayerControl
{

    public class PlayerCameraControl : MonoBehaviour
    {
        [SerializeField] private PlayerDragInput _playerDragInput;

        private void OnValidate()
        {
            if (!_playerDragInput) TryGetComponent(out _playerDragInput);
        }

        public void Initialize(CameraRotator cameraRotator)
        {
            cameraRotator.Rotate(_playerDragInput.Delta.x);
        }
    }

}