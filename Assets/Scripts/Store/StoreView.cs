using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Store
{
    public class StoreView
    {
        private Button storeBuyButton;
        private TMP_Text storeCountText;
        private TMP_Text storeCostText;
        private TMP_Text storeNameText;
        private Slider storeIncomeSlider;

        public StoreView(Button buyButton, TMP_Text countText, TMP_Text priceText, TMP_Text nameText, Slider incomeSlider)
        {
            storeBuyButton = buyButton;
            storeCountText = countText;
            storeCostText = priceText;
            storeNameText = nameText;
            storeIncomeSlider = incomeSlider;
        }

        public void UpdateStoreCountText(int count)
        {
            storeCountText.text = count.ToString();
        }

        public void UpdateStoreCostText(float amount)
        {
            storeCostText.text = "Buy $" + $"{amount:0.00}";
        }

        public void UpdateStoreNameText(string name)
        {
            storeNameText.text = name;
        }
        
        public void UpdateIncomeSlider(float value)
        {
            storeIncomeSlider.value = value;
        }

        public void EnableBuyButton()
        {
            storeBuyButton.interactable = true;
        }

        public void DisableBuyButton()
        {
            storeBuyButton.interactable = false;
        }

        public void LockStore(CanvasGroup cg)
        {
            cg.alpha = 0.5f;
            cg.interactable = false;
        }

        public void UnockStore(CanvasGroup cg)
        {
            cg.alpha = 1;
            cg.interactable = true;
        }
    }
}