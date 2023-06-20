using System;
using System.Collections.Generic;
using System.Linq;
using Logic.BallControl;
using Logic.Collisions;
using Logic.WallControl;
using UnityEngine;

namespace Infrastructure.Services.CollisionRegistration
{

    public class CollisionRegistrationService : ICollisionRegistrationService
    {
        private List<BallCollision> _ballCollisions = new List<BallCollision>();
        
        public event Action<BallCollision> BallCollisionRegistered;
        public event Action<Wall> WallCollisionRegistered;
        
        public void TryRegisterBallCollision(BallCollision ballCollision)
        {
            BallCollision equalCollision = _ballCollisions.FirstOrDefault(x => x.IsEqualId(ballCollision));
            
            if (equalCollision == null)
            {
                _ballCollisions.Add(ballCollision);
                BallCollisionRegistered?.Invoke(ballCollision);
            }
            else
            {
                _ballCollisions.Remove(equalCollision);
            }
        }

        public void RegisterWallCollision(Wall wall)
        {
            WallCollisionRegistered?.Invoke(wall);
        }

        public void Clear()
        {
            _ballCollisions = new List<BallCollision>();
        }
    }

}