using System;
using System.Runtime.CompilerServices;

namespace Pets.Core.Math
{
    public static partial class Math
    {
        private const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        public const float Infinity = float.PositiveInfinity;
        public const float NegativeInfinity = float.NegativeInfinity;
        public const float MinValue = float.MinValue;
        public const float MaxValue = float.MaxValue;
        public const float Epsilon = float.Epsilon;
        public const float E = MathF.E;
        public const float Pi = MathF.PI;
        public const float Tau = MathF.PI * 2f;
        public const float GoldenRatio = 1.61803398875f;
        public const float SilverRatio = 2.41421356237f;
        public const float DegreeToRadian = Tau / 360f;
        public const float RadianToDegree = 360f / Tau;
    }
}