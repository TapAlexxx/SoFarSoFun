using UnityEngine;

namespace Logic.CameraControl
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private Transform _carTransform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _xDamping;
        [SerializeField] private float _yDamping;
        [SerializeField] private float _zDamping;

        private void Start() =>
            transform.parent = null;

        private void FixedUpdate()
        {
            Vector3 rbPos = _rigidbody.position;
            rbPos.x = Mathf.Lerp(rbPos.x, _carTransform.position.x, _xDamping * Time.fixedDeltaTime);
            rbPos.y = Mathf.Lerp(rbPos.y, _carTransform.position.y, _yDamping * Time.fixedDeltaTime);
            rbPos.z = Mathf.Lerp(rbPos.z, _carTransform.position.z, _zDamping * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(_carTransform.rotation);
            _rigidbody.MovePosition(rbPos);
        }
    }
}