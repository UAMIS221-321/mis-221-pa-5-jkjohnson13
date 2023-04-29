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
            // string endTime = specificTime.AddHours(1).ToShortTimeString();
            mySession.SetTime($"{startTime}");

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
                Edit(searchID);
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

        public void Edit(int searchID)
        {
            string choice = ""; //To enter the choice
            
            while(choice != "5")
            {
                Console.WriteLine("\nWould you like to change the...\n(1) Trainer Name\n(2) Date\n(3) Time\n(4) Cost\n(5) Back to Listing Data\n"); //Main Menu options displayed
                choice = Console.ReadLine(); //This will take their selection 
                
                if(choice == "1")
                {
                    Console.Write("Change current trainer name to: ");
                    sessions[searchID].SetTrainerName(Console.ReadLine());
                    choice = "5";
                }
                else if (choice == "2") 
                {
                    Console.Write("Change current date to (mm/dd/yyyy): ");
                    DateTime specificDate = DateTime.Parse(Console.ReadLine());
                    string date = specificDate.ToShortDateString();
                    sessions[searchID].SetDate(date);
                    choice = "5";
                }
                else if(choice == "3") 
                {
                    Console.Write("Change current time to (ex. 12:30 pm): ");
                    DateTime specificTime = DateTime.Parse(Console.ReadLine());
                    string startTime = specificTime.ToShortTimeString();
                    sessions[searchID].SetTime($"{startTime}");
                    choice = "5";
                }
                else if(choice == "4") 
                {
                    Console.Write("Change current cost to: ");
                    sessions[searchID].SetCost(double.Parse(Console.ReadLine()));
                    choice = "5";
                }
                else if(choice == "5") 
                {
                    //to exit menu
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select one of the options");
                }
            }
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