namespace mis_221_pa_5_jkjohnson13
{
    public class Session
    {
        private  int sessionID; 
        private string trainerName;
        private string date;
        private string time;
        private double cost;
        private string available;
        private static int count;
        private static int maxID;

       

        private Session[] SessionInfo = new Session[100];

        public Session()
        {

        }
        //constructor
        public Session(int sessionID, string trainerName, string date, string time, double cost, string available)
        {
            this.sessionID = sessionID;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.available = available;
        }

        
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }
        public string GetDate()
        {
            return date;
        }
        public void SetTime(string time)
        {
            this.time = time;
        }
        public string GetTime()
        {
            return time;
        }
        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }
        public int GetSessionID()
        {
            return sessionID;
        }
        public void SetCost(double cost)
        {
            this.cost = cost;
        }
        public double GetCost()
        {
            return cost;
        }
        public void SetAvailable(string available)
        {
            this.available = available;
        }
        public string GetAvailable()
        {
            return available;
        }
        public static void SetCount(int count)
        {
            Session.count = count;
        }
        public static int GetCount()
        {
            return Session.count;
        }
        public static void IncCount()
        {
            count++;
        }
        public static void SetMaxID(int maxID)
        {
            Session.maxID = maxID;
        }
        public static int GetMaxID()
        {
            return Session.maxID;
        }
        public static void IncMaxID()
        {
            maxID++;
        }
        

        public string PlayerList() //List of Sessions
        {
            return $"{sessionID}\t{trainerName}\t{date}\t{time}\t${cost.ToString("#.##")}\t{available}";
        }
        public override string ToString()
        {
            return $"{sessionID.ToString().PadRight(2)} | {trainerName.PadRight(15)} | {date.PadRight(23)} | {time.PadRight(26)} | ${cost.ToString("#.##").PadRight(5)} | {available}";
        }
        public string ToFile()
        {
            return sessionID + "#" + trainerName + "#" + date + "#" + time + "#" + cost.ToString("#.##") + "#" + available;
        }


    }
}