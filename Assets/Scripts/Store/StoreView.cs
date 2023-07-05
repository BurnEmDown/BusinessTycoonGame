using TMPro;
using UnityEngine.UI;

namespace Store
{
    public class StoreView
    {
        private Button storeBuyButton;
        private TMP_Text storeCountText;
        private TMP_Text storeCostText;
        private Slider storeIncomeSlider;

        public StoreView(Button buyButton, TMP_Text countText, TMP_Text priceText, Slider incomeSlider)
        {
            storeBuyButton = buyButton;
            storeCountText = countText;
            storeCostText = priceText;
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
    }
}