namespace mis_221_pa_5_jkjohnson13
{
    public class SessionUtility
    {
        private Session[] sessions;

        //constructor
        public SessionUtility(Session[] sessions)
        {
            this.sessions = sessions;
        }

        public Session[] GetSessionInfo()
        {
            //open
            StreamReader inFile = new StreamReader("listings.txt");

            //process
            Session.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                sessions[Session.GetCount()] = new Session(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), temp[5]);
                Session.IncCount();
                
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
            return sessions;
        }

        public void AddSession()
        {
            Console.Clear();
            
            Session mySession = new Session();

            int maxID = MaxID();
            mySession.SetSessionID(maxID + 1);

            mySession.SetAvailable("OPEN");

            System.Console.Write("Enter the trainers name: ");
            mySession.SetTrainerName(Console.ReadLine());

            System.Console.Write("Enter the date of the session (mm/dd/yyyy): ");
            DateTime specificDate = DateTime.Parse(Console.ReadLine());
            string date = specificDate.ToShortDateString();
            mySession.SetDate(date);

            System.Console.Write("Enter the time of the session (ex. 12:30 pm): ");
            DateTime specificTime = DateTime.Parse(Console.ReadLine());
            string startTime = specificTime.ToShortTimeString();
            string endTime = specificTime.AddHours(1).ToShortTimeString();
            mySession.SetTime($"{startTime} - {endTime}");

            System.Console.Write("Enter the cost amount of the session: ");
            mySession.SetCost(double.Parse(Console.ReadLine()));

            sessions[Session.GetCount()] = mySession;

            Session.IncCount();
            Session.IncMaxID();

            Save();
        }

        public int MaxID()
        {
            Sort();
            int max = 0;

            for(int i = 0; i < Session.GetCount(); i++)
            {
                if(sessions[i].GetSessionID() > max)
                {
                    max = sessions[i].GetSessionID();
                }
            }
            return max;
        }

        public void Sort()
        {
            for(int i = 0; i < Session.GetCount() - 1; i++)
            {
                int min = i;

                for(int j = i + 1; j < Session.GetCount(); j++)
                {
                    if(sessions[j].GetSessionID().CompareTo(sessions[min].GetSessionID()) < 0)
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

        private void Swap(int x, int y)
        {
            Session temp = sessions[x];
            sessions[x] = sessions[y];
            sessions[y] = temp;
        }

        public void Save()
        {            
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Session.GetCount(); i++)
            {
                outFile.WriteLine(sessions[i].ToFile());
            }

            outFile.Close();
        }
    }
}