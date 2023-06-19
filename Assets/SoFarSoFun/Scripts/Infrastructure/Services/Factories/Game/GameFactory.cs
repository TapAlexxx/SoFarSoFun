using Infrastructure.Services.StaticData;
using Logic.PlayerControl;
using StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories.Game
{
    public class GameFactory : Factory, IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        public GameObject Player { get; private set; }
        public GameObject GameHud { get; private set; }



        public GameFactory(IInstantiator instantiator, IStaticDataService staticDataService) : base(instantiator)
        {
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

        public void Clear()
        {
            Player = null;
            GameHud = null;
        }
    }
}