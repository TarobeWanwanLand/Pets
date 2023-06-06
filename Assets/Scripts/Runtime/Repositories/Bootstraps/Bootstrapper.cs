using MessagePack.Resolvers;
using Pets.Entities.Generated.Resolvers;
using UnityEngine;

namespace Pets.Core.Bootstraps
{
    internal static class Bootstrapper
    {
        static bool _messagePackInitialized;

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#endif
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            InitializeMessagePack();
        }

        private static void InitializeMessagePack()
        {
            if (_messagePackInitialized) 
                return;
            
            // シリアライザの初期設定
            StaticCompositeResolver.Instance.Register(
                EntityResolver.Instance,
                StandardResolver.Instance,
                MessagePack.Unity.UnityResolver.Instance,
                MessagePack.Unity.Extension.UnityBlitWithPrimitiveArrayResolver.Instance
            );

            // 設定を構築
            var option = MessagePack.MessagePackSerializerOptions.Standard
                .WithResolver(StaticCompositeResolver.Instance);

            // 設定を適応
            MessagePack.MessagePackSerializer.DefaultOptions = option;
            
            _messagePackInitialized = true;
        }
    }
}