using System;
using UniRx;
using UnityEngine.InputSystem;

namespace Pets.Core.Extensions
{
    public static class InputActionExtensions
    {
        public static IObservable<InputAction.CallbackContext> OnStartedAsObservable(this InputAction self)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => self.started += h,
                h => self.started -= h);
        }
        
        public static IObservable<InputAction.CallbackContext> OnCanceledAsObservable(this InputAction self)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => self.canceled += h,
                h => self.canceled -= h);
        }
        
        public static IObservable<InputAction.CallbackContext> OnPerformedAsObservable(this InputAction self)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => self.performed += h,
                h => self.performed -= h);
        }
    }
}