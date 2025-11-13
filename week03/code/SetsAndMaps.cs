using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        var wordSet = new HashSet<string>(words); // Create a set for O(1) lookups
        var pairs = new HashSet<string>(); // List to store the found pairs

        foreach (var word in words) // Iterate through each word
        {
            string fullWord = word;
            string firstChar = fullWord[0].ToString();
            string secondChar = fullWord[1].ToString();
            string reversed = secondChar + firstChar; // Reverse the word

            if (firstChar == secondChar)
            {
                continue; // Skip if both characters are the same
            }   

            //string pair = $"{word} & {reversed}";
            //string reversePair = $"{reversed} & {words[i]}";

            if (wordSet.Contains(reversed)) // Check if the reversed word exists and is not the same word, and not already added to avoid duplicates.
            {
                // Normalize pair order to avoid duplicates (alphabetical order)
                string pair = string.Compare(word, reversed) < 0 
                    ? $"{word} & {reversed}" 
                    : $"{reversed} & {word}";

                pairs.Add(pair);
                //Console.WriteLine($"Found pair: {pair}");
            }

            //Console.WriteLine($"({i}/{words.Length - 1}) Reverse of {words[i]} is {reversed}");
        }

        return pairs.ToArray(); // Convert the list to an array and return it
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(","); // Split line into columns
            // TODO Problem 2 - ADD YOUR CODE HERE

            string degree = fields[3]; // 4th column is index 3
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++; // Increment count if degree already exists
            }
            else
            {
                degrees[degree] = 1; // Initialize count if degree is new
            }

            //Console.WriteLine($"Processing line: {line}");
            //Console.WriteLine($"Found degree: {degree}");
            //Console.WriteLine($"Found degree: {degree}");
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // Normalize words: remove spaces and convert to lowercase
        string normalizedWord1 = word1.Replace(" ", "").ToLower();
        string normalizedWord2 = word2.Replace(" ", "").ToLower();

        // If lengths differ, they cannot be anagrams
        if (normalizedWord1.Length != normalizedWord2.Length)
        {
            return false;
        }

        var charCount = new Dictionary<char, int>();

        // Count characters in the first word
        foreach (char c in normalizedWord1)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        foreach (char c in normalizedWord2)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]--;
                if (charCount[c] < 0)
                {
                    return false; // More occurrences in word2 than in word1
                }
            }
            else
            {
                return false; // Character in word2 not found in word1
            }
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        var summaries = new List<string>();

        foreach (var feature in featureCollection.features)
        {
            // 1km NE of Pahala, Hawaii - Mag 2.36,
            string place = feature.properties.place; // Location of the earthquake
            double? magnitude = feature.properties.mag; // Magnitude of the earthquake
            string summary = $"{place} - Mag {magnitude}";

            //Console.WriteLine(description);
            summaries.Add(summary);
        }

        return summaries.ToArray();
    }
}