using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Test
{
    public class Garden
    {
        private ICollection<string> _plants = new List<string>();

        public Garden(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
        }

        public int Size { get; }

        public bool Plant(string plant)
        {
            CheckForNull(plant);
            ValidateName(plant);
            CheckForDuplicates(plant);
            if (Size <= _plants.Count)
            {
                return false;
            }
            _plants.Add(plant);
            return true;
        }

        private void CheckForDuplicates(string plant)
        {
            if (_plants.Contains(plant))
                throw new ArgumentException("Duplicated name", nameof(plant));
        }

        private static void ValidateName(string plant)
        {
            if (string.IsNullOrWhiteSpace(plant))
                throw new ArgumentException("Invalid name", nameof(plant));
        }

        private static void CheckForNull(string plant)
        {
            if (plant == null)
                throw new ArgumentNullException(nameof(plant));
        }

        public IEnumerable<string> GetPlants()
        {
            return _plants.ToList();
        }
    }
}