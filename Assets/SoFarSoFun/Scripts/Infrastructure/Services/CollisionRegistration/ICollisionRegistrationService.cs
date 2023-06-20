using System;
using Logic.BallControl;
using Logic.Collisions;
using Logic.WallControl;

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