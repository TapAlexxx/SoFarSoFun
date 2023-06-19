using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Collisions;

namespace Infrastructure.Services.CollisionRegistration
{

    public class CollisionRegistrationService : ICollisionRegistrationService
    {
        private List<BallCollision> _ballCollisions = new List<BallCollision>();
        
        public event Action BallCollisionRegistered;
        public event Action WallCollisionRegistered;
        
        public void TryRegisterBallCollision(BallCollision ballCollision)
        {
            BallCollision equalCollision = _ballCollisions.FirstOrDefault(x => x.IsEqual(ballCollision));
            
            if (equalCollision == null)
            {
                _ballCollisions.Add(ballCollision);
                BallCollisionRegistered?.Invoke();
            }
            else
            {
                _ballCollisions.Remove(equalCollision);
            }
        }

        public void RegisterWallCollision()
        {
            WallCollisionRegistered?.Invoke();
        }
    }

}