using System;

namespace ConsoleApp.Test
{
    public class Garden
    {
        public Garden(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
        }

        public int Size { get; }

        public bool Plant(string name)
        {
            return true;
        }
    }
}