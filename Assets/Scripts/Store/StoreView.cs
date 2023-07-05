using TMPro;
using UnityEngine.UI;

namespace Store
{
    public class StoreView
    {
        private TMP_Text storeCountText;
        private Slider storeIncomeSlider;

        public TMP_Text StoreCountText
        {
            get => storeCountText;
            set => storeCountText = value;
        }

        public Slider StoreIncomeSlider
        {
            get => storeIncomeSlider;
            set => storeIncomeSlider = value;
        }

        public StoreView(TMP_Text countText, Slider incomeSlider)
        {
            storeCountText = countText;
            storeIncomeSlider = incomeSlider;
        }

        public void UpdateStoreCountText(int count)
        {
            storeCountText.text = count.ToString();
        }
    }
}