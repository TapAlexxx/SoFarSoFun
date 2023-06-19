using System;
using Logic.Collisions;

namespace Infrastructure.Services.CollisionRegistration
{

    public interface ICollisionRegistrationService
    {
        event Action BallCollisionRegistered;
        event Action WallCollisionRegistered;

        void TryRegisterBallCollision(BallCollision ballCollision);
        void RegisterWallCollision();
    }

}