using System;
using Balance;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Store
{
    public class StoreController : MonoBehaviour
    {
        private GameManager gameManager => GameManager.Instance;
        private BalanceController balanceController => BalanceController.Instance;

        private StoreModel model;
        private StoreView view;

        [SerializeField] private Button storeBuyButton;
        [SerializeField] private TMP_Text storeCountText;
        [SerializeField] private TMP_Text storePriceText;
        [SerializeField] private TMP_Text storeNameText;
        [SerializeField] private Slider incomeSlider;

        [SerializeField] private float baseStoreCost;
        [SerializeField] private float baseStoreProfit;
        [SerializeField] private float baseStoreIncomeTime;
        [SerializeField] private float storeMultiplier;
        [SerializeField] private string storeName;

        private CanvasGroup cg;
        
        private float currentIncomeTime = 0;
        private bool startTimer;

        private bool storeInitialized;

        private void Start()
        {
            cg = transform.GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (!storeInitialized) return;
            
            if (startTimer)
            {
                currentIncomeTime += Time.deltaTime;
                if (currentIncomeTime > model.IncomeTimer)
                {
                    if(!model.ManagerUnlocked)
                        startTimer = false;
                    currentIncomeTime = 0f;
                    balanceController.AddBalance(model.BaseStoreProfit * model.StoreCount);
                }

            }
        
            UpdateIncomeSlider();
            CheckStoreUnlock();
            if(model.StoreUnlocked)
                CheckStoreBuy();
        }

        public void Init(StoreData data)
        {
            model = new StoreModel(data.baseStoreCost, data.storeCount, data.baseStoreProfit, data.incomeTime, data.storeMultiplier, data.storeName);
            view = new StoreView(storeBuyButton, storeCountText, storePriceText, storeNameText, incomeSlider);
            view.UpdateStoreCountText(model.StoreCount);
            view.UpdateStoreCostText(model.BaseStoreCost);
            view.UpdateStoreNameText(model.StoreName);
            
            storeInitialized = true;
        }

        private void UpdateIncomeSlider()
        {
            view.UpdateIncomeSlider(currentIncomeTime / model.IncomeTimer);
        }

        private void CheckStoreUnlock()
        {
            if (!model.StoreUnlocked && !balanceController.CanBuy(model.NextStoreCost))
            {
                view.LockStore(cg);
            }
            else
            {
                view.UnockStore(cg);
                model.UnlockStore();
            }
        }

        private void CheckStoreBuy()
        {
            if (!model.StoreUnlocked && !balanceController.CanBuy(model.NextStoreCost))
            {
                model.UnlockStore();
            }
            
            if (balanceController.CanBuy(model.NextStoreCost))
            {
                view.EnableBuyButton();
            }
            else
            {
                view.DisableBuyButton();
            }
        }

        public void BuyStoreOnClick()
        {
            if (!balanceController.CanBuy(model.NextStoreCost)) return;
            
            balanceController.RemoveBalance(model.NextStoreCost);

            model.AddStore();
            model.UpdateNextStoreCost();
            view.UpdateStoreCountText(model.StoreCount);
            view.UpdateStoreCostText(model.NextStoreCost);
        }

        public void StoreOnClick()
        {
            if (startTimer || !(model.StoreCount > 0)) return;
        
            startTimer = true;
            currentIncomeTime = 0f;
        }
    }
}
