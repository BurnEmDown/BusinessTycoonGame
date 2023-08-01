using System.Xml;
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

        XmlNodeList StoreList = xmlDocument.GetElementsByTagName("store");

        foreach (XmlNode storeInfo in StoreList)
        {
            GameObject newStore = Instantiate(storePrefab);

            StoreController storeObj = newStore.GetComponent<StoreController>();
            StoreData data = new StoreData();
            
            XmlNodeList storeNodes = storeInfo.ChildNodes;
            foreach (XmlNode storeNode in storeNodes)
            {
                Debug.Log(storeNode.Name);
                Debug.Log(storeNode.InnerText);
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
                    case "IncomeTime":
                        data.incomeTime = float.Parse(storeNode.InnerText);
                        break;
                    case "StoreMultiplier":
                        data.storeMultiplier = float.Parse(storeNode.InnerText);
                        break;
                }
            }
            
            storeObj.transform.SetParent(storePanel.transform);
            storeObj.Init(data);
        }
    }
}
