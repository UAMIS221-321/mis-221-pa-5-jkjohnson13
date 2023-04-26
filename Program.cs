using System.IO;
using mis_221_pa_5_jkjohnson13;
//********START MAIN*********
Trainer[] trainers = new Trainer[100];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
Session[] sessions = new Session[100];
SessionUtility sessionUtility = new SessionUtility(sessions);
// Transaction[] transactions = new Transaction[100];
// TransactionUtility transactionUtility = new TransactionUtility(transactions);
Report report = new Report(trainers, sessions);


DisplayMenu(trainers, trainerUtility, sessions, sessionUtility, report);
//*********END MAIN*********

static void DisplayMenu(Trainer[] trainers, TrainerUtility trainerUtility, Session[] sessions, SessionUtility sessionUtility, Report report)
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
            TransactionData();
        }
        else if(menu == "4")
        {
            Reports();
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
    trainerUtility.GetTrainerInfo();

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
    sessionUtility.GetSessionInfo();

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
            System.Console.WriteLine("Edit a Session");
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

static void TransactionData()
{
    System.Console.WriteLine("Booking Data");
}

static void Reports()
{
    System.Console.WriteLine("running reports...running reports...running reports");
    Pause();
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