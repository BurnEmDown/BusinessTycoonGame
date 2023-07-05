namespace Store
{
    public class StoreModel
    {

        private float baseStoreCost;
        private int storeCount;
        private float baseStoreProfit;
        private float incomeTimer;
        private bool managerUnlocked;

        public float BaseStoreCost
        {
            get => baseStoreCost;
        }

        public int StoreCount
        {
            get => storeCount;
        }

        public float BaseStoreProfit
        {
            get => baseStoreProfit;
        }

        public float IncomeTimer => incomeTimer;

        public bool ManagerUnlocked => managerUnlocked;

        public StoreModel(float baseCost, int count, float baseProfit, float incomeTime)
        {
            baseStoreCost = baseCost;
            storeCount = count;
            baseStoreProfit = baseProfit;
            incomeTimer = incomeTime;
        }

        public void AddStore()
        {
            storeCount++;
        }

        public void UnlockManager()
        {
            managerUnlocked = true;
        }
    }
}