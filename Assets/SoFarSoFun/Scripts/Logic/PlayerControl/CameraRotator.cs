using System;
using Cinemachine;
using Logic.PlayerInputControl;
using UnityEngine;

namespace Logic.PlayerControl
{

    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private CinemachineOrbitalTransposer _orbitalTransposer;
        private PlayerDragInput _playerDragInput;

        public void Initialize(PlayerDragInput playerDragInput)
        {
            _playerDragInput = playerDragInput;
        }
        
        private void Start()
        {
            _orbitalTransposer = _virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        }

        private void Update()
        {
            if(!_playerDragInput || !_playerDragInput.IsOnDrag)
                return;
            
            Rotate(_playerDragInput.Delta.x);
        }

        private void Rotate(float deltaX) => 
            _orbitalTransposer.m_XAxis.Value += deltaX;
    }

}