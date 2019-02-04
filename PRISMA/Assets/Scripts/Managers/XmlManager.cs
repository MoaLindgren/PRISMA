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
    int dialogueCounter, gameRound;
    MenuManager menuManager;

    bool item;
    string stationName;
    int index;

    void Start()
    {
        menuManager = GetComponent<MenuManager>();
        //SetUpXML();
    }

    public void SetUpXML(bool newItem, string name, int itemIndex)
    {
        //gameRound = gameRoundIndex;
        //index = stationIndex;
        dialogueCounter = 0;

        item = newItem;
        stationName = name;
        index = itemIndex;



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
        //Dialogue(false, true);
    }
    public void Dialogue(/*bool newItem, string name, int itemIndex*/)
    {
        nodeList = doc.GetElementsByTagName("Root");

        foreach (XmlNode rootNode in nodeList)
        {
            foreach (XmlNode node in rootNode)
            {
                if(node.Name == name)
                {
                    menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);
                }




                //if (!newItem)
                //{

                //    if (node.Name == name)
                //    {

                //        menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);
                //        dialogueCounter += 1;
                //    }
                //}
                //else
                //{

                //    if (node.Name == "Items")
                //    {
                //        print("uh");
                //        menuManager.ViewDialogue(node.Attributes[index].Value, true);
                //    }
                //}
            }
        }

        dialogueCounter++;
    }
    //public void Dialogue(bool item, bool win)
    //{
    //    nodeList = doc.GetElementsByTagName("Root");

    //    foreach (XmlNode rootNode in nodeList)
    //    {
    //        foreach (XmlNode roundNode in rootNode)
    //        {
    //            if (roundNode.Name == "Game" + gameRound.ToString())
    //            {
    //                foreach (XmlNode minigameNode in roundNode)
    //                {
    //                    if (!item)
    //                    {
    //                        if (minigameNode.Name == "Station" + index.ToString())
    //                        {

    //                            if (win)
    //                            {
    //                                menuManager.ViewDialogue(minigameNode.Attributes[dialogueCounter].Value, false);
    //                                dialogueCounter += 1;
    //                            }
    //                            else
    //                            {
    //                                dialogueCounter += 2;
    //                                menuManager.ViewDialogue(minigameNode.Attributes[dialogueCounter].Value, false);
    //                                dialogueCounter += 1;
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        if (minigameNode.Name == "Items")
    //                        {
    //                            print("hej");
    //                            menuManager.ViewDialogue(minigameNode.Attributes[index].Value, true);
    //                        }
    //                    }
    //                }
    //            }


    //        }
    //    }

    //}

}
