using System.Xml;
using Balance;
using Managers;
using Store;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameData : MonoBehaviour
{
    [SerializeField] private GameObject storePrefab;
    [SerializeField] private GameObject storePanel;
    
    [SerializeField] private GameObject managerPrefab;
    [SerializeField] private GameObject managerPanel;
    
    public TextAsset GameData;

    public void Start()
    {
        Invoke(nameof(LoadData), 0.1f);
    }
    
    public void LoadData()
    {
        XmlDocument xmlDocument = new XmlDocument();
        
        xmlDocument.LoadXml(GameData.text);

        SetStartingBalance(xmlDocument);
        SetCompanyName(xmlDocument);
        
        XmlNodeList StoreList = xmlDocument.GetElementsByTagName("store");

        foreach (XmlNode storeInfo in StoreList)
        {
            LoadStore(storeInfo);
        }
    }

    private void LoadManagerNodes(XmlNode storeInfo)
    {
        
    }

    private void LoadStore(XmlNode storeInfo)
    {
        GameObject newStore = Instantiate(storePrefab);

        StoreController storeObj = newStore.GetComponent<StoreController>();
            
        XmlNodeList storeNodes = storeInfo.ChildNodes;
        StoreData data = GetDataFromStoreNode(storeNodes);
            
        storeObj.transform.SetParent(storePanel.transform);
        storeObj.Init(data);
    }

    private StoreData GetDataFromStoreNode(XmlNodeList storeNodes)
    {
        StoreData data = new();

        foreach (XmlNode storeNode in storeNodes)
        {
            switch (storeNode.Name)
            {
                case "StoreName":
                    data.storeName = storeNode.InnerText;
                    break;
                case "BaseStoreProfit":
                    data.baseStoreProfit = float.Parse(storeNode.InnerText);
                    break;
                case "BaseStoreCost":
                    data.baseStoreCost = float.Parse(storeNode.InnerText);
                    break;
                case "StoreCount":
                    data.storeCount = int.Parse(storeNode.InnerText);
                    break;
                case "IncomeTimer":
                    data.incomeTime = float.Parse(storeNode.InnerText);
                    break;
                case "StoreMultiplier":
                    data.storeMultiplier = float.Parse(storeNode.InnerText);
                    break;
                case "Image":
                    Sprite newSprite = Resources.Load<Sprite>(storeNode.InnerText);
                    data.image = newSprite;
                    break;
                case "ManagerCost":
                    CreateManager(data.storeName, storeNode.InnerText);
                    break;
            }
        }
        
        return data;
    }

    private void CreateManager(string storeName, string cost)
    {
        GameObject newManager = Instantiate(managerPrefab);
        newManager.transform.SetParent(managerPanel.transform);
        
        // this is a bad way to do this and some errors might occur when the store name sent is empty
        TMP_Text managerText = newManager.transform.Find("ManagerNameText").GetComponent<TMP_Text>();
        managerText.text = storeName;

        Button unlockButton = newManager.transform.Find("UnlockManagerButton").GetComponent<Button>();
        
        TMP_Text unlockButtonText = unlockButton.transform.Find("UnlockManagerButtonText").GetComponent<TMP_Text>();
        unlockButtonText.text = "Unlock $" + cost;
    }

    private void SetCompanyName(XmlDocument xmlDocument)
    {
        XmlNodeList companyNameNode = xmlDocument.GetElementsByTagName("CompanyName");
        string companyName = companyNameNode[0].InnerText;
        GameManager.Instance.UpdateCompanyName(companyName);
    }

    private static void SetStartingBalance(XmlDocument xmlDocument)
    {
        XmlNodeList startingBalanceNode = xmlDocument.GetElementsByTagName("StartingBalance");
        float startingBalance = float.Parse(startingBalanceNode[0].InnerText);
        BalanceController.Instance.AddBalance(startingBalance);
    }
}
