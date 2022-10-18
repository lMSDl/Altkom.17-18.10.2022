using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Test
{
    public class Garden
    {
        private ICollection<string> _plants = new List<string>();
        private readonly ILogger _logger;

        public Garden(int size, ILogger logger)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            _logger = logger;
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
            _logger.Log($"{plant} planted in garden");
            return true;
        }

        private void CheckForDuplicates(string plant)
        {
            if (!_plants.Contains(plant))
                return;
            var exception = new ArgumentException("Duplicated name", nameof(plant));
            _logger.Log($"Exception: {exception.Message}");
            throw exception;
        }

        private  void ValidateName(string plant)
        {
            if (!string.IsNullOrWhiteSpace(plant))
                return;
            var exception = new ArgumentException("Invalid name", nameof(plant));
            _logger.Log($"Exception: {exception.Message}");
            throw exception;
        }

        private void CheckForNull(string plant)
        {
            if (plant != null)
                return;
            var exception = new ArgumentNullException(nameof(plant));
            _logger.Log($"Exception: {exception.Message}");
            throw exception;
        }

        public IEnumerable<string> GetPlants()
        {
            return _plants.ToList();
        }
    }
}