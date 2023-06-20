using System.Linq;

namespace Logic.BallControl
{

    public class BallCollision
    {
        private readonly int[] _collisionIds;
        public Ball ItsBall { get; }
        public Ball HitBall { get; }

        public int ItsBallId { get; }
        public int HitBallId { get; }

        public BallCollision(int itsBallId, int hitBallId, Ball itsBall, Ball hitBall)
        {
            ItsBallId = itsBallId;
            HitBallId = hitBallId;
            
            _collisionIds = new[] { itsBallId, hitBallId };
            
            HitBall = hitBall;
            ItsBall = itsBall;
        }

        public bool IsEqualId(BallCollision ballCollision) => 
            _collisionIds.Contains(ballCollision.ItsBallId) && _collisionIds.Contains(ballCollision.HitBallId);
    }

}