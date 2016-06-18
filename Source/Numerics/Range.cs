using System.Collections.Generic;

namespace Numerics
{
    /// <summary>
    /// A range of 64-bit integers.
    /// </summary>
    public struct Range
    {
        private readonly long length;
        private readonly long start;
        private readonly long end;

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="index">The index.</param>
        public Range(long length, long index)
        {
            this.length = length;
            this.start = index;
            this.end = index + length - 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="length">The length.</param>
        public Range(long length) : this(length, 0) { }

        /// <summary>
        /// Splits the range.
        /// </summary>
        /// <param name="count">The count of ranges to split into.</param>
        /// <returns>IEnumerable&lt;Range&gt;.</returns>
        public IEnumerable<Range> Split(long count)
        {
            if (count <= 0) return null;

            var currentStart = start;
            var newCount = length;

            long rangeCount;
            long unprocessedRangeCount;
            if (length / count == 0)
            {
                rangeCount = length;
                unprocessedRangeCount = length;
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{start} -> {end} [{length}]";
        }
    }
}
