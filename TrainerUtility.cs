namespace mis_221_pa_5_jkjohnson13
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        //constructor
        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public Trainer[] GetTrainerInfo()
        {
            //open
            StreamReader inFile = new StreamReader("trainer.txt");

            //process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4]);
                Trainer.IncCount();
                
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
            return trainers;
        }

        public void AddTrainer()
        {
            Console.Clear();
            
            Trainer myTrainer = new Trainer();

            int maxID = MaxID();
            myTrainer.SetTrainerID(maxID + 1);

            myTrainer.SetActive("Active");

            System.Console.Write("Enter the trainers name: ");
            myTrainer.SetName(Console.ReadLine());

            myTrainer.SetTrainerID(maxID + 1);

            System.Console.Write("Enter Mailing Address: ");
            myTrainer.SetMailingAddress(Console.ReadLine());

            System.Console.Write("Enter Email Address: ");
            myTrainer.SetEmailAddress(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;

            Trainer.IncCount();
            Trainer.IncMaxID();

            Save();

        }

        public void Search()
        {
            Console.Write("Enter ID: ");
            int searchVal = int.Parse(Console.ReadLine());
            int searchID = BinarySearch(searchVal);

            if(searchID == -1)
            {
                Console.WriteLine("\nTrainer does not exist\n\n");
            }
            else
            {
                Edit(searchID);
                Save();
            }
        }

        public int BinarySearch(int searchVal)
        {
            System.Console.WriteLine(Trainer.GetCount());
            
            int min = 0;
            int max = Trainer.GetCount() - 1;
            int mid = (max + min)/2;

            while(min <= max)
            {
                if(searchVal == trainers[mid].GetTrainerID())
                {
                    return mid;
                }
                if(searchVal < trainers[mid].GetTrainerID())
                {
                    mid = min + 1;
                }
                else
                {
                    mid = max - 1;
                }
            }

            return -1;
        }

        public void Edit(int searchID)
        {
            string choice = ""; //To enter the choice
            
            while(choice != "5")
            {
                Console.WriteLine("\nWould you like to change the...\n(1) Trainer Name\n(2) Mailing Address\n(3) Email Address\n(4) Trainer Status?\n(5) Back to Trainer Data\n"); //Main Menu options displayed
                choice = Console.ReadLine(); //This will take their selection 
                
                if (choice == "1") 
                {
                    Console.Write("Change current trainer name to:");
                    trainers[searchID].SetName(Console.ReadLine());
                    choice = "5";
                }
                else if(choice == "2") 
                {
                    Console.Write("Change current mailing address to: ");
                    trainers[searchID].SetMailingAddress(Console.ReadLine());
                    choice = "5";
                }
                else if(choice == "3") 
                {
                    Console.Write("Change current email address to: ");
                    trainers[searchID].SetEmailAddress(Console.ReadLine());
                    choice = "5";
                }
                else if(choice == "4") 
                {
                    Console.WriteLine("Activate -> A\nDeactivate -> D");
                    trainers[searchID].SetActive(Status(Console.ReadLine()));
                    choice = "5";
                }
                else if(choice == "5") 
                {
                    //To exit the system
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select one of the options");
                }
            }
        }

        public int MaxID()
        {
            Sort();
            int max = 0;

            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetTrainerID() > max)
                {
                    max = trainers[i].GetTrainerID();
                }
            }
            return max;
        }

        public void Sort()
        {
            for(int i = 0; i < Trainer.GetCount() - 1; i++)
            {
                int min = i;

                for(int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    if(trainers[j].GetTrainerID().CompareTo(trainers[min].GetTrainerID()) < 0)
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
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }
        public void Save()
        {            
            StreamWriter outFile = new StreamWriter("trainer.txt");

            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        //*********OTHER METHODS*********
        public string Status(string input)
        {
            if(input.ToUpper() == "D")
            {
                return "Inactive";
            }
            return "Active";
        }
    }
}