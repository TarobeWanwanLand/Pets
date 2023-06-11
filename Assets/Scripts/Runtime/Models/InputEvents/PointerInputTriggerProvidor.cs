using System;
using Pets.Views;
using UniRx;
using UniRx.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pets.Core.InputEvents
{
    public readonly struct PointerPressEvent
    {
        public Vector2 Position { get; }
        public TimeSpan Duration { get; }
        
        internal PointerPressEvent(Vector2 position, TimeSpan duration)
        {
            Position = position;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{{{nameof(Position)}: {Position.ToString()}, {nameof(Duration)}: {Duration.ToString()}}}";
        }
    }

    public sealed class PointerInputEventProvider : DisposableModel, IPointerInputEventProvider
    {
        private IConnectableObservable<PointerPressEvent> _onPress;
        private IConnectableObservable<PointerPressEvent> _onRelease;
        private IConnectableObservable<PointerPressEvent> _onMultiPress;
        private IConnectableObservable<PointerPressEvent> _onHoldPress;
        private IConnectableObservable<Vector2> _onPositionChange;
        private IConnectableObservable<Vector2> _onMove;

        public IObservable<PointerPressEvent> OnPressAsObservable()
        {
            if (_onPress == null)
            {
                _onPress = GetPressEventObservable()
                    .Where(ctx => ctx.ReadValueAsButton())
                    .WithLatestFrom(OnPositionChangeAsObservable(),
                        (_, pos) => new PointerPressEvent(pos, TimeSpan.Zero))
                    .Publish();
                _onPress.Connect()
                    .AddTo(this);
            }
            return _onPress;
        }

        public IObservable<PointerPressEvent> OnReleaseAsObservable()
        {
            if (_onRelease == null)
            {
                _onRelease = GetPressEventObservable()
                    .Where(ctx => !ctx.ReadValueAsButton())
                    .WithLatestFrom(OnPositionChangeAsObservable(),
                        (ctx, pos) => new PointerPressEvent(pos, TimeSpan.FromSeconds(ctx.duration)))
                    .Publish();
                _onRelease.Connect()
                    .AddTo(this);
            }
            return _onRelease;
        }
        
        public IObservable<PointerPressEvent> OnDoublePressAsObservable()
        {
            if (_onMultiPress == null)
            {
                var delayTime = TimeSpan.FromSeconds(InputSystem.settings.multiTapDelayTime);
                
                _onMultiPress = GetPressEventObservable()
                    .Where(ctx => ctx.ReadValueAsButton())
                    .TimeInterval()
                    .Pairwise((prev, curt) => (Previous: prev.Interval, Current: curt.Interval))
                    .Where(intervals => intervals.Previous > delayTime && intervals.Current <= delayTime)
                    .WithLatestFrom(OnPositionChangeAsObservable(),
                        (intervals, pos) => new PointerPressEvent(pos, intervals.Current))
                    .Publish();
                _onMultiPress.Connect()
                    .AddTo(this);
            }
            return _onMultiPress;
        }

        public IObservable<PointerPressEvent> OnHoldPressAsObservable()
        {
            if (_onHoldPress == null)
            {
                var holdTime = TimeSpan.FromSeconds(InputSystem.settings.defaultHoldTime);
                
                _onHoldPress = GetPressEventObservable()
                    .Where(ctx => ctx.ReadValueAsButton())
                    .SelectMany(_ => Observable.ReturnUnit()
                        .Delay(holdTime)
                        .TakeUntil(GetPressEventObservable()))
                    .WithLatestFrom(OnPositionChangeAsObservable(), (_, pos) => new PointerPressEvent(pos, holdTime))
                    .Publish();
                _onHoldPress.Connect()
                    .AddTo(this);
            }
            return _onHoldPress;
        }

        public IObservable<Vector2> OnPositionChangeAsObservable()
        {
            if (_onPositionChange == null)
            {
                _onPositionChange = GetPositionEventObservable()
                    .Select(ctx => ctx.ReadValue<Vector2>())
                    .Publish();
                _onPositionChange.Connect()
                    .AddTo(this);
            }
            return _onPositionChange;
        }

        public IObservable<Vector2> OnMoveAsObservable()
        {
            if (_onMove == null)
            {
                _onMove = GetMoveEventObservable()
                    .Select(ctx => ctx.ReadValue<Vector2>())
                    .Publish();
                _onMove.Connect()
                    .AddTo(this);
            }
            return _onMove;
        }
        
        private IObservable<InputAction.CallbackContext> GetPressEventObservable()
        {
            var action = new InputAction("Press", InputActionType.PassThrough, binding: "<Pointer>/press")
                .AddTo(this);
            action.Enable();

            return Observable.FromEvent<InputAction.CallbackContext>(
                h => action.performed += h,
                h => action.performed -= h);
        }

        private IObservable<InputAction.CallbackContext> GetPositionEventObservable()
        {
            var action = new InputAction("Position", binding: "<Pointer>/position")
                .AddTo(this);
            action.Enable();

            return Observable.FromEvent<InputAction.CallbackContext>(
                h => action.performed += h,
                h => action.performed -= h);
        }

        private IObservable<InputAction.CallbackContext> GetMoveEventObservable()
        {
            var action = new InputAction("Delta", binding: "<Pointer>/delta")
                .AddTo(this);
            action.Enable();

            return Observable.FromEvent<InputAction.CallbackContext>(
                h => action.performed += h,
                h => action.performed -= h);
        }
    }
}