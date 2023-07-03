using System;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    private float currentBalance;

    private float baseStoreCost;
    private int storeCount;
    private float baseStoreProfit;
    [SerializeField] private TMP_Text storeCountText;

    [SerializeField] private TMP_Text currentBalanceText;

    private float incomeTimer = 4f;
    private float currentIncomeTime = 0;
    private bool startTimer;

    private void Start()
    {
        storeCount = 1;
        currentBalance = 2;
        baseStoreCost = 1.5f;
        baseStoreProfit = 0.5f;
        storeCountText.text = storeCount.ToString();
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
                currentBalance += baseStoreProfit * storeCount;
                UpdateCurrentBalanceUI();
            }
        }
    }

    public void BuyStoreOnClick()
    {
        Debug.Log(currentBalance);
        if (currentBalance < baseStoreCost) return;

        currentBalance -= baseStoreCost;
        UpdateCurrentBalanceUI();

        storeCount++;
        storeCountText.text = storeCount.ToString();
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
