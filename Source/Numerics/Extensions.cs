using System.Collections.Generic;

namespace Numerics
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns a zero-based enumeration up to, but excluding, the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IEnumerable&lt;System.Int64&gt;.</returns>
        public static IEnumerable<long> AsEnumerable(this long value)
        {
            for (var current = 0; current < value; ++current)
            {
                yield return current;
            }
        }

        /// <summary>
        /// Returns a zero-based enumeration up to, but excluding, the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        public static IEnumerable<int> AsEnumerable(this int value)
        {
            for (var current = 0; current < value; ++current)
            {
                yield return current;
            }
        }
    }
}