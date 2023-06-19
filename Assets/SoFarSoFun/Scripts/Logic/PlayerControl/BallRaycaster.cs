using System;
using Extensions;
using Logic.BallControl;
using UnityEngine;

namespace Logic.PlayerControl
{

    public class BallRaycaster : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        
        private Camera _castCamera;
        private bool _initialized;
        
        private int LayerMask => 1 << 9;

        public void Initialize()
        {
            _castCamera = Camera.main;
            _initialized = true;
        }
        
        private void Start()
        {
            _playerInput.Clicked += OnClicked;
        }

        private void OnDestroy()
        {
            _playerInput.Clicked -= OnClicked;
        }

        private void OnClicked(Vector3 clickPosition)
        {
            if (!_initialized)
                throw new InvalidOperationException("BallPusher not initialized");

            Ray screenPointToRay = _castCamera.ScreenPointToRay(clickPosition);
            if (Physics.Raycast(screenPointToRay, out RaycastHit hit, 50, LayerMask))
            {
                if (hit.collider.TryGetComponent(out BallPusher ballPusher))
                {
                    ballPusher.PushTo(_castCamera.gameObject.transform.forward.normalized.SetY(0));
                }
            }
        }
    }

}