using System.Xml;
using Balance;
using Managers;
using Store;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    [SerializeField] private GameObject storePrefab;
    [SerializeField] private GameObject storePanel;
    
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
            }
        }
        
        return data;
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
