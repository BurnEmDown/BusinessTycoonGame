using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Store
{
    public class StoreController : MonoBehaviour
    {
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
        
        private float currentIncomeTime = 0;
        private bool startTimer;

        private void Start()
        {
            model = new StoreModel(baseStoreCost, 0, baseStoreProfit, baseStoreIncomeTime, storeMultiplier);
            view = new StoreView(storeBuyButton, storeCountText, storePriceText, incomeSlider);
            view.UpdateStoreCountText(model.StoreCount);
            view.UpdateStoreCostText(model.BaseStoreCost);
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
                    GameManager.Instance.AddBalance(model.BaseStoreProfit * model.StoreCount);
                }

            }
        
            UpdateIncomeSlider();
            CheckStoreBuy();
        }

        private void UpdateIncomeSlider()
        {
            view.UpdateIncomeSlider(currentIncomeTime / model.IncomeTimer);
        }

        public void CheckStoreBuy()
        {
            if (GameManager.Instance.CanBuy(model.NextStoreCost))
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
            Debug.Log(GameManager.Instance.CurrentBalance);
            if (!GameManager.Instance.CanBuy(model.NextStoreCost)) return;
            
            GameManager.Instance.RemoveBalance(model.NextStoreCost);

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
