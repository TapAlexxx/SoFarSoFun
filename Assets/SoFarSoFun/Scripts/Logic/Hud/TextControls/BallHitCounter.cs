using System;
using System.Collections;
using Infrastructure.Services.CollisionRegistration;
using Logic.BallControl;
using Logic.WallControl;
using UnityEngine;
using Zenject;

namespace Logic.Hud.TextControls
{

    public class BallHitCounter : MonoBehaviour
    {
        public int BallHits { get; private set; }
        public int WallHits { get; private set;}
        public int CurrentCombo { get; private set; }

        private ICollisionRegistrationService _collisionRegistration;
        private float _comboTime;
        private float _elapsedTime;
        private bool _isOnCombo;
        private Coroutine _comboCoroutine;
        private int _maxCombo;

        public event Action BallHitsChanged;
        public event Action WallHitsChanged;
        public event Action ComboStarted;
        public event Action ComboEnded;

        [Inject]
        public void Construct(ICollisionRegistrationService collisionRegistration)
        {
            _collisionRegistration = collisionRegistration;
        }

        public void Initialize(float comboTime, int maxCombo)
        {
            _maxCombo = maxCombo;
            _comboTime = comboTime;
        }

        private void Start()
        {
            ResetCounter();
            _collisionRegistration.BallCollisionRegistered += OnBallCollision;
            _collisionRegistration.WallCollisionRegistered += OnWallCollision;
        }

        private void ResetCounter()
        {
            BallHits = 0;
            WallHits = 0;
            CurrentCombo = 0;
            
            BallHitsChanged?.Invoke();
            WallHitsChanged?.Invoke();
        }

        private void OnDestroy()
        {
            _collisionRegistration.BallCollisionRegistered -= OnBallCollision;
            _collisionRegistration.WallCollisionRegistered -= OnWallCollision;
        }

        private void OnBallCollision(BallCollision obj)
        {
            BallHits++;
            IncreaseCombo();
            
            if (!_isOnCombo && CurrentCombo >= 2)
            {
                StopComboIfExist();
                _comboCoroutine = StartCoroutine(StartCombo());
            }
            else
            {
                ResetComboTimer();
            }

            BallHitsChanged?.Invoke();
        }

        private void IncreaseCombo()
        {
            CurrentCombo = CurrentCombo + 1 > _maxCombo 
                ? CurrentCombo
                : CurrentCombo + 1;
        }

        private void ResetComboTimer()
        {
            _elapsedTime = 0;
        }

        private void StopComboIfExist()
        {
            if (_comboCoroutine != null)
            {
                StopCoroutine(_comboCoroutine);
                _comboCoroutine = null;
            }
        }

        private IEnumerator StartCombo()
        {
            _isOnCombo = true;
            _elapsedTime = 0f;
            ComboStarted?.Invoke();
            while (_elapsedTime < _comboTime)
            {
                _elapsedTime += Time.deltaTime;
                yield return null;
            }
            ComboEnded?.Invoke();
            CurrentCombo = 0;
            _isOnCombo = false;
        }


        private void OnWallCollision(Wall obj)
        {
            WallHits++;
            WallHitsChanged?.Invoke();
        }
    }

}