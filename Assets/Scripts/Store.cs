using System;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    private float currentBalance;

    private float baseStoreCost;
    private int storeCount;
    [SerializeField] private TMP_Text storeCountText;

    [SerializeField] private TMP_Text currentBalanceText;

    private void Start()
    {
        storeCount = 1;
        currentBalance = 2;
        baseStoreCost = 1.5f;
        storeCountText.text = storeCount.ToString();
        UpdateCurrentBalance(currentBalance);
    }

    public void BuyStoreOnClick()
    {
        Debug.Log(currentBalance);
        if (currentBalance < baseStoreCost) return;

        currentBalance -= baseStoreCost;
        UpdateCurrentBalance(currentBalance);

        storeCount++;
        storeCountText.text = storeCount.ToString();
    }

    private void UpdateCurrentBalance(float newBalance)
    {
        currentBalanceText.text = "$" + $"{newBalance:0.00}";
    }
}
