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
        
        [SerializeField] private TMP_Text storeCountText;
        [SerializeField] private Slider incomeSlider;

        private float incomeTimer = 4f;
        private float currentIncomeTime = 0;
        private bool startTimer;

        private void Start()
        {
            model = new StoreModel(1.5f, 1, 0.5f);
            view = new StoreView(storeCountText, incomeSlider);
            view.UpdateStoreCountText(model.StoreCount);
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
                    GameManager.Instance.AddBalance(model.BaseStoreProfit * model.StoreCount);
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
            Debug.Log(GameManager.Instance.CurrentBalance);
            if (GameManager.Instance.CanBuy(model.BaseStoreCost)) return;
            
            GameManager.Instance.RemoveBalance(model.BaseStoreCost);

            model.AddStore();
            view.UpdateStoreCountText(model.StoreCount);
        }

        public void StoreOnClick()
        {
            if (startTimer) return;
        
            startTimer = true;
            currentIncomeTime = 0f;
        }
    }
}
