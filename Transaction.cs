namespace mis_221_pa_5_jkjohnson13
{
    public class Transaction
    {
        private int bookingID;
        private  int sessionID; 
        private string customerName;
        private string email;
        private string date;
        private int trainerID;
        private string trainerName;
        private string status;
        private static int count;

       

        private Transaction[] TransactionInfo = new Transaction[100];

        public Transaction()
        {

        }
        //constructor
        public Transaction(int bookingID, int sessionID, string customerName, string email, string date, int trainerID, string trainerName, string status)
        {
            this.bookingID = bookingID;
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.email = email;
            this.date = date;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        
        public void SetBookingID(int bookingID)
        {
            this.bookingID = bookingID;
        }
        public int GetBookingID()
        {
            return bookingID;
        }
        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }
        public int GetSessionID()
        {
            return sessionID;
        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }
        public string GetDate()
        {
            return date;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public int GetTrainerID()
        {
            return trainerID;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
        public string GetStatus()
        {
            return status;
        }
        public static void SetCount(int count)
        {
            Transaction.count = count;
        }
        public static int GetCount()
        {
            return Transaction.count;
        }
        public static void IncCount()
        {
            count++;
        }
        

        //List of Transactions
        public override string ToString()
        {
            return $"{bookingID.ToString().PadRight(2)} | Session ID: {sessionID.ToString().PadRight(2)} | {customerName.PadRight(15)} | {email.PadRight(26)} | {date.PadRight(10)} | {trainerID}: {trainerName.PadRight(15)} | {status}";
        }
        public string ToFile()
        {
            return bookingID + "#" + sessionID + "#" + customerName + "#" + email + "#" + date + "#" + trainerID + "#" + trainerName+ "#" + status;
        }
    }
}