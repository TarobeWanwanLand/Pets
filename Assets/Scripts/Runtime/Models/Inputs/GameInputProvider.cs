using System;
using Pets.Core.Extensions;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using VContainer.Unity;

namespace Pets.Models.Inputs
{
    /// <summary>
    /// 最新のゲーム入力を提供するクラス
    /// </summary>
    public class GameInputProvider : IGameInputProvider, IInitializable, IDisposable
    {
        // InputActionsAssetから生成したInputActions
        private readonly GameInputActions _gameInputActions = new();
        private readonly CompositeDisposable _disposables = new();
        
        /// <summary>
        /// 最新の移動入力
        /// </summary>
        public float2 Move { get; private set; }
        
        public void Initialize()
        {
            // InputActionsを有効化する
            _gameInputActions.AddTo(_disposables);
            _gameInputActions.Enable();

            // 入力トリガーを購読する
            _gameInputActions.Game.Move.OnPerformedAsObservable()
                .SubscribeWithState(this, (context, self) => self.Move = context.ReadValue<Vector2>())
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}