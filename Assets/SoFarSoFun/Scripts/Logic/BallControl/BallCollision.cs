using System.Linq;

namespace Logic.Collisions
{

    public class BallCollision
    {
        private int[] _collisionIds;

        private int ItsBallId { get; }
        private int HitBallId { get; }

        public BallCollision(int itsBallId, int hitBallId)
        {
            ItsBallId = itsBallId;
            HitBallId = hitBallId;
            _collisionIds = new[] { itsBallId, hitBallId };
        }

        public bool IsEqual(BallCollision ballCollision) => 
            _collisionIds.Contains(ballCollision.ItsBallId) && _collisionIds.Contains(ballCollision.HitBallId);
    }

}