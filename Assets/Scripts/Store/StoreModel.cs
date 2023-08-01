using System;
using UnityEngine;

namespace Store
{
    public class StoreModel
    {

        private float baseStoreCost;
        private int storeCount;
        private float baseStoreProfit;
        private float incomeTimer;
        private bool managerUnlocked;
        private float nextStoreCost;
        private float storeMultiplier;
        private bool storeUnlocked;
        private string storeName;

        public float BaseStoreCost
        {
            get => baseStoreCost;
            private set => baseStoreCost = value;
        }

        public int StoreCount
        {
            get => storeCount;
            private set => storeCount = value;
        }

        public float BaseStoreProfit
        {
            get => baseStoreProfit;
            private set => baseStoreProfit = value;
        }

        public float IncomeTimer
        {
            get => incomeTimer;
            private set => incomeTimer = value;
        }

        public bool ManagerUnlocked => managerUnlocked;
        public float NextStoreCost
        {
            get => nextStoreCost;
            private set => nextStoreCost = value;
        }

        public bool StoreUnlocked
        {
            get => storeUnlocked;
            private set => storeUnlocked = value;
        }

        public float StoreMultiplier
        {
            get => storeMultiplier;
            private set => storeMultiplier = value;
        }

        public string StoreName
        {
            get => storeName;
            private set => storeName = value;
        }

        public StoreModel(float baseCost, int count, float baseProfit, float incomeTime, float multiplier, string name)
        {
            BaseStoreCost = baseCost;
            NextStoreCost = baseCost;
            StoreCount = count;
            BaseStoreProfit = baseProfit;
            IncomeTimer = incomeTime;
            StoreMultiplier = multiplier;
            StoreName = name;
        }

        public void AddStore()
        {
            storeCount++;
        }

        public void UnlockManager()
        {
            managerUnlocked = true;
        }

        public void UpdateNextStoreCost()
        {
            nextStoreCost = (BaseStoreCost * Mathf.Pow(StoreMultiplier, storeCount));
            nextStoreCost = (float)Math.Round(nextStoreCost, 2);
        }
        
        public void UnlockStore()
        {
            StoreUnlocked = true;
        }
    }
}