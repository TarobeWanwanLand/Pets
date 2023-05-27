using UnityEditor;
using UnityEngine;

namespace Pets.Core.Helpers
{
    public static class ApplicationHelper
    {
        public static void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}