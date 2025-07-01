using System;
using System.Collections.Generic;

/// <summary>
/// Αναπαριστά ένα FIX μήνυμα με εύκολη πρόσβαση σε tag-values.
/// </summary>
public class FixMessage
{
    private readonly Dictionary<string, string> _fields;

    public FixMessage(string rawMessage)
    {
        _fields = FixParser.ParseFixMessage(rawMessage);
    }

    /// <summary>
    /// Επιστρέφει την τιμή ενός tag, αν υπάρχει, αλλιώς null.
    /// </summary>
    public string GetValue(string tag)
    {
        if (_fields.TryGetValue(tag, out var value))
            return value;
        return null;
    }

    /// <summary>
    /// Επιστρέφει την πλήρη συλλογή tag-value.
    /// </summary>
    public IReadOnlyDictionary<string, string> Fields => _fields;
}
