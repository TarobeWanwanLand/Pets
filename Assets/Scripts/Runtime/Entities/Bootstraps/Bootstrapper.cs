using MessagePack.Resolvers;
using UnityEngine;

namespace Pets.Core.Runtime.Core.Bootstraps
{
    internal static class Bootstrapper
    {
        static bool _serializerRegistered;

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
            if (_serializerRegistered) 
                return;
            
            // シリアライザの初期設定
            StaticCompositeResolver.Instance.Register(
                GeneratedResolver.Instance,
                StandardResolver.Instance,
                MessagePack.Unity.UnityResolver.Instance,
                MessagePack.Unity.Extension.UnityBlitWithPrimitiveArrayResolver.Instance
            );

            // 設定を構築
            var option = MessagePack.MessagePackSerializerOptions.Standard
                .WithResolver(StaticCompositeResolver.Instance);

            // 設定を適応
            MessagePack.MessagePackSerializer.DefaultOptions = option;
            
            _serializerRegistered = true;
        }
    }
}