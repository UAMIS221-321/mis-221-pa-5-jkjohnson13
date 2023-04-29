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

        public void Individual()
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
        public void CustomerSessions()
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