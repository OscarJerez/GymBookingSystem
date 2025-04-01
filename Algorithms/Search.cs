using System;
using System.Collections.Generic;

namespace GymBookingSystem.Algorithms
{
    // Implements Binary Search algorithm to find a class by name
    public class Search
    {
        public int BinarySearch(List<string> sortedClasses, string target)
        {
            int left = 0;
            int right = sortedClasses.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(sortedClasses[mid], target, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return mid; // Found the target class
                }
                else if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1; // Not found
        }
    }
}
