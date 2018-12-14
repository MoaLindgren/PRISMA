using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XmlManager : MonoBehaviour
{
    string filePath;
    XmlDocument doc;
    XmlNodeList nodeList;
    TextAsset path;
    XmlWriter writer;
    int dialogueCounter, index;
    MenuManager menuManager;


    void Start()
    {
        menuManager = GetComponent<MenuManager>();
    }

    public void SetUpXML(int stationIndex)
    {
        index = stationIndex;
        dialogueCounter = 0;
        doc = new XmlDocument();

        filePath = Application.dataPath + "/Resources/Dialogues.xml";
        path = Resources.Load("Dialogues") as TextAsset;
        doc.LoadXml(path.text);

        filePath = Application.persistentDataPath + "/Dialogues.xml";
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        using (writer = XmlWriter.Create(Application.persistentDataPath + "/Dialogues.xml", settings))
        {
            doc.Save(writer);
        }
        print(filePath);
        Dialogue();
    }

    public void Dialogue()
    {
        nodeList = doc.GetElementsByTagName("MiniGames");

        foreach (XmlNode games in nodeList)
        {
            foreach (XmlNode miniGame in games)
            {

                if (miniGame.Name == "MiniGame" + index.ToString())
                {
                    print("hej");
                    menuManager.ViewDialogue(miniGame.Attributes[dialogueCounter].Value);
                }

            }
        }
        dialogueCounter += 1;
    }

}
