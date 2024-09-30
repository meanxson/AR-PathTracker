using UnityEngine;
using Zenject;

namespace Client
{
    public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
    {
        [SerializeField] private GameSession _gameSession;

        public override void InstallBindings()
        {
            Container.Bind<GameSession>().FromInstance(_gameSession).AsSingle().NonLazy();
        }
    }
}