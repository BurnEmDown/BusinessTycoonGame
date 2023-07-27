using System.Xml;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
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
            XmlNodeList storeNodes = storeInfo.ChildNodes;
            foreach (XmlNode storeNode in storeNodes)
            {
                Debug.Log(storeNode.Name);
                Debug.Log(storeNode.InnerText);
            }
        }
    }
}
