using Pets.Core.InputEvents;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Pets.Views
{
    public sealed class VehicleBuilderModel : DisposableModel, IInitializable
    {
        private IPointerInputEventProvider _pointerInputEventProvider;
        
        [Inject]
        public VehicleBuilderModel(IPointerInputEventProvider pointerInputEventProviderProvider)
        {
            _pointerInputEventProvider = pointerInputEventProviderProvider;
        }

        void IInitializable.Initialize()
        {
            _pointerInputEventProvider.OnMoveAsObservable()
                .Subscribe(OnMovePart)
                .AddTo(this);
        }

        private void OnMovePart(Vector2 delta)
        {
            
        }
    }
}
