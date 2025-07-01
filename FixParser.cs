using System;
using System.Collections.Generic;

public static class FixParser
{
    /// <summary>
    /// Μετατρέπει ένα FIX μήνυμα σε dictionary με key=tag και value=τιμή.
    /// </summary>
    /// <param name="fixMessage">Το FIX μήνυμα, με πεδία διαχωρισμένα με <SOH></param>
    /// <returns>Dictionary με τα tag-value ζευγάρια</returns>
    public static Dictionary<string, string> ParseFixMessage(string fixMessage)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();

        if (string.IsNullOrEmpty(fixMessage))
            throw new ArgumentException("Το FIX μήνυμα δεν μπορεί να είναι κενό.");

        // Διαχωρισμός με βάση το <SOH> string (που υποκαθιστά τον χαρακτήρα ASCII 0x01)
        string[] fields = fixMessage.Split(new string[] { "<SOH>" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string field in fields)
        {
            int idx = field.IndexOf('=');
            if (idx <= 0 || idx == field.Length - 1)
                throw new FormatException($"Μη έγκυρο πεδίο FIX: {field}");

            string tag = field.Substring(0, idx);
            string value = field.Substring(idx + 1);

            result[tag] = value;
        }

        return result;
    }
}
