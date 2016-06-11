using System.Collections.Generic;

namespace ConsoleApplication1
{
    public struct Range
    {
        private readonly long length;
        private readonly long start;
        private readonly long end;

        public Range(long length, long index)
        {
            this.length = length;
            this.start = index;
            this.end = index + length - 1;
        }

        public Range(long length) : this(length, 0) { }

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

        public override string ToString()
        {
            return $"{start} -> {end} [{length}]";
        }
    }
}
