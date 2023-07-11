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
            balance += addBalance;
        }

        public void RemoveBalance(float removeBalance)
        {
            balance -= removeBalance;
        }
    }
}