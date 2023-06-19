using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories.Game
{
    public class GameFactory : Factory, IGameFactory
    {
        private IStaticDataService _staticDataService;
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

        public void Clear()
        {
            Player = null;
        }
    }
}