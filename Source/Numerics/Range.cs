using System.Collections.Generic;
using System.Linq;

namespace Numerics
{
    /// <summary>
    /// A range of 64-bit integers.
    /// </summary>
    public struct Range
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="index">The index.</param>
        public Range(long length, long index)
        {
            Length = length;
            Start = index;
            End = index + length - 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="length">The length.</param>
        public Range(long length) : this(length, 0) { }

        /// <summary>
        /// Gets the start.
        /// </summary>
        /// <value>The start.</value>
        public long Start { get; }

        /// <summary>
        /// Gets the end.
        /// </summary>
        /// <value>The end.</value>
        public long End { get; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public long Length { get; }

        /// <summary>
        /// Splits the range.
        /// </summary>
        /// <param name="count">The count of ranges to split into.</param>
        /// <returns>IEnumerable&lt;Range&gt;.</returns>
        public IEnumerable<Range> Split(long count)
        {
            if (count <= 0) return null;

            var currentStart = Start;
            var newCount = Length;

            long rangeCount;
            long unprocessedRangeCount;
            if (Length / count == 0)
            {
                rangeCount = Length;
                unprocessedRangeCount = Length;
            }
            else
            {
                rangeCount = count;
                unprocessedRangeCount = count;
            }
            var ranges = new Range[rangeCount];

            for (var i = 0; i < rangeCount; i++)
            {
                long currentRangeLength;
                var idealLength = newCount / unprocessedRangeCount;

                if (newCount % idealLength != 0 || (idealLength == 1 && newCount > unprocessedRangeCount))
                {
                    currentRangeLength = idealLength + 1;
                }
                else
                {
                    currentRangeLength = idealLength;
                }

                ranges[i] = new Range(currentRangeLength, currentStart);

                currentStart = currentStart + currentRangeLength;
                newCount = newCount - currentRangeLength;
                unprocessedRangeCount = unprocessedRangeCount - 1;
            }
            return ranges;
        }

        /// <summary>
        /// Enumerates between the start and end of the range.
        /// </summary>
        /// <returns>IEnumerable&lt;System.Int64&gt;.</returns>
        public IEnumerable<long> AsEnumerable()
        {
            for (var current = Start; current <= End; ++current)
            {
                yield return current;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{Start} -> {End} [{Length}]";
        }
    }
}