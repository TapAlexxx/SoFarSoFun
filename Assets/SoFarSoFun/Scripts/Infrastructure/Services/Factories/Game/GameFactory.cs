using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Infrastructure.Services.ColorService;
using Infrastructure.Services.StaticData;
using Logic.BallControl;
using Logic.PlayerControl;
using StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Infrastructure.Services.Factories.Game
{
    public class GameFactory : Factory, IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IColorService _colorService;
        
        private List<GameObject> _balls;
        private ICoroutineRunner _coroutineRunner;
        public GameObject Player { get; private set; }
        public GameObject GameHud { get; private set; }



        public GameFactory(IInstantiator instantiator, IStaticDataService staticDataService
            , IColorService colorService, ICoroutineRunner coroutineRunner) : base(instantiator)
        {
            _coroutineRunner = coroutineRunner;
            _colorService = colorService;
            _staticDataService = staticDataService;
        }

        public GameObject CreateHud()
        {
            GameHud = InstantiateOnActiveScene("Hud/Hud");
            return GameHud;
        }

        public GameObject CreatePlayer()
        {
            LevelStaticData levelStaticData = _staticDataService.GetLevelStaticData();
            GameObject player = InstantiatePrefabOnActiveScene(levelStaticData.Player);
            player.GetComponentInChildren<BallRaycaster>().Initialize();
            Player = player;
            return Player;
        }

        public void CreateBalls(Action onBallsCreated)
        {
            LevelStaticData levelData = _staticDataService.GetLevelStaticData();
            _coroutineRunner.StartCoroutine(StartCreateBalls(levelData, onBallsCreated));
        }

        private IEnumerator StartCreateBalls(LevelStaticData levelData, Action onBallsCreated)
        {
            for (int i = 0; i < levelData.BallCount; i++)
            {
                if (TrySetupBall(levelData, i, out GameObject ball))
                {
                    _balls.Add(ball);
                }
                else
                {
                    i--;
                }

                yield return new WaitForEndOfFrame();
            }
            onBallsCreated?.Invoke();
        }

        private bool TrySetupBall(LevelStaticData levelData, int i, out GameObject ballGameObject)
        {
            ballGameObject = null;
            if (TryGetRandomPosition(levelData.BallSpawnRadius, out Vector3 targetPosition))
            {
                ballGameObject = InstantiatePrefabOnActiveScene(levelData.Ball);
                Ball ball = ballGameObject.GetComponentInChildren<Ball>();
                BallPusher ballPusher = ballGameObject.GetComponentInChildren<BallPusher>();

                ball.Initialize(i, _colorService.GetRandomColor());
                ballPusher.Initialize(levelData.ClickPower);

                ball.transform.position = targetPosition;
            }
            return ballGameObject != null;
        }

        private bool TryGetRandomPosition(float ballSpawnRadius, out Vector3 targetPosition)
        {
            targetPosition = new Vector3(0, -10,0);
            Vector2 randomXZ = Random.insideUnitCircle * ballSpawnRadius;
            targetPosition = new Vector3(randomXZ.x, 1.5f, randomXZ.y);

            Collider[] colliders = Physics.OverlapSphere(targetPosition, 2.5f, 1<<9);

            if (colliders.Length == 0)
            {
                return true;
            }
            
            targetPosition = new Vector3(0, -10,0);
            Debug.Log(targetPosition);
            return false;
        }

        public void Clear()
        {
            Player = null;
            GameHud = null;
            _balls = new List<GameObject>();
        }
    }
}