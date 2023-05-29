using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Pets.Core.Math
{
    public static partial class Math
    {
        #region Comparison

        /// <summary>
        /// 指定された値が近しいかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <param name="other">比較する値</param>
        /// <param name="tolerance">許容誤差</param>
        /// <returns>値が近しいかどうか</returns>
        public static bool IsNearlyEqual(float value, float other, float tolerance = Epsilon * 8f) =>
            MathF.Abs(value - other) < Max(0.000001f * Max(Abs(value), Abs(other)), tolerance);

        /// <summary>
        /// 指定された値がゼロに近いかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <param name="tolerance">許容誤差</param>
        /// <returns>値がゼロに近いかどうか</returns>
        public static bool IsNearlyZero(this float value, float tolerance = Epsilon * 8f) =>
            IsNearlyEqual(value, 0f, tolerance);
        
        /// <summary>
        /// 指定された値が指定された範囲内にあるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns>値が指定された範囲内にあるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsWithin(this float value, float min, float max) => min <= value && value <= max;
        
        /// <summary>
        /// 指定された値が指定された範囲内にあるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <param name="length">範囲の長さ</param>
        /// <returns>値が指定された範囲内にあるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsWithin(this float value, float length) => IsWithin(value, 0f, length);
        
        /// <summary>
        /// 指定された値が指定された範囲内にあるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <param name="length">範囲の長さ</param>
        /// <returns>値が指定された範囲内にあるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsWithinAbs(this float value, float length) => IsWithin(value, -length, length);

        /// <summary>
        /// 指定された値が数値であるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <returns>値が数値であるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsNumber(this float value) => !float.IsNaN(value) && !float.IsInfinity(value);
        
        /// <summary>
        /// 指定された値が有限の数値であるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <returns>値が有限の数値であるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsFinite(this float value) => float.IsFinite(value);
        
        /// <summary>
        /// 指定された値が無限の数値であるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <returns>値が無限の数値であるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsInfinity(this float value) => float.IsInfinity(value);
        
        /// <summary>
        /// 指定された値が非数値であるかどうかを判定します
        /// </summary>
        /// <param name="value">判定する値</param>
        /// <returns>値が非数値であるかどうか</returns>
        [MethodImpl(Inline)]
        public static bool IsNaN(this float value) => float.IsNaN(value);

        #endregion Comparison
        #region Root

        /// <summary>
        /// 指定された値の平方根を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>平方根の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Sqrt(float value) => MathF.Sqrt(value);
        
        /// <summary>
        /// 指定された値の立方根を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>立方根の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Cbrt(float value) => MathF.Cbrt(value);
        
        /// <summary>
        /// 指定された値の塁根を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <param name="n">塁数</param>
        /// <returns>塁根の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Root(float value, float n) => Pow(value, 1f / n);
        
        #endregion Root
        #region Power

        /// <summary>
        /// 指定された値の累乗を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <param name="n">累乗</param>
        /// <returns>累乗の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Pow(float value, float n) => MathF.Pow(value, n);

        #endregion Power
        #region Logarithmic and Exponential
        
        /// <summary>
        /// 指定された値の自然対数を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>自然対数の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Log(float value) => MathF.Log(value);
        
        /// <summary>
        /// 指定された値の常用対数を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>常用対数の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Log10(float value) => MathF.Log10(value);
        
        /// <summary>
        /// 指定された値の底の対数を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <param name="n">底</param>
        /// <returns>底の対数の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Log(float value, float n) => MathF.Log(value, n);

        /// <summary>
        /// 指定された値の自然指数関数を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>自然指数関数の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Exp(float value) => MathF.Exp(value);

        #endregion Logarithmic and Exponential
        #region Trigonometric
        
        /// <summary>
        /// 指定された値の正弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>正弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Sin(float value) => MathF.Sin(value);
        
        /// <summary>
        /// 指定された値の余弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>余弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Cos(float value) => MathF.Cos(value);
        
        /// <summary>
        /// 指定された値の正接を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>正接の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Tan(float value) => MathF.Tan(value);
        
        /// <summary>
        /// 指定された値の逆正弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>逆正弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Asin(float value) => MathF.Asin(value);
        
        /// <summary>
        /// 指定された値の逆余弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>逆余弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Acos(float value) => MathF.Acos(value);
        
        /// <summary>
        /// 指定された値の逆正接を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>逆正接の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Atan(float value) => MathF.Atan(value);
        
        /// <summary>
        /// 指定された値の逆正接を計算します
        /// </summary>
        /// <param name="y">y座標</param>
        /// <param name="x">x座標</param>
        /// <returns>逆正接の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Atan2(float y, float x) => MathF.Atan2(y, x);

        #endregion Trigonometric
        #region Hyperbolic
        
        /// <summary>
        /// 指定された値の双曲線正弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>双曲線正弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Sinh(float value) => MathF.Sinh(value);
        
        /// <summary>
        /// 指定された値の双曲線余弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>双曲線余弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Cosh(float value) => MathF.Cosh(value);
        
        /// <summary>
        /// 指定された値の双曲線正接を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>双曲線正接の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Tanh(float value) => MathF.Tanh(value);
        
        /// <summary>
        /// 指定された値の逆双曲線正弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>逆双曲線正弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Asinh(float value) => MathF.Asinh(value);
        
        /// <summary>
        /// 指定された値の逆双曲線余弦を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>逆双曲線余弦の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Acosh(float value) => MathF.Acosh(value);
        
        /// <summary>
        /// 指定された値の逆双曲線正接を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>逆双曲線正接の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Atanh(float value) => MathF.Atanh(value);
        
        #endregion Hyperbolic
        #region Sign
        
        /// <summary>
        /// 指定された値の絶対値を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>絶対値の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Abs(float value) => MathF.Abs(value);
        
        /// <summary>
        /// 指定された値の符号を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>符号の計算結果</returns>
        [MethodImpl(Inline)]
        public static float Sign(float value) => MathF.Sign(value);

        /// <summary>
        /// 指定された値の符号を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <param name="tolerance">0とみなす閾値</param>
        /// <returns>符号の計算結果</returns>
        [MethodImpl(Inline)]
        public static int SignAsInt(float value, float tolerance = Epsilon * 8f) =>
            IsNearlyZero(value, tolerance) ? 0 : value < 0f ? -1 : 1;
        
        #endregion Sign
        #region Rounding
        
        /// <summary>
        /// 指定された値の小数部を切り捨てます
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り捨て結果</returns>
        [MethodImpl(Inline)]
        public static float Floor(float value) => MathF.Floor(value);
        
        /// <summary>
        /// 指定された値の小数部を切り捨てた結果を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り捨て結果</returns>
        [MethodImpl(Inline)]
        public static int FloorToInt(float value) => (int)Floor(value);
        
        /// <summary>
        /// 指定された値の小数部を切り上げます
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り上げ結果</returns>
        [MethodImpl(Inline)]
        public static float Ceiling(float value) => MathF.Ceiling(value);
        
        /// <summary>
        /// 指定された値の小数部を切り上げた結果を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り上げ結果</returns>
        [MethodImpl(Inline)]
        public static int CeilingToInt(float value) => (int)Ceiling(value);

        /// <summary>
        /// 指定された値の小数部を切り捨てた結果を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り捨て結果</returns>
        [MethodImpl(Inline)]
        public static float Truncate(float value) => MathF.Truncate(value);
        
        /// <summary>
        /// 指定された値の小数部を切り捨てた結果を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り捨て結果</returns>
        [MethodImpl(Inline)]
        public static int TruncateToInt(float value) => (int)Truncate(value);
        
        /// <summary>
        /// 指定された値の小数部を切り捨てた結果を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り捨て結果</returns>
        [MethodImpl(Inline)]
        public static float Round(float value) => MathF.Round(value);
        
        /// <summary>
        /// 指定された値の小数部を切り捨てた結果を計算します
        /// </summary>
        /// <param name="value">計算する値</param>
        /// <returns>小数部の切り捨て結果</returns>
        [MethodImpl(Inline)]
        public static int RoundToInt(float value) => (int)Round(value);
        
        #endregion Rounding
        #region Clamping
        
        /// <summary>
        /// 指定された値を [min, max] の範囲内に丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="min">丸められる値の下限</param>
        /// <param name="max">丸められる値の上限</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float Clamp(float value, float min, float max) => 
            value < min ? min : value > max ? max : value;

        /// <summary>
        /// 指定された値を [0, length] の範囲に丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="length">丸められる値の上限</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float Clamp(float value, float length) => Clamp(value, 0.0f, length);
        
        /// <summary>
        /// 指定された値を [0, 1] の範囲に丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float Clamp(float value) => Clamp(value, 0.0f, 1.0f);

        /// <summary>
        /// 指定された値を [-length, length] の範囲に丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="length">丸められる値の上限の絶対値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float ClampAbs(float value, float length) => Clamp(value, -length, length);
        
        /// <summary>
        /// 指定された値を [-1, 1] の範囲に丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float ClampAbs(float value) => Clamp(value, -1.0f, 1.0f);
        
        #endregion Clamping
        #region Repeating
        
        /// <summary>
        /// 指定された値の小数点以下の部分を返します
        /// </summary>
        /// <param name="value">小数点以下の部分を取得する値</param>
        /// <returns>小数点以下の部分の値</returns>
        [MethodImpl(Inline)] 
        public static float Frac(float value) => value - Floor( value );
        
        /// <summary>
        /// 指定された値を割った余りを返します
        /// </summary>
        /// <param name="value">剰余を求める値</param>
        /// <param name="length">剰余を求めるときに使用する値</param>
        /// <returns>剰余の値</returns>
        [MethodImpl(Inline)] 
        public static float Mod(float value, float length) => value - Floor( value / length ) * length;
        
        /// <summary>
        /// 指定された値を [min, max] の範囲内に繰り返すように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="min">丸められる値の下限</param>
        /// <param name="max">丸められる値の上限</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float Repeat(float value, float min, float max) =>
            value - MathF.Floor(value / (max - min)) * (max - min);

        /// <summary>
        /// 指定された値を [0, length] の範囲に繰り返すように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="length">丸められる値の範囲</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float Repeat(float value, float length) => Repeat(value, 0.0f, length);
        
        /// <summary>
        /// 指定された値を [0, 1] の範囲に繰り返すように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float Repeat(float value) => Repeat(value, 0.0f, 1.0f);
        
        /// <summary>
        /// 指定された値を [-length, length] の範囲に繰り返すように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="length">丸められる値の範囲の絶対値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float RepeatAbs(float value, float length) => Repeat(value, -length, length);
        
        /// <summary>
        /// 指定された値を [-1, 1] の範囲に繰り返すように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float RepeatAbs(float value) => Repeat(value, -1.0f, 1.0f);
        
        /// <summary>
        /// 指定された値を [min, max] の範囲内にピンポンするように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="min">丸められる値の下限</param>
        /// <param name="max">丸められる値の上限</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float PingPong(float value, float min, float max) =>
            max - MathF.Abs((max - value) % (2.0f * (max - min)) - (max - min));
        
        /// <summary>
        /// 指定された値を [0, length] の範囲にピンポンするように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="length">丸められる値の範囲</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float PingPong(float value, float length) => PingPong(value, 0.0f, length);
        
        /// <summary>
        /// 指定された値を [0, 1] の範囲にピンポンするように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float PingPong(float value) => PingPong(value, 0.0f, 1.0f);

        /// <summary>
        /// 指定された値を [-length, length] の範囲にピンポンするように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <param name="length">丸められる値の範囲の絶対値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float PingPongAbs(float value, float length) => PingPong(value, -length, length);

        /// <summary>
        /// 指定された値を [-1, 1] の範囲にピンポンするように丸めます
        /// </summary>
        /// <param name="value">丸められる値</param>
        /// <returns>丸められた値</returns>
        [MethodImpl(Inline)]
        public static float PingPongAbs(float value) => PingPong(value, -1.0f, 1.0f);

        #endregion Repeating
        #region Select
        
        /// <summary>
        /// 指定された2つの値のうち小さい方の値を計算します
        /// </summary>
        /// <param name="a">計算する値</param>
        /// <param name="b">計算する値</param>
        /// <returns>小さい方の値</returns>
        [MethodImpl(Inline)]
        public static float Min(float a, float b) => MathF.Min(a, b);

        /// <summary>
        /// 指定された値のうち最も小さい値を計算します
        /// </summary>
        /// <param name="values">計算する値</param>
        /// <returns>最も小さい値</returns>
        [MethodImpl(Inline)]
        public static float Min(params float[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("配列の長さは1以上である必要があります", nameof(values));
            return values.Min();
        }
        
        /// <summary>
        /// 指定された2つの値のうち大きい方の値を計算します
        /// </summary>
        /// <param name="a">計算する値</param>
        /// <param name="b">計算する値</param>
        /// <returns>大きい方の値</returns>
        [MethodImpl(Inline)]
        public static float Max(float a, float b) => MathF.Max(a, b);

        /// <summary>
        /// 指定された値のうち最も大きい値を計算します
        /// </summary>
        /// <param name="values">計算する値</param>
        /// <returns>最も大きい値</returns>
        [MethodImpl(Inline)]
        public static float Max(params float[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("配列の長さは1以上である必要があります", nameof(values));
            return values.Max();
        }

        /// <summary>
        /// 指定された3つの値のうち中央の値を計算します
        /// </summary>
        /// <param name="a">計算する値</param>
        /// <param name="b">計算する値</param>
        /// <param name="c">計算する値</param>
        /// <returns>中央の値</returns>
        [MethodImpl(Inline)]
        public static float Median(float a, float b, float c) => 
            a < b ? b < c ? b : a < c ? c : a : c < b ? b : c < a ? c : a;

        /// <summary>
        /// 指定された値のうち中央の値を計算します
        /// </summary>
        /// <param name="values">計算する値</param>
        /// <returns>中央の値</returns>
        [MethodImpl(Inline)]
        public static float Median(params float[] values)
        {
            var length = values.Length;
            switch (length)
            {
                case 0: throw new ArgumentException("配列の長さは1以上である必要があります", nameof(values));
                case 1: return values[0];
                case 2: return (values[0] + values[1]) / 2f;
                default:
                {
                    var sorted = new float[length];
                    Array.Copy(values, sorted, length);
                    Array.Sort(sorted);
                    var midIndex = length / 2;
                    return (length ^ 1) == 0
                        ? sorted[midIndex]
                        : (sorted[midIndex - 1] + sorted[midIndex]) / 2f;
                }
            }
        }

        #endregion Select
        #region Interpolation
        
        /// <summary>
        /// 線形補間を計算します
        /// </summary>
        /// <param name="a">補間する値</param>
        /// <param name="b">補間する値</param>
        /// <param name="t">補間する値</param>
        /// <returns>補間された値</returns>
        [MethodImpl(Inline)]
        public static float Lerp(float a, float b, float t) => a + (b - a) * t;

        /// <summary>
        /// 角度の線形補間を計算します
        /// </summary>
        /// <param name="a">補間する角度</param>
        /// <param name="b">補間する角度</param>
        /// <param name="t">補間する値</param>
        /// <returns>補間された角度</returns>
        [MethodImpl(Inline)]
        public static float LerpAngle(float a, float b, float t)
        {
            var delta = RepeatAbs(b - a, 180f);
            return a + delta * Clamp(t);
        }

        #endregion Interpolation
        #region Remapping
        
        /// <summary>
        /// 指定された値を指定された範囲に再マッピングします
        /// </summary>
        /// <param name="value">再マッピングする値</param>
        /// <param name="iMin">入力の最小値</param>
        /// <param name="iMax">入力の最大値</param>
        /// <param name="oMin">出力の最小値</param>
        /// <param name="oMax">出力の最大値</param>
        /// <returns>再マッピングされた値</returns>
        [MethodImpl(Inline)]
        public static float Remap(float value, float iMin, float iMax, float oMin, float oMax) => 
            oMin + (value - iMin) * (oMax - oMin) / (iMax - iMin);

        #endregion Remapping
    }
}