namespace MyQueue.Contract
{
    public class ReallyAwesomeMessage
    {
        public ReallyAwesomeMessage(string superDuper)
        {
            SuperDuper = superDuper;
        }

        public string SuperDuper { get; private set; }
    }
}
