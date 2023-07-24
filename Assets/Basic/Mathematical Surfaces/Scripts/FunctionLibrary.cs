using UnityEngine;
using static UnityEngine.Mathf;
namespace CatLikeCoding.Basics
{
    public class FunctionLibrary
    {
        #region Delegate
        public delegate Vector3 Function(float u, float v, float t);
        #endregion

        #region Private Variables
        static Function[] mFunction = { Wave, MultiWave, Ripple, Sphere, Torus };
        #endregion

        #region Static Functions
        public static Vector3 Wave(float u, float v, float t)
        {
            Vector3 p;
            p.x = u;
            p.y = Sin(PI * (u + v + t));
            p.z = v;
            return p;
        }

        public static Vector3 MultiWave(float u, float v, float t)
        {
            Vector3 p;
            p.x = u;
            p.y = Sin(PI * (u + .5f * t));
            p.y += .5f * Sin(PI * 2f * (v + t)) * (2f / 3);
            p.y += Sin(PI * (u + v + 0.25f * t));
            p.y *= (1 / 2.5f);
            p.z = v;
            return p;
        }

        public static Vector3 Ripple(float u, float v, float t)
        {
            Vector3 p;
            p.x = u;
            float d = Sqrt(u * u + v * v);
            p.y = Sin(PI * (4f * d - t));
            p.y /= (1f + 10f * d);
            p.z = v;
            return p;
        }

        public static Vector3 Sphere(float u, float v, float t)
        {
            float r = 0.5f + 0.5f * Sin(PI * t);
            float s = r * Cos(0.5f * PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = r * Sin(0.5f * PI * v);
            p.z = s * Cos(PI * u);
            return p;
        }

        public static Vector3 Torus(float u, float v, float t)
        {
            float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
            float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
            float s = r1 + r2 * Cos(PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = r2 * Sin(PI * v);
            p.z = s * Cos(PI * u);
            return p;
        }

        public static Function GetFunction(FunctionName functionName)
        {
            return mFunction[(int)functionName];
        }
        #endregion
    }

    #region Enum
    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple,
        Sphere,
        Torus
    }
    #endregion
}