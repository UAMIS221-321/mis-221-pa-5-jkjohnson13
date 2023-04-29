namespace mis_221_pa_5_jkjohnson13
{
    public class TransactionUtility
    {
       private Transaction[] transactions;
       private Session[] sessions;
       private Trainer[] trainers;

       public TransactionUtility(Transaction[] transactions, Session[] sessions, Trainer[] trainers)
       {
            this.transactions = transactions;
            this.sessions = sessions;
            this.trainers = trainers;
       }

       public Transaction[] GetTransactionInfo()
        {
            //open
            StreamReader inFile = new StreamReader("transactions.txt");

            //process
            Transaction.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                transactions[Transaction.GetCount()] = new Transaction(int.Parse(temp[0]), int.Parse(temp[1]), temp[2], temp[3], temp[4], int.Parse(temp[5]), temp[6], temp[7]);
                Transaction.IncCount();
                
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
            return transactions;
        }

        public void AddTransaction()
        {
            Console.Clear();
            
            bool inLoop = true;
            while(inLoop)
            {
                Report report = new Report(trainers, sessions, transactions);
                Session book = new Session();
                Transaction myTrans = new Transaction();

                System.Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                System.Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                System.Console.Write("Enter a date to see available sessions for that day (mm/dd/yyyy): ");
                DateTime specificDate = DateTime.Parse(Console.ReadLine());
                string date = specificDate.ToShortDateString();
                System.Console.WriteLine($"\n---------Here are the available sessions on {date}---------");
                for(int i = 0; i < Session.GetCount(); i++)
                {
                    if(sessions[i].GetDate() == date && sessions[i].GetAvailable() == "OPEN")
                    {
                        Console.WriteLine(sessions[i].ToString());
                    }
                }

                System.Console.Write("\n\nEnter the Session ID: ");
                int sessionID = int.Parse(Console.ReadLine());
                for(int i = 0; i < Session.GetCount(); i++)
                {
                    if(sessions[i].GetSessionID() == sessionID)
                    {
                        Console.WriteLine(sessions[i].ToString());
                        myTrans.SetTrainerName(sessions[i].GetTrainerName());
                        sessions[i].SetAvailable("CLOSED");
                    }
                }

                Pause();
                report.DisplayAllTrainers();
                System.Console.Write($"\nEnter the Trainers ID to finish booking: ");
                int trainerID = int.Parse(Console.ReadLine());

                System.Console.WriteLine("\nPlease confirm the session by typing 'Yes'. Type 'No' if not");
                string confirm = Console.ReadLine();
                if(confirm.ToUpper() != "YES")
                {
                    System.Console.WriteLine("Back out and find the session you are looking for!");
                }
                else
                {
                    myTrans.SetSessionID(sessionID);
                    myTrans.SetCustomerName(name);
                    myTrans.SetEmail(email);
                    myTrans.SetDate(date);
                    myTrans.SetTrainerID(trainerID);
                    myTrans.SetStatus("BOOKED");
                    myTrans.SetBookingID(Transaction.GetCount() + 1);
                    transactions[Transaction.GetCount()] = myTrans;
                    Transaction.IncCount();

                    Save();

                    inLoop = false;
                }
            }
        }

        public void Search()
        {
            Console.Write("Enter ID: ");
            int searchVal = int.Parse(Console.ReadLine());
            int searchID = BinarySearch(searchVal);

            if(searchID == -1)
            {
                Console.WriteLine("\nSession does not exist\n\n");
            }
            else
            {
                UpdateSession(searchID);
                Save();
            }
        }

        public int BinarySearch(int searchVal)
        {   
            int min = 0;
            int max = Session.GetCount() - 1;

            while(min <= max)
            {
                int mid = (max + min)/2;
                
                if(searchVal == sessions[mid].GetSessionID())
                {
                    return mid;
                }
                if(searchVal < sessions[mid].GetSessionID())
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }

        public void UpdateSession(int searchID)
        {
            Console.Clear();
            
            Report report = new Report(trainers, sessions, transactions);
            
            System.Console.WriteLine(sessions[searchID].ToString());
            
            string choice = "";

            while(choice != "3")
            {
                System.Console.WriteLine("\nDo you want to....\n(1) Pay for session\n(2) Cancel session\n(3) Exit");
                choice = Console.ReadLine();

                if(choice == "1")
                {
                    System.Console.Write("\nEnter payment to complete session: $");
                    double payment = double.Parse(Console.ReadLine());
                    double cost = sessions[searchID].GetCost();
                    
                    while(payment != cost)
                    {
                        if(payment > cost)
                        {
                            double change = payment - cost; //calculates the change due
                            System.Console.WriteLine($"\nYour change due is ${change.ToString("#.##")}");
                            payment = cost; //exits while loop
                        }
                        else
                        {
                            System.Console.WriteLine(sessions[searchID].ToString());

                            System.Console.Write("\nInsuffiecient funds. Please enter the correct amount: $");
                            payment = double.Parse(Console.ReadLine());
                        }
                    }

                    report.DisplayAllTransactions();
                    System.Console.Write("\nNow, Enter the booking ID number to finalize transaction: ");
                    int setID = int.Parse(Console.ReadLine());
                    int bookID = setID - 1;
                    transactions[bookID].SetStatus("COMPLETED");
                    sessions[searchID].SetAvailable("PAID");

                    choice = "3"; 
                }
                else if(choice == "2")
                {
                    report.DisplayAllTransactions();
                    System.Console.Write("\nNow, Enter the booking ID number to finalize cancellation: ");
                    int setID = int.Parse(Console.ReadLine());
                    int bookID = setID - 1;
                    transactions[bookID].SetStatus("CANCELED");

                    choice = "3";
                }
                else if(choice == "3")
                {
                    //exits program
                }
                else
                {
                    System.Console.WriteLine("\nINVALID INPUT. Select valid option.\n");
                }
            }

        }

        public void Sort()
        {
            for(int i = 0; i < Transaction.GetCount() - 1; i++)
            {
                int min = i;

                for(int j = i + 1; j < Transaction.GetCount(); j++)
                {
                    if(transactions[j].GetBookingID().CompareTo(transactions[min].GetBookingID()) < 0)
                    {
                        min = j;
                    }
                }

                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }

        public void Swap(int x, int y)
        {
            Transaction temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }


        public void Save()
        {            
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Transaction.GetCount(); i++)
            {
                outFile.WriteLine(transactions[i].ToFile());
            }

            outFile.Close();
        }

        public void Pause()
        {
            System.Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadKey();
        }
    }
}