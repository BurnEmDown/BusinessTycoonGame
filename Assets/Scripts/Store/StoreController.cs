using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Store
{
    public class StoreController : MonoBehaviour
    {
        private float currentBalance;

        private StoreModel model;
        private StoreView view;
        
        [SerializeField] private TMP_Text storeCountText;
        [SerializeField] private TMP_Text currentBalanceText;
        [SerializeField] private Slider incomeSlider;

        private float incomeTimer = 4f;
        private float currentIncomeTime = 0;
        private bool startTimer;

        private void Start()
        {
            model = new StoreModel(1.5f, 1, 0.5f);
            view = new StoreView(storeCountText, incomeSlider);
            currentBalance = 2;
            view.UpdateStoreCountText(model.StoreCount);
            UpdateCurrentBalanceUI();
        }

        private void Update()
        {
            if (startTimer)
            {
                currentIncomeTime += Time.deltaTime;
                if (currentIncomeTime > incomeTimer)
                {
                    startTimer = false;
                    currentIncomeTime = 0f;
                    currentBalance += model.BaseStoreProfit * model.StoreCount;
                    UpdateCurrentBalanceUI();
                }

            
            }
        
            UpdateIncomeSlider();
        }

        private void UpdateIncomeSlider()
        {
            incomeSlider.value = currentIncomeTime / incomeTimer;
        }

        public void BuyStoreOnClick()
        {
            Debug.Log(currentBalance);
            if (currentBalance < model.BaseStoreCost) return;

            currentBalance -= model.BaseStoreCost;
            UpdateCurrentBalanceUI();

            model.AddStore();
            view.UpdateStoreCountText(model.StoreCount);
        }

        private void UpdateCurrentBalanceUI()
        {
            currentBalanceText.text = "$" + $"{currentBalance:0.00}";
        }

        public void StoreOnClick()
        {
            if (startTimer) return;
        
            startTimer = true;
            currentIncomeTime = 0f;
        }
    }
}