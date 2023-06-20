using System;
using System.Collections.Generic;
using Infrastructure.Services.CollisionRegistration;
using Infrastructure.Services.ColorService;
using Logic.BallControl;
using Logic.Collisions;
using Logic.WallControl;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Logic.PlayerControl
{

    public class ColorChangeControl : MonoBehaviour
    {
        private ICollisionRegistrationService _collisionRegistration;
        private IColorService _colorService;

        [Inject]
        public void Construct(ICollisionRegistrationService collisionRegistration, IColorService colorService)
        {
            _colorService = colorService;
            _collisionRegistration = collisionRegistration;
        }

        private void Start()
        {
            _collisionRegistration.BallCollisionRegistered += OnBallCollision;
            _collisionRegistration.WallCollisionRegistered += OnWallCollision;
        }

        private void OnDestroy()
        {
            if (_collisionRegistration == null)
                return;
            
            _collisionRegistration.BallCollisionRegistered -= OnBallCollision;
            _collisionRegistration.WallCollisionRegistered -= OnWallCollision;
        }

        private void OnBallCollision(BallCollision ballCollision)
        {
            if (ballCollision.ItsBall.TargetColor == ballCollision.HitBall.TargetColor)
            {
                IColorChangeable ball = GetRandomBall(ballCollision);
                ball.ChangeColor(_colorService.GetRandomColor(ball.TargetColor));
            }
            else
            {
                Color tmp = ballCollision.ItsBall.TargetColor; 
                ballCollision.ItsBall.ChangeColor(ballCollision.HitBall.TargetColor);
                ballCollision.HitBall.ChangeColor(tmp);
            }
        }

        private IColorChangeable GetRandomBall(BallCollision ballCollision)
        {
            List<Ball> balls = new List<Ball>();
            balls.Add(ballCollision.ItsBall);
            balls.Add(ballCollision.HitBall);
            return balls[Random.Range(0,balls.Count)];
        }

        private void OnWallCollision(Wall wall)
        {
            wall.ChangeColor(_colorService.GetRandomColor(wall.TargetColor));
        }
    }

}