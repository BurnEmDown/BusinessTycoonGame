using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Balance
{
    public class BalanceController : MonoBehaviour
    {
        public static BalanceController Instance;
        private GameManager gameManager => GameManager.Instance;
        
        [SerializeField] private TMP_Text currentBalanceText;
        [SerializeField] private float startingBalance;

        private BalanceModel model;
        private BalanceView view;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            model = new BalanceModel();
            view = new BalanceView(currentBalanceText);
        }

        private void Start()
        {
            model.AddBalance(startingBalance);
            UpdateCurrentBalanceUI(model.Balance);
        }

        public void AddBalance(float addBalance)
        {
            if(addBalance >= 0)
                model.AddBalance(addBalance);
            
            UpdateCurrentBalanceUI(model.Balance);
        }

        public void RemoveBalance(float removeBalance)
        {
            if (removeBalance >= 0)
                model.RemoveBalance(removeBalance);

            UpdateCurrentBalanceUI(model.Balance);
        }
        
        private void UpdateCurrentBalanceUI(float balance)
        {
            view.UpdateBalanceUI(balance);
        }
        
        public bool CanBuy(float amount)
        {
            return model.Balance >= amount;
        }
    }
}