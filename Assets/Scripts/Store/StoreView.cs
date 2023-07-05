using TMPro;
using UnityEngine.UI;

namespace Store
{
    public class StoreView
    {
        private TMP_Text storeCountText;
        private TMP_Text storeCostText;
        private Slider storeIncomeSlider;

        public StoreView(TMP_Text countText, TMP_Text priceText, Slider incomeSlider)
        {
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
    }
}