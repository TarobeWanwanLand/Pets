using Pets.Core.Loggers.Handlers;
using Pets.Models.Inputs;
using Pets.Models.Players;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Logger = Pets.Core.Loggers.Logger;

namespace Pets.Scopes
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterPlayer(builder);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            var loggerHandler = new GameLoggerHandler();
            builder.RegisterInstance(new Logger(loggerHandler));
            
            builder.RegisterEntryPoint<GameInputProvider>()
                .As<IGameInputProvider>();
        }
        
        private void RegisterPlayer(IContainerBuilder builder)
        {
            var playerGameObject = new GameObject("Player");
            var playerTransform = playerGameObject.transform;

            builder.RegisterEntryPoint<PlayerMovement>()
                .WithParameter(playerTransform);
        }
    }
}