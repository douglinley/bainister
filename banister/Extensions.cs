using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace banister
{
    public static class Extensions
    {
        public static Vector2 Normalized(this Vector2 vector)
        {
            return IsZero(vector.Length()) ? vector : Vector2.Normalize(vector);
        }

        public static bool IsZero(float num)
        {
            return MathF.Abs(num) <= float.Epsilon;
        }
    }
}
