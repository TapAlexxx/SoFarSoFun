using System;
using UnityEngine;

namespace Logic.BallControl
{

    public class BallPusher : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        private float _force;

        public event Action BallPushed;

        private void OnValidate()
        {
            if (!_rigidbody) TryGetComponent(out _rigidbody);
        }

        public void Initialize(float force)
        {
            _force = force;
        }

        public void PushTo(Vector3 direction)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
            BallPushed?.Invoke();
        }
    }

}