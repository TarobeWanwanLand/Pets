using System;
using UnityEngine;

namespace Pets.Core.InputEvents
{
    public interface IPointerInputEventProvider
    {
        IObservable<PointerPressEvent> OnPressAsObservable();
        IObservable<PointerPressEvent> OnReleaseAsObservable();
        IObservable<PointerPressEvent> OnDoublePressAsObservable();
        IObservable<PointerPressEvent> OnHoldPressAsObservable();
        IObservable<Vector2> OnPositionChangeAsObservable();
        IObservable<Vector2> OnMoveAsObservable();
    }
}