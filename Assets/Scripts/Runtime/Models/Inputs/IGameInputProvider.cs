using Unity.Mathematics;

namespace Pets.Models.Inputs
{
    /// <summary>
    /// ゲーム入力を提供するインターフェース
    /// </summary>
    public interface IGameInputProvider
    {
        /// <summary>
        /// 移動入力
        /// </summary>
        float2 Move { get; }
    }
}