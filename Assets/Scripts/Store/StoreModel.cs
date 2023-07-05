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

        public float BaseStoreCost => baseStoreCost;
        public int StoreCount => storeCount;
        public float BaseStoreProfit => baseStoreProfit;
        public float IncomeTimer => incomeTimer;
        public bool ManagerUnlocked => managerUnlocked;
        public float NextStoreCost => nextStoreCost;

        public StoreModel(float baseCost, int count, float baseProfit, float incomeTime, float multiplier)
        {
            baseStoreCost = baseCost;
            nextStoreCost = baseCost;
            storeCount = count;
            baseStoreProfit = baseProfit;
            incomeTimer = incomeTime;
            storeMultiplier = multiplier;
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
            nextStoreCost = (BaseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
            nextStoreCost = (float)Math.Round(nextStoreCost, 2);
        }
    }
}