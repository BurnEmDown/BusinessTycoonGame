using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private float currentBalance;
        
        [SerializeField] private TMP_Text currentBalanceText;

        public float CurrentBalance => currentBalance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
                
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            currentBalance = 2;
            UpdateCurrentBalanceUI();
        }

        public void AddBalance(float addBalance)
        {
            if(addBalance >= 0)
                currentBalance = CurrentBalance + addBalance;

            UpdateCurrentBalanceUI();
        }

        public void RemoveBalance(float removeBalance)
        {
            if (removeBalance >= 0)
                currentBalance = CurrentBalance - removeBalance;

            UpdateCurrentBalanceUI();
        }
        
        private void UpdateCurrentBalanceUI()
        {
            currentBalanceText.text = "$" + $"{CurrentBalance:0.00}";
        }

        public bool CanBuy(float amount)
        {
            return amount <= currentBalance;
        }
    }
}