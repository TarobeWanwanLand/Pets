using System;
using UniRx;

namespace Pets.Views
{
    public abstract class DisposableModel : IDisposable
    {
        private readonly CompositeDisposable _disposables = new();

        void IDisposable.Dispose() => _disposables.Dispose();

        internal void AddDisposable(IDisposable item)
        {
            _disposables.Add(item);
        }
    }
    
    internal static class DisposableModelExtensions
    {
        public static TDisposable AddTo<TDisposable>(this TDisposable disposable, DisposableModel model)
            where TDisposable : IDisposable
        {
            model.AddDisposable((IDisposable)disposable);
            return disposable;
        }
    }
}