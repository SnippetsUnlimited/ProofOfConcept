using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.SpellChecker.Library
{
    public class LevenshteinDistance
    {
        public static int GetDistance(string left, string right, bool isDamerauDistanceApplied)
        {
            if (left.Length == 0) return right.Length;
            if (right.Length == 0) return left.Length;

            var lenLeft = left.Length;
            var lenRight = right.Length;

            var matrix = new int[lenLeft + 1, lenRight + 1];

            for (var i = 0; i <= lenLeft; i++)
                matrix[i, 0] = i;

            for (var i = 0; i <= lenRight; i++)
                matrix[0, i] = i;

            for (var i = 1; i <= lenLeft; i++)
            {
                for (var j = 1; j <= lenRight; j++)
                {
                    var cost = (left[i - 1] == right[j - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);

                    if (isDamerauDistanceApplied)
                    {
                        // Fixed for string base 0 index.
                        if (i > 1 && j > 1 && left[i - 1] == right[j - 2] && left[i - 2] == right[j - 1])
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                        }
                    }

                }
            }

            return matrix[lenLeft, lenRight];
        }
    }
}