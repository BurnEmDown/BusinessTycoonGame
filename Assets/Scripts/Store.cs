using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    private int storeCount;
    [SerializeField] private TMP_Text storeCountText;

    private void Start()
    {
        storeCount = 1;
        storeCountText.text = storeCount.ToString();
    }

    public void BuyStoreOnClick()
    {
        storeCount++;
        storeCountText.text = storeCount.ToString();
    }
}
