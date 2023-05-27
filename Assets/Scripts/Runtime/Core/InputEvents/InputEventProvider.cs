using UnityEngine;

namespace Pets.Core.InputEvents
{
    public static class InputEvent
    {
        public static Pointer Pointer { get; private set; }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#endif
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Pointer = new();
        }
    }
}