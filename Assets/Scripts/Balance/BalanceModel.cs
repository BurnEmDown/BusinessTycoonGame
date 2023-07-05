namespace Balance
{
    public class BalanceModel
    {
        private float balance;

        public float Balance
        {
            get => balance;
        }
        
        public void AddBalance(float addBalance)
        {
            if(addBalance >= 0)
                balance += addBalance;
        }

        public void RemoveBalance(float removeBalance)
        {
            if (removeBalance >= 0)
                balance -= removeBalance;
        }
    }
}