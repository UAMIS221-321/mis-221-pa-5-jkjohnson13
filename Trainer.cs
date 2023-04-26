namespace mis_221_pa_5_jkjohnson13
{
    public class Trainer
    {
        private  int trainerID; 
        private string name;
        private string mailingAddress;
        private string emailAddress;
        private string active;
        private static int count;
        private static int maxID;

       

        private Trainer[] trainerInfo = new Trainer[100];

        public Trainer()
        {

        }
        //constructor
        public Trainer(int trainerID, string name, string mailingAddress, string emailAddress, string active)
        {
            this.trainerID = trainerID;
            this.name = name;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
            this.active = active;
        }

        
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public void SetMailingAddress(string mailingAddress)
        {
            this.mailingAddress = mailingAddress;
        }
        public string GetMailingAddress()
        {
            return mailingAddress;
        }
        public void SetEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }
        public string GetEmailAddress()
        {
            return emailAddress;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public int GetTrainerID()
        {
            return trainerID;
        }
        public void SetActive(string active)
        {
            this.active = active;
        }
        public string GetActive()
        {
            return active;
        }
        public static void SetCount(int count)
        {
            Trainer.count = count;
        }
        public static int GetCount()
        {
            return Trainer.count;
        }
        public static void IncCount()
        {
            count++;
        }
        public static void SetMaxID(int maxID)
        {
            Trainer.maxID = maxID;
        }
        public static int GetMaxID()
        {
            return Trainer.maxID;
        }
        public static void IncMaxID()
        {
            maxID++;
        }
        

        public string PlayerList() //List of trainers
        {
            return $"{trainerID}\t{name}\t{mailingAddress}\t{emailAddress}\t{active}";
        }
        public override string ToString()
        {
            return $"{trainerID.ToString().PadRight(2)} | {name.PadRight(15)} | {mailingAddress.PadRight(23)} | {emailAddress.PadRight(26)} | {active}";
        }
        public string ToFile()
        {
            return trainerID + "#" + name + "#" + mailingAddress + "#" + emailAddress + "#" + active;
        }


    }
}