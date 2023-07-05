namespace Store
{
    public class StoreModel
    {

        private float baseStoreCost;
        private int storeCount;
        private float baseStoreProfit;

        public float BaseStoreCost
        {
            get => baseStoreCost;
            set => baseStoreCost = value;
        }

        public int StoreCount
        {
            get => storeCount;
            set => storeCount = value;
        }

        public float BaseStoreProfit
        {
            get => baseStoreProfit;
            set => baseStoreProfit = value;
        }

        public StoreModel(float baseCost, int count, float baseProfit)
        {
            baseStoreCost = baseCost;
            storeCount = count;
            baseStoreProfit = baseProfit;
        }

        public void AddStore()
        {
            storeCount++;
        }
    }
}