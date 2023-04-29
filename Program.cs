using System.IO;
using mis_221_pa_5_jkjohnson13;
//********START MAIN*********
Trainer[] trainers = new Trainer[100];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
Session[] sessions = new Session[100];
SessionUtility sessionUtility = new SessionUtility(sessions);
Transaction[] transactions = new Transaction[100];
TransactionUtility transactionUtility = new TransactionUtility(transactions, sessions, trainers);
Report report = new Report(trainers, sessions, transactions);

trainerUtility.GetTrainerInfo();
sessionUtility.GetSessionInfo();
transactionUtility.GetTransactionInfo();

DisplayMenu(trainers, trainerUtility, sessions, sessionUtility, transactions, transactionUtility, report);
//*********END MAIN*********

static void DisplayMenu(Trainer[] trainers, TrainerUtility trainerUtility, Session[] sessions, SessionUtility sessionUtility, Transaction[] transactions, TransactionUtility transactionUtility, Report report)
{
    string menu = "";
    
    while(menu != "5")
    {
        Console.Clear();

        System.Console.WriteLine("---------MAIN MENU---------");
        System.Console.WriteLine("1. Manage Trainer Data\n2. Manage Listing Data\n3. Manage Customer Booking Data\n4. Run the reports\n5. Exit the application");
        menu = Console.ReadLine();

        if(menu == "1")
        {   
            TrainerData(trainers, trainerUtility, report);
        }
        else if(menu == "2")
        {
            SessionData(sessions, sessionUtility, report);
        }
        else if(menu == "3")
        {
            TransactionData(sessionUtility, transactions, transactionUtility, report);
        }
        else if(menu == "4")
        {
            Reports(trainerUtility, sessionUtility, transactionUtility,report);
        }
        else if(menu == "5")
        {
            System.Console.WriteLine("Thank you for using my application!");
        }
        else
        {
            InvalidInput();
        }
    }
}

static void TrainerData(Trainer[] trainers, TrainerUtility trainerUtility, Report report)
{
    string choice = "";

    while(choice != "4")
    {
        Console.Clear();
        
        System.Console.WriteLine("---------Trainer Data---------");
        System.Console.WriteLine("1. Add Trainers\n2. Edit Trainers\n3. Display Trainers\n4. Exit");
        choice = Console.ReadLine();

        if(choice == "1")
        {
            // Guid g = Guid.NewGuid();
            // Console.WriteLine(g);
            
            trainerUtility.AddTrainer();
            report.DisplayAllTrainers();
            Pause();
        }
        else if(choice == "2")
        {
            report.DisplayAllTrainers();
            trainerUtility.Search();
            report.DisplayAllTrainers();
            Pause();
        }
        else if(choice == "3")
        {
            trainerUtility.Sort();
            report.DisplayAllTrainers();
            Pause();
        }
        else if(choice == "4")
        {
            
        }
        else
        {
            InvalidInput();
            Pause();
        }

    }
} 

static void SessionData(Session[] sessions, SessionUtility sessionUtility, Report report)
{
    string choice = "";

    while(choice != "4")
    {
        Console.Clear();
        
        System.Console.WriteLine("---------Listing Data---------");
        System.Console.WriteLine("1. Add Session\n2. Edit Session\n3. Display Sessions\n4. Exit");
        choice = Console.ReadLine();

        if(choice == "1")
        {   
            sessionUtility.AddSession();
            report.DisplayAllSessions();
            Pause();
        }
        else if(choice == "2")
        {
            report.DisplayAllSessions();
            sessionUtility.Search();
            report.DisplayAllSessions();
            Pause();
        }
        else if(choice == "3")
        {
            report.DisplayAllSessions();
            Pause();
        }
        else if(choice == "4")
        {
            
        }
        else
        {
            InvalidInput();
            Pause();
        }

    }
}

static void TransactionData(SessionUtility sessionUtility, Transaction[] transactions, TransactionUtility transactionUtility, Report report)
{
    string choice = "";

    while(choice != "4")
    {
        Console.Clear();
        
        System.Console.WriteLine("---------Booking Data---------");
        System.Console.WriteLine($"1. Book a Session\n2. Update Status\n3. Display Bookings\n4. Exit");
        choice = Console.ReadLine();

        if(choice == "1")
        {   
            transactionUtility.AddTransaction();
            sessionUtility.Save();
            report.DisplayAllTransactions();
            Pause();
        }
        else if(choice == "2")
        {
            sessionUtility.Sort();
            report.DisplayAllSessions();
            transactionUtility.Search();
            report.DisplayAllTransactions();
            Pause();
        }
        else if(choice == "3")
        {
            report.DisplayAllTransactions();
            Pause();
        }
        else if(choice == "4")
        {
            
        }
        else
        {
            InvalidInput();
            Pause();
        }

    }
}

static void Reports(TrainerUtility trainerUtility, SessionUtility sessionUtility, TransactionUtility transactionUtility, Report report)
{
    Console.Clear();
    
    System.Console.WriteLine("running reports...running reports...running reports");
    Pause();

    string choice = "";

    while(choice != "4")
    {
        Console.Clear();
        
        System.Console.WriteLine("---------Report Menu---------");
        System.Console.WriteLine($"1. Individual Customer Sessions\n2. Historical Customer Sessions\n3. Historical Revenue Report\n4. Exit");
        choice = Console.ReadLine();

        if(choice == "1")
        {   
            report.Individual();
            Pause();
        }
        else if(choice == "2")
        {
            string option = "";

            while(option != "4")
            {
                System.Console.WriteLine($"\n---------Historical Customer Sessions---------");
                System.Console.WriteLine($"(1) Sorted by Date\n(2) Sorted by Customer\n(3) Total Sessions by Customer\n(4) Exit");
                option = Console.ReadLine();

                if(option == "1")
                {
                    report.SortByDateTime();
                    report.SaveSession();
                }
                else if(option == "2")
                {
                    report.SortByNameDate();
                    report.DisplayAllTransactions();
                    report.SaveTransaction();
                }
                else if(option == "3")
                {
                    report.CustomerSessions();
                }
                else if(option == "4")
                {

                }
                else
                {
                    InvalidInput();
                    Pause();
                }
            }
        }
        else if(choice == "3")
        {
            report.RevenueReport();
        }
        else if(choice == "4")
        {
            //back to menu
        }
        else
        {
            InvalidInput();
            Pause();
        }

    }

    trainerUtility.Sort();
    sessionUtility.Sort();
    transactionUtility.Sort();
}

//*********OTHER METHODS*********
static void Pause()
{
    System.Console.WriteLine("\n\nPress enter to continue...");
    Console.ReadKey();
}

static void InvalidInput()
{
    System.Console.WriteLine("\nINVALID INPUT. Please enter one of the options given");
}