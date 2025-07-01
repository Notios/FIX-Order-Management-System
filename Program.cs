using System;

class Program
{
    static void Main()
    {
        string message = "8=FIX.4.4<SOH>9=178<SOH>35=D<SOH>49=CLIENT12<SOH>56=BROKER12<SOH>34=215<SOH>52=20250701-12:30:05.123<SOH>11=ORDER12345<SOH>21=1<SOH>55=EUR/USD<SOH>54=1<SOH>38=1000000<SOH>40=2<SOH>44=1.12345<SOH>59=0<SOH>10=128<SOH>";

        try
        {
            var fixMessage = new FixMessage(message);

            Console.WriteLine("Parsed FIX message:");
            foreach (var kvp in fixMessage.Fields)
            {
                Console.WriteLine($"Tag {kvp.Key} = {kvp.Value}");
            }

            // Παράδειγμα
            string orderId = fixMessage.GetValue("11");  // ClOrdID
            Console.WriteLine($"\nOrder ID (tag 11): {orderId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Σφάλμα κατά την ανάλυση FIX μηνύματος: {ex.Message}");
        }
    }
}
