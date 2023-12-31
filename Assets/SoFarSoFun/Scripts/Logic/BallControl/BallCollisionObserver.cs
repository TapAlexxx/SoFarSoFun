﻿using Infrastructure.Services.CollisionRegistration;
using Logic.Collisions;
using Logic.WallControl;
using UnityEngine;
using Zenject;

namespace Logic.BallControl
{

    public class BallCollisionObserver : MonoBehaviour
    {
        [SerializeField] private CollisionObserver _collisionObserver;
        [SerializeField] private Ball _ball;
        [SerializeField] private BallAnimation _ballAnimation;
        
        private ICollisionRegistrationService _collisionRegistrationService;

        private void OnValidate()
        {
            if (!_collisionObserver) TryGetComponent(out _collisionObserver);
            if (!_ballAnimation) TryGetComponent(out _ballAnimation);
            if (!_ball) TryGetComponent(out _ball);
        }

        [Inject]
        public void Construct(ICollisionRegistrationService collisionRegistrationService)
        {
            _collisionRegistrationService = collisionRegistrationService;
        }

        private void Start()
        {
            _collisionObserver.ColliderEnter += OnCollision;
        }

        private void OnDestroy()
        {
            _collisionObserver.ColliderEnter -= OnCollision;
        }

        private void OnCollision(Collision obj)
        {
            if (obj.collider.TryGetComponent(out Ball hitBall))
            {
                BallCollision collision = new BallCollision(_ball.ID, hitBall.ID, _ball, hitBall);
                _collisionRegistrationService.TryRegisterBallCollision(collision);
                _ballAnimation.AnimateBallPop();
                _ballAnimation.AnimateBallCollision(obj.contacts[0].point, _ball.TargetColor);
            }

            if (obj.collider.TryGetComponent(out Wall wall))
            {
                _collisionRegistrationService.RegisterWallCollision(wall);
            }
        }
    }

}