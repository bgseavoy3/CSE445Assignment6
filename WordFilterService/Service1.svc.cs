using System;
using System.Linq;
using System.ServiceModel;

namespace WordFilterService
{
    // This class implements the IWordFilterService contract.
    // Renaming the file is optional but recommended for clarity.
    public class Service1 : IWordFilterService
    {
        public string WordFilter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Define a list of stop words to filter out.
            string[] stopWords = { "a", "an", "in", "on", "the", "is", "are", "am" };

            // Split the input string into words using whitespace.
            var words = input.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Filter out words that are in the stopWords list (case-insensitive).
            var filteredWords = words.Where(word => !stopWords.Contains(word.ToLower())).ToArray();

            // Join the remaining words back into a single string.
            return string.Join(" ", filteredWords);
        }
    }
}
