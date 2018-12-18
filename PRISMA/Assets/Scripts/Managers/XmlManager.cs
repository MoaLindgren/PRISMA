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
        Dialogue(false, true);
    }

    public void Dialogue(bool item, bool win)
    {
        nodeList = doc.GetElementsByTagName("Root");

        print(index.ToString());
        foreach (XmlNode rootNode in nodeList)
        {
            foreach (XmlNode node in rootNode)
            {
                if(!item)
                {
                    if (node.Name == "MiniGame" + index.ToString())
                    {
                        if(win)
                        {
                            menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);
                            dialogueCounter += 1;
                        }
                        else
                        {
                            dialogueCounter += 2;
                            menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);
                            dialogueCounter += 1;
                        }
                    }
                }
                else
                {
                    if (node.Name == "Items")
                    {
                        menuManager.ViewDialogue(node.Attributes[index].Value, true);
                    }
                }


            }
        }

    }

}
