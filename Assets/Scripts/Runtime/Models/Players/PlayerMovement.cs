using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Pets.Models.Inputs;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using VContainer.Unity;
using Logger = Pets.Core.Loggers.Logger;

namespace Pets.Models.Players
{
    public class PlayerMovement : IStartable, IDisposable
    {
        private readonly CompositeDisposable _disposables = new();
        
        private readonly Transform _transform;
        private readonly IGameInputProvider _gameInput;
        private readonly Logger _logger;

        public PlayerMovement(Transform transform, IGameInputProvider gameInput, Logger logger)
        {
            _transform = transform;
            _gameInput = gameInput;
            _logger = logger;
        }

        public void Start()
        {
            _logger.DebugLog("PlayerMovement.Start");
            
            Observable.EveryUpdate()
                .SubscribeWithState(this, (_, self) => self.Move(self._gameInput.Move))
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
        
        public void Move(float2 velocity)
        {
            _transform.position += new Vector3(velocity.x, 0, velocity.y);
        }
    }
}