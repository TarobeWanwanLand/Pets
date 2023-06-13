using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using VContainer;
using VContainer.Unity;

namespace Pets.Scopes
{
    public abstract class Scope : LifetimeScope
    {
        private CancellationToken _cancellationToken;
        
        protected abstract void ConfigureServices(IContainerBuilder builder);
        
        [UsedImplicitly]
        private new async UniTaskVoid Awake()
        {
            _cancellationToken = this.GetCancellationTokenOnDestroy();
        }
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_cancellationToken);
            ConfigureServices(builder);
        }
    }
}