using System;
using Logic.BallControl;
using Logic.Collisions;

namespace Infrastructure.Services.CollisionRegistration
{

    public interface ICollisionRegistrationService
    {
        event Action<BallCollision> BallCollisionRegistered;
        event Action<Wall> WallCollisionRegistered;

        void TryRegisterBallCollision(BallCollision ballCollision);
        void RegisterWallCollision(Wall wall);

        void Clear();
    }

}