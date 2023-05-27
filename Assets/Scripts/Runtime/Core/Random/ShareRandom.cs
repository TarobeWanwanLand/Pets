using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static Pets.Core.Math.Math;
using static UnityEngine.Vector3;

namespace Pets.Core.Random
{
    /// <summary>
    /// スレッドセーフな乱数ジェネレータ
    /// </summary>
    public static class ShareRandom
    {
        private const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;
        
        [ThreadStatic]
        private static readonly System.Random Random = new();
        
        public static int NextInt() => NextInt(int.MaxValue);
        public static int NextInt(int maxValue) => NextInt(0, maxValue);
        public static int NextInt(int minValue, int maxValue) => Random.Next(minValue, maxValue);
        
        public static float NextFloat() => NextFloat(1f);
        public static float NextFloat(float maxValue) => NextFloat(0f, maxValue);
        public static float NextFloat(float minValue, float maxValue) =>
            (float)Random.NextDouble() * (maxValue - minValue) + minValue;
        
        public static Vector2 NextInsideUnitCircle()
        {
            var angle = NextFloat(Tau);
            var radius = Sqrt(NextFloat());
            return new Vector2(Cos(angle) * radius, Sin(angle) * radius);
        }
        
        public static Vector2 NextOnUnitCircle()
        {
            var angle = NextFloat(Tau);
            return new Vector2(Cos(angle), Sin(angle));
        }

        public static Vector3 NextInsideUnitSphere()
        {
            var angle = NextFloat(Tau);
            var radius = Cbrt(NextFloat());
            var z = NextFloat(-1f, 1f);
            var sqrt = 1f - Sqrt(z * z);
            return new Vector3(Cos(angle) * sqrt, Sin(angle) * sqrt, z) * radius;
        }

        public static Vector3 NextOnUnitSphere()
        {
            var angle = NextFloat(Tau);
            var z = NextFloat(-1f, 1f);
            var sqrt = 1f - Sqrt(z * z);
            return new Vector3(Cos(angle) * sqrt, Sin(angle) * sqrt, z);
        }
        
        public static Vector3 NextInsideUnitHemisphere(Vector3 normal)
        {
            var angle = NextFloat(Tau);
            var radius = Sqrt(NextFloat());
            var z = NextFloat();
            var sqrt = 1f - z * z;
            var tangent = sqrt < Epsilon ? Cross(normal, up) : Cross(normal, forward);
            var bitangent = Cross(normal, tangent);
            return tangent * Cos(angle) * radius + bitangent * Sin(angle) * radius + normal * Sqrt(sqrt);
        }
        
        public static Vector3 NextOnUnitHemisphere(Vector3 normal)
        {
            var angle = NextFloat(Tau);
            var z = NextFloat();
            var sqrt = 1f - z * z;
            var tangent = sqrt < Epsilon ? Cross(normal, up) : Cross(normal, forward);
            var bitangent = Cross(normal, tangent);
            return tangent * Cos(angle) * Sqrt(sqrt) + bitangent * Sin(angle) * Sqrt(sqrt) + normal * z;
        }
        
        public static Vector3 NextInsideUnitCone(Vector3 direction, float angle)
        {
            var radius = Sqrt(NextFloat());
            var z = NextFloat();
            var sqrt = 1f - z * z;
            var tangent = sqrt < Epsilon
                ? Cross(direction, up)
                : Cross(direction, forward);
            var bitangent = Cross(direction, tangent);
            var cos = Cos(angle);
            var sin = Sin(angle);
            return tangent * cos * radius + bitangent * sin * radius + direction * Sqrt(sqrt);
        }
        
        public static Vector3 NextOnUnitCone(Vector3 direction, float angle)
        {
            var z = NextFloat();
            var sqrt = 1f - z * z;
            var tangent = sqrt < Epsilon
                ? Cross(direction, up)
                : Cross(direction, forward);
            var bitangent = Cross(direction, tangent);
            var cos = Cos(angle);
            var sin = Sin(angle);
            return tangent * cos * Sqrt(sqrt) + bitangent * sin * Sqrt(sqrt) + direction * z;
        }
    }
}