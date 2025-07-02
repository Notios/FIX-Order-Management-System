# Financial Information eXchange (FIX)

### FIX Protocol
- Το FIX είναι πρωτόκολλο ανταλλαγής μηνυμάτων για συναλλαγές σε χρηματοοικονομικές αγορές.
- Χρησιμοποιείται για πραγματικό χρόνο επικοινωνία μεταξύ επενδυτικών τραπεζών, χρηματιστηρίων και traders.
- Υποστηρίζει pre-trade, trade και post-trade επικοινωνία.

#### Τι είναι όλα αυτά τα trade;

Οι όροι *pre-trade*, *trade* και *post-trade* χρησιμοποιούνται συνήθως στον χώρο των χρηματοπιστωτικών αγορών και περιγράφουν τα τρία βασικά στάδια μιας συναλλαγής. Ακολουθεί μια ανάλυση:

#### 1. Pre-trade (Πριν από τη συναλλαγή)
Αφορά όλα τα βήματα και τις διαδικασίες που γίνονται πριν από την εκτέλεση μιας συναλλαγής.

Περιλαμβάνει:
- Ανάλυση αγοράς και στρατηγική επιλογής επενδύσεων
- Καθορισμός προφίλ ρίσκου του επενδυτή
- Έρευνα τιμών, όγκου και τάσεων
- Επιλογή χρηματοπιστωτικού μέσου (μετοχή, ομόλογο, παράγωγο κ.λπ.)
- Εκτίμηση κόστους συναλλαγής και πιθανών κινδύνων

#### 2. Trade (Κατά τη διάρκεια της συναλλαγής)
Είναι το στάδιο της εκτέλεσης της συναλλαγής στην αγορά.

Περιλαμβάνει:
- Διάταξη εντολής αγοράς ή πώλησης (order placement)
- Εκτέλεση της εντολής από τον broker ή μέσω trading platform
- Επιβεβαίωση ότι η τιμή και οι όροι είναι σύμφωνοι με τις επιθυμίες του επενδυτή

#### 3. Post-trade (Μετά τη συναλλαγή)
Αφορά όλες τις διαδικασίες μετά την ολοκλήρωση της εντολής.

Περιλαμβάνει:
- Διακανονισμό (settlement), δηλαδή τη μεταφορά τίτλων και κεφαλαίων
- Εκκαθάριση (clearing), όπου υπολογίζεται η ακριβής υποχρέωση κάθε πλευράς
- Καταγραφή συναλλαγής στα συστήματα
- Αναφορές, λογιστική αποτύπωση και εποπτικός έλεγχος

### FIX Engines
Για να γράψεις εφαρμογές που μιλούν FIX, χρειάζεσαι FIX engine. Οι πιο γνωστοί είναι:

| FIX Engine     | Γλώσσες        | Σημειώσεις |
|----------------|----------------|--------|
| QuickFIX       | C++, Python, Ruby | Ανοιχτού κώδικα, ευρέως χρησιμοποιούμενος |
| QuickFIX/n     | C#/.NET        | Για .NET περιβάλλον |
| QuickFIX/J     | Java           | Για Java developers |

### Εκδόσεις του FIX
- FIX 4.2: Πολύ διαδεδομένο για equities.
- FIX 4.4: Υποστηρίζει πιο σύνθετα προϊόντα.
- FIX 5.0: Πιο σύγχρονο, με διαχωρισμό transport και message layer.

#### Βιβλιογραφία 📚 
- [Επίσημος οδηγός του FIX Trading Community](https://www.fixtrading.org/implementation-guide/)
- [Άρθρο ανάυσης του FIX στο Investopedia](https://www.investopedia.com/terms/f/financial-information-exchange.asp)

## FIX εφαρμογή σε .NET περιβάλλον

Η C# σε συνδυασμό με το **QuickFIX/n** είναι ιδανική για να χτίσουμε FIX εφαρμογές σε .NET περιβάλλον.

### 1. Εγκατάσταση QuickFIX/n
Προσθέτουμε το QuickFIX/n στο project σου με NuGet:

```bash
dotnet add package QuickFIXn.FIX4.4
```

Αυτό θα μας δώσει FIX 4.4 υποστήριξη, που είναι αυτή την περίοδο, η πιο διαδεδομένη.

### 2. Δομή Εφαρμογής
Θα χρειαστούμε δύο βασικά components:
- **Initiator**: Ο client που ξεκινά τη FIX σύνδεση.
- **Acceptor**: Ο server που δέχεται FIX connections.

### 3. FIX Session
Χρησιμοποιούμε ένα `.cfg` αρχείο για να ορίσουμε τις παραμέτρους της σύνδεσης:

```ini
[DEFAULT]
ConnectionType=initiator
StartTime=00:00:00
EndTime=23:59:59
HeartBtInt=30
FileStorePath=store
FileLogPath=log
DataDictionary=spec/FIX44.xml

[SESSION]
BeginString=FIX.4.4
SenderCompID=YOUR_APP
TargetCompID=BROKER
SocketConnectHost=127.0.0.1
SocketConnectPort=9876
```

### 4. Δημιουργία FIX Μηνυμάτων
Παράδειγμα `NewOrderSingle` σε C#:

```csharp
var order = new QuickFix.FIX44.NewOrderSingle(
    new ClOrdID("12345"),
    new Symbol("ETE"),
    new Side(Side.BUY),
    new TransactTime(DateTime.Now),
    new OrdType(OrdType.MARKET)
);
Session.SendToTarget(order, sessionID);
```

## 1. Initiator

### Δομή του Project

```
FixClient/
├── App.config
├── FixClientApp.cs
├── FixClient.csproj
├── fix.cfg
```

---

### 1. Το αρχείο `fix.cfg`

```ini
[DEFAULT]
ConnectionType=initiator
StartTime=00:00:00
EndTime=23:59:59
HeartBtInt=30
FileStorePath=store
FileLogPath=log
DataDictionary=spec/FIX44.xml

[SESSION]
BeginString=FIX.4.4
SenderCompID=CLIENT1
TargetCompID=SERVER1
SocketConnectHost=127.0.0.1
SocketConnectPort=5001
```

### 2. Η κλάση `FixClientApp.cs`

```csharp
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;

public class FixClientApp : MessageCracker, IApplication
{
    private SessionID _sessionID;

    public void OnCreate(SessionID sessionID) => _sessionID = sessionID;
    public void OnLogon(SessionID sessionID) => Console.WriteLine("Logon successful");
    public void OnLogout(SessionID sessionID) => Console.WriteLine("Logged out");
    public void FromAdmin(Message message, SessionID sessionID) { }
    public void ToAdmin(Message message, SessionID sessionID) { }
    public void FromApp(Message message, SessionID sessionID) => Crack(message, sessionID);
    public void ToApp(Message message, SessionID sessionID) => Console.WriteLine("Sent: " + message);

    public void SendOrder()
    {
        var order = new NewOrderSingle(
            new ClOrdID("123456"),
            new Symbol("ΕΤΕ"),
            new Side(Side.BUY),
            new TransactTime(DateTime.Now),
            new OrdType(OrdType.MARKET)
        );

        order.Set(new OrderQty(100));
        Session.SendToTarget(order, _sessionID);
    }

    public void OnMessage(ExecutionReport report, SessionID sessionID)
    {
        Console.WriteLine("Received ExecutionReport: " + report);
    }
}
```

### 3. Main Method

```csharp
class Program
{
    static void Main(string[] args)
    {
        var settings = new SessionSettings("fix.cfg");
        var app = new FixClientApp();
        var storeFactory = new FileStoreFactory(settings);
        var logFactory = new FileLogFactory(settings);
        var messageFactory = new DefaultMessageFactory();

        // logon
        var initiator = new SocketInitiator(app, storeFactory, settings, logFactory, messageFactory);
        initiator.Start();

        app.SendOrder(); 

        // 
        Console.WriteLine("Press Enter to quit");
        Console.ReadLine();
        initiator.Stop();
    }
}
```

### 4. Πώς να το τρέξεις
1. Κατέβασε το [QuickFIX/n από το GitHub](https://github.com/connamara/quickfixn) ή εγκατέστησέ το με NuGet.
2. Βεβαιώσου ότι έχεις το `FIX44.xml` στο φάκελο `spec/`.
3. Τρέξε το project και παρακολούθησε τα logs.

## 2. Acceptor

### Δομή του Project

```
FixServer/
├── FixServerApp.cs
├── fix.cfg
├── FixServer.csproj
```

### 1. Το αρχείο `fix.cfg`

```ini
[DEFAULT]
ConnectionType=acceptor
StartTime=00:00:00
EndTime=23:59:59
HeartBtInt=30
FileStorePath=store
FileLogPath=log
DataDictionary=spec/FIX44.xml
SocketAcceptPort=5001

[SESSION]
BeginString=FIX.4.4
SenderCompID=SERVER1
TargetCompID=CLIENT1
```

### 2. Η κλάση `FixServerApp.cs`

```csharp
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;

public class FixServerApp : MessageCracker, IApplication
{
    public void OnCreate(SessionID sessionID) => Console.WriteLine("Session created");
    public void OnLogon(SessionID sessionID) => Console.WriteLine("Client logged on");
    public void OnLogout(SessionID sessionID) => Console.WriteLine("Client logged out");
    public void FromAdmin(Message message, SessionID sessionID) { }
    public void ToAdmin(Message message, SessionID sessionID) { }
    public void ToApp(Message message, SessionID sessionID) => Console.WriteLine("Sent: " + message);
    public void FromApp(Message message, SessionID sessionID) => Crack(message, sessionID);

    public void OnMessage(NewOrderSingle order, SessionID sessionID)
    {
        Console.WriteLine("Received Order: " + order);

        var execReport = new ExecutionReport(
            new OrderID("123"),
            new ExecID("123456"),
            new ExecType(ExecType.FILL),
            new OrdStatus(OrdStatus.FILLED),
            order.Symbol,
            order.Side,
            new LeavesQty(0),
            new CumQty(100),
            new AvgPx(150.00m)
        );

        execReport.Set(order.ClOrdID);
        execReport.Set(new LastShares(100));
        execReport.Set(new LastPx(150.00m));

        Session.SendToTarget(execReport, sessionID);
    }
}
```

### 3. Main Method

```csharp
class Program
{
    static void Main(string[] args)
    {
        var settings = new SessionSettings("fix.cfg");
        var app = new FixServerApp();
        var storeFactory = new FileStoreFactory(settings);
        var logFactory = new FileLogFactory(settings);
        var messageFactory = new DefaultMessageFactory();

        var acceptor = new SocketAcceptor(app, storeFactory, settings, logFactory, messageFactory);
        acceptor.Start();

        Console.WriteLine("FIX Acceptor running. Press Enter to stop.");
        Console.ReadLine();

        acceptor.Stop();
    }
}
```

## 3. FIX Client <-> FIX Server

Πάμε να ετοιμάσουμε τον FIX Client και τον FIX Server ώστε να λειτουργούν μαζί.

### Δομή του Solution

```
FixDemoSolution/
├── FixClient/
│   ├── FixClient.csproj
│   ├── fix.cfg
│   └── FixClientApp.cs
├── FixServer/
│   ├── FixServer.csproj
│   ├── fix.cfg
│   └── FixServerApp.cs
├── FixDemoSolution.sln
```

1. **Δημιουργούμε το Solution:**

```bash
dotnet new sln -n FixDemoSolution
```

2. **Δημιουργούμε τα Projects:**

```bash
dotnet new console -n FixClient
dotnet new console -n FixServer
```

3. **Προσθέτουμε τα Projects στο Solution:**

```bash
dotnet sln add FixClient/FixClient.csproj
dotnet sln add FixServer/FixServer.csproj
```

4. **Προσθέτουμε το NuGet πακέτο:**

```bash
dotnet add FixClient package QuickFIXn.FIX4.4
dotnet add FixServer package QuickFIXn.FIX4.4
```

5. **Αντιγράφουμε τα αρχεία `fix.cfg` και τις κλάσεις `FixClientApp.cs`, `FixServerApp.cs`** όπως πριν.

6. **Κατεβάζουμε το `FIX44.xml`** από το [QuickFIX/n GitHub repo](https://github.com/connamara/quickfixn/tree/master/spec) και και το βάζουμε στον φάκελο `spec/` και στα δύο projects.

### Πώς το τρέχουμε

1. Άνοιξε το solution στο Visual Studio.
2. Κάνε build με `dotnet build`.
3. Τρέξε πρώτα το `FixServer`:

```bash
dotnet run --project FixServer
```

4. Μετά τρέξε το `FixClient`:

```bash
dotnet run --project FixClient
```

Θα δεις logon, αποστολή εντολής και λήψη `ExecutionReport`.

## Πώς ακριβώς επικοινωνούν μεταξύ τους ο FixClient και ο FixServer;

Η επικοινωνία γίνεται μέσω TCP socket connection και χρησιμοποιεί το FIX 4.4 πρωτόκολλο για την ανταλλαγή μηνυμάτων.

| Ρόλος        | Περιγραφή                         | Παράδειγμα FIX Message         |
|--------------|-----------------------------------|-------------------------------|
| **Client (Initiator)** | Ξεκινάει τη σύνδεση         | Logon, NewOrderSingle         |
| **Server (Acceptor)**  | Δέχεται τη σύνδεση           | Logon Response, ExecutionReport |

### Σειρά Ενεργειών

### 1. Ο Client ξεκινά τη σύνδεση
- Ο `FixClient` προσπαθεί να συνδεθεί στο `SocketAcceptHost` και `SocketAcceptPort` του Server που ορίζονται στο `fix.cfg`.

### 2. Ανταλλαγή Logon
- Ο Client στέλνει `Logon` μήνυμα με `SenderCompID=CLIENT1` και `TargetCompID=SERVER1`.
- Ο Server απαντά με `Logon` για να επιβεβαιώσει τη σύνδεση.

Αυτά γίνονται αυτόματα από την QuickFIX engine.

### 3. Αποστολή Εντολής από Client
Ο `FixClient` δημιουργεί `NewOrderSingle`:

```csharp
var order = new NewOrderSingle(
    new ClOrdID("123456"),
    new Symbol("ΕΤΕ"),
    new Side(Side.BUY),
    new TransactTime(DateTime.Now),
    new OrdType(OrdType.MARKET)
);
Session.SendToTarget(order, sessionID);
```

Αυτό το μήνυμα στέλνεται μέσω της **Session** στο Server.

### 4. Ο Server λαμβάνει και απαντά
Ο `FixServer` λαμβάνει το `NewOrderSingle` στο `OnMessage(...)` και δημιουργεί `ExecutionReport` για να απαντήσει:

```csharp
var execReport = new ExecutionReport(
    new OrderID("ORDER123"),         // Μοναδικό ID εντολής του συστήματος
    new ExecID("EXEC123"),           // ID εκτέλεσης (execution ID)
    new ExecType(ExecType.FILL),     // Τύπος εκτέλεσης (π.χ. Fill, PartialFill, Reject)
    new OrdStatus(OrdStatus.FILLED), // Κατάσταση εντολής (π.χ. Filled, New, Rejected)
    order.Symbol,                    // Σύμβολο της μετοχής από την αρχική εντολή (π.χ. ETE)
    order.Side,                      // Κατεύθυνση εντολής (Buy/Sell)
    new LeavesQty(0),                // Υπόλοιπο που απομένει (0 = πλήρως εκτελεσμένη)
    new CumQty(100),                 // Ποσότητα που εκτελέστηκε συνολικά
    new AvgPx(150.00m)               // Μέση τιμή εκτέλεσης
);

Session.SendToTarget(execReport, sessionID);
```

### 5. Ο Client λαμβάνει την απάντηση
Ο `FixClientApp` την παραλαμβάνει στο `OnMessage(ExecutionReport, ...)` και μπορεί να την εμφανίσει ή να την επεξεργαστεί.


### FIX Messages που ανταλλάσσονται

| Μήνυμα            | Ποιος το στέλνει | Περιγραφή                        |
|------------------|------------------|----------------------------------|
| `Logon`          | Client/Server    | Ξεκινά επικοινωνία               |
| `NewOrderSingle` | Client           | Αγορά/πώληση εντολή              |
| `ExecutionReport`| Server           | Επιστροφή αποτελέσματος εντολής |
