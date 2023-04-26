namespace mis_221_pa_5_jkjohnson13
{
    public class Report
    {
        Trainer[] trainers;
        Session[] sessions;

        public Report(Trainer[] trainers, Session[] sessions)
        {
            this.trainers = trainers;
            this.sessions = sessions;
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


        //*********TRANSACTION REPORTS*********
    }
}