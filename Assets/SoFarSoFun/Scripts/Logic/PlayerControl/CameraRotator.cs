using Cinemachine;
using UnityEngine;

namespace Logic.PlayerControl
{

    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private CinemachineOrbitalTransposer _orbitalTransposer;
        
        private void Start()
        {
            _orbitalTransposer = _virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        }

        public void Rotate(float deltaX)
        {
            _orbitalTransposer.m_XAxis.Value += deltaX;
        }
    }

}