using UnityEngine;

namespace Infrastructure.Services.Factories.Game
{
    public interface IGameFactory
    {
        GameObject Player { get; }
        GameObject GameHud { get; }
        GameObject CreateHud();
        GameObject CreatePlayer();
        void Clear();
    }
}