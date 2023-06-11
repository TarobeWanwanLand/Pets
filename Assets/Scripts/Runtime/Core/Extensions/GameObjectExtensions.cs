using UnityEngine;

namespace Pets.Core.Runtime.Core.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// ゲームオブジェクトがプレハブかどうかを判定する
        /// </summary>
        /// <param name="gameObject">判定するゲームオブジェクト</param>
        /// <returns>プレハブであれば真</returns>
        public static bool IsPrefab(this GameObject gameObject)
        {
            return gameObject.scene == default;
        }
    }
}