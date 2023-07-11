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
        [SerializeField] private Slider incomeSlider;

        [SerializeField] private float baseStoreCost;
        [SerializeField] private float baseStoreProfit;
        [SerializeField] private float baseStoreIncomeTime;
        [SerializeField] private float storeMultiplier;

        private CanvasGroup cg;
        
        private float currentIncomeTime = 0;
        private bool startTimer;

        private bool storeUnlocked;

        private void Start()
        {
            model = new StoreModel(baseStoreCost, 0, baseStoreProfit, baseStoreIncomeTime, storeMultiplier);
            view = new StoreView(storeBuyButton, storeCountText, storePriceText, incomeSlider);
            view.UpdateStoreCountText(model.StoreCount);
            view.UpdateStoreCostText(model.BaseStoreCost);
            cg = transform.GetComponent<CanvasGroup>();
        }

        private void Update()
        {
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
            if(storeUnlocked)
                CheckStoreBuy();
        }

        private void UpdateIncomeSlider()
        {
            view.UpdateIncomeSlider(currentIncomeTime / model.IncomeTimer);
        }

        private void CheckStoreUnlock()
        {
            if (!storeUnlocked && !balanceController.CanBuy(model.NextStoreCost))
            {
                cg.alpha = 0.5f;
                cg.interactable = false;
            }
            else
            {
                storeUnlocked = true;
                cg.alpha = 1;
                cg.interactable = true;
            }
        }

        private void CheckStoreBuy()
        {
            if (!storeUnlocked && !balanceController.CanBuy(model.NextStoreCost))
            {
                storeUnlocked = true;
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
