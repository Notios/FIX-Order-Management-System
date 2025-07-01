# 💹 FIX Order Management System (.NET)
Αυτό το project αποτελεί ένα βασικό σύστημα διαχείρισης εντολών αγοραπωλησίας μετοχών βασισμένο στο πρωτόκολλο FIX (Financial Information eXchange), υλοποιημένο σε C# και .NET.

## 🧩 Περιγραφή

Το σύστημα υποστηρίζει:
- Ανάλυση FIX μηνυμάτων (`FixParser`, `FixMessage`)
- Διαχείριση πελατών και εντολών (`Client`, `Order`)
- Επαλήθευση εγκυρότητας εντολών
- Δομή που επιτρέπει επέκταση σε σύνδεση με Brokers ή ανταλλαγές.

## 📦 Δομή Κώδικα

| Κλάση/Αρχείο | Περιγραφή |
|-------------|-----------|
| `Order` | Αναπαριστά μια εντολή αγοράς ή πώλησης |
| `OrderType` | Enum τύπου εντολής: Buy ή Sell |
| `Client` | Πελάτης με λίστα εντολών |
| `FixParser` | Parser για FIX μηνύματα σε tag-value pairs |
| `FixMessage` | Wrapper γύρω από dictionary tags, με εύκολη πρόσβαση |
| `Program.cs` | Παράδειγμα χρήσης με parsing FIX string |

## 🧪 Παράδειγμα FIX μηνύματος

```text
8=FIX.4.4<SOH>9=178<SOH>35=D<SOH>49=CLIENT12<SOH>56=BROKER12<SOH>...
```

Το Program.cs αναλύει αυτό το μήνυμα, εμφανίζει τα tags και εξάγει το ClOrdID (tag 11).

## ✅ Έλεγχοι εγκυρότητας

Η μέθοδος IsValid() στην Order ελέγχει:

- Αν υπάρχει σύμβολο και ISIN
- Αν Quantity & Price > 0

## 🛠️ Τεχνολογίες

Γλώσσα: C#

Πλατφόρμα: .NET 6+

FIX Version: FIX.4.4
