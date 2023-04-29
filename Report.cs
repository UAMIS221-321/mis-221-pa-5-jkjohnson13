namespace mis_221_pa_5_jkjohnson13
{
    public class Report
    {
        Trainer[] trainers;
        Session[] sessions;
        Transaction[] transactions;

        public Report(Trainer[] trainers, Session[] sessions, Transaction[] transactions)
        {
            this.trainers = trainers;
            this.sessions = sessions;
            this.transactions = transactions;
        }

        public void SaveSession()
        {
            bool inLoop = true;

            while(inLoop)
            {
                System.Console.WriteLine("\nWould you like to save this report? 'Yes' or 'No'");
                string choice = Console.ReadLine().ToUpper();

                if(choice == "YES")
                {
                    System.Console.Write("\nEnter existing report file or create a new one: ");
                    string file = Console.ReadLine();
                    
                    StreamWriter outFile = new StreamWriter(file);
     
                    for(int i = 0; i < Session.GetCount(); i++)
                    {
                        outFile.WriteLine(sessions[i].ToFile());
                    }

                    outFile.Close();
                }
                inLoop = false;
            }
        }
        public void SaveTransaction()
        {
            bool inLoop = true;

            while(inLoop)
            {
                System.Console.WriteLine("\nWould you like to save this report? 'Yes' or 'No'");
                string choice = Console.ReadLine().ToUpper();

                if(choice == "YES")
                {
                    System.Console.Write("\nEnter existing report file or create a new one: ");
                    StreamWriter outFile = new StreamWriter(Console.ReadLine());

                    for(int i = 0; i < Transaction.GetCount(); i++)
                    {
                        outFile.WriteLine(transactions[i].ToFile());
                    }

                    outFile.Close();
                }
                inLoop = false;
            }
        }

        //*********TRAINER REPORTS*********
        public void DisplayAllTrainers()
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        //*********SESSION REPORTS*********
        public void DisplayAllSessions()
        {
            for(int i = 0; i < Session.GetCount(); i++)
            {
                System.Console.WriteLine(sessions[i].ToString());
            }
        }
        public void SortByDateTime()
        {
            for(int i = 0; i < Session.GetCount() - 1; i++)
            {
                int min = i;

                for(int j = i + 1; j < Session.GetCount(); j++)
                {
                    if(sessions[j].GetDate().CompareTo(sessions[min].GetDate()) > 0 || 
                    sessions[j].GetDate() == sessions[min].GetDate() && DateTime.Parse(sessions[j].GetTime()) < DateTime.Parse(sessions[min].GetTime()))
                    {
                        min = j;
                    }
                }

                if(min != i)
                {
                    SwapSessions(min, i);
                }
            }

            DisplayAllSessions();
        }
        public void RevenueReport()
        {
            Console.Clear();

            SortByDateTime();
            string choice = "";

            while(choice != "3")
            {
                System.Console.WriteLine("\n(1) By Month\n(2) By Year\n(3) Exit");
                choice = Console.ReadLine();

                if(choice == "1")
                {
                    Console.Clear();

                    string curr = DateTime.Parse(sessions[0].GetDate()).Month.ToString();
                    double count = sessions[0].GetCost();
                    for(int i = 0; i < Session.GetCount(); i++)
                    {
                        if(DateTime.Parse(sessions[i].GetDate()).Month.ToString() == curr)
                        {
                            count += sessions[i].GetCost();
                        }
                        else
                        {
                            ProcessBreakMonth(ref curr, ref count, sessions[i]);
                        }
                    }
                    
                        
                    ProcessBreak2(curr, count);
                    SaveSession();
                }
                else if(choice == "2")
                {
                    Console.Clear();
                    
                    string curr = DateTime.Parse(sessions[0].GetDate()).Year.ToString();
                    double count = sessions[0].GetCost();
                    for(int i = 0; i < Session.GetCount(); i++)
                    {
                        if(DateTime.Parse(sessions[i].GetDate()).Year.ToString() == curr)
                        {
                            count += sessions[i].GetCost();
                        }
                        else
                        {
                            ProcessBreakYear(ref curr, ref count, sessions[i]);
                        }
                    }
                    ProcessBreak2(curr, count);
                    SaveSession();
                }
                else if(choice == "3")
                {
                    //exit
                }
                else
                {
                    System.Console.WriteLine("INVALID INPUT. Please select a valid option.\n");
                }
            }
        }
        public void ProcessBreakMonth(ref string curr, ref double count, Session newSession)
        {
            System.Console.WriteLine($"Month {curr}: ${count}");
            curr = DateTime.Parse(newSession.GetDate()).Month.ToString();
            count = newSession.GetCost();
        }
        public void ProcessBreakYear(ref string curr, ref double count, Session newSession)
        {
            System.Console.WriteLine($"{curr}: ${count}");
            curr = DateTime.Parse(newSession.GetDate()).Year.ToString();
            count = newSession.GetCost();
        }
        public void ProcessBreak2(string curr, double count)
        {
            System.Console.WriteLine($"{curr}: ${count}");
        }
        private void SwapSessions(int x, int y)
        {
            Session temp = sessions[x];
            sessions[x] = sessions[y];
            sessions[y] = temp;
        }


        //*********TRANSACTION REPORTS*********
        public void DisplayAllTransactions()
        {
            for(int i = 0; i < Transaction.GetCount(); i++)
            {
                System.Console.WriteLine(transactions[i].ToString());
            }
        }
        public void Individual() //Individual Reports
        {
            System.Console.Write("Enter your email address to see report: ");
            string email = Console.ReadLine();
            System.Console.WriteLine($"\n---------Displaying: {email}---------");
            for(int i = 0; i < Transaction.GetCount(); i++)
            {
                if(transactions[i].GetEmail() == email)
                {
                    Console.WriteLine(transactions[i].ToString());
                }
            }
            SaveTransaction();
        }
        public void SortByNameDate()
        {
            for(int i = 0; i < Transaction.GetCount() - 1; i++)
            {
                int min = i;

                for(int j = i + 1; j < Transaction.GetCount(); j++)
                {
                    if(transactions[j].GetCustomerName().CompareTo(transactions[min].GetCustomerName()) < 0 || 
                    transactions[j].GetCustomerName() == transactions[min].GetCustomerName() && DateTime.Parse(transactions[j].GetDate()) > DateTime.Parse(transactions[min].GetDate()))
                    {
                        min = j;
                    }
                }

                if(min != i)
                {
                    SwapTransactions(min, i);
                }
            }
        }
        public void CustomerSessions() //For each customer provide total number of sessions
        {
            Console.Clear();

            SortByNameDate();
            string curr = transactions[0].GetCustomerName();
            int count = 0;
            for(int i = 0; i < Transaction.GetCount(); i++)
            {
                if(transactions[i].GetCustomerName() == curr)
                {
                    count++;
                }
                else
                {
                    ProcessBreak(ref curr, ref count, transactions[i]);
                }
            }
            ProcessBreak(curr, count);
            SaveTransaction();
        }
        public void ProcessBreak(ref string curr, ref int count, Transaction newTrans)
        {
            System.Console.WriteLine($"{curr} has a total of {count} session(s)");
            curr = newTrans.GetCustomerName();
            count = 1;
        }
        public void ProcessBreak(string curr, int count)
        {
            System.Console.WriteLine($"{curr} has a total of {count} session(s)");
        }
        public void SwapTransactions(int x, int y)
        {
            Transaction temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }
    }
}