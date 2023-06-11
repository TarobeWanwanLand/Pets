namespace Pets.Core.Helpers
{
    /// <summary>
    /// アプリケーションのヘルパークラス
    /// </summary>
    public static class ApplicationHelper
    {
        /// <summary>
        /// アプリケーションを終了する
        /// </summary>
        /// <remarks>エディタ上ではプレイモードを終了する</remarks>
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}