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

    bool station, dialogueStarted;
    string name;
    int index;
    [SerializeField]
    float dialogueTimer;
    float timer;

    void Start()
    {
        timer = dialogueTimer;
        menuManager = GetComponent<MenuManager>();
        //SetUpXML();
    }

    public void SetUpXML(bool station, string name, int item)
    {
        //gameRound = gameRoundIndex;
        //index = stationIndex;
        dialogueCounter = 0;
        this.station = station;
        this.name = name;
        this.index = item;

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
        nodeList = doc.GetElementsByTagName("Root");

        foreach (XmlNode rootNode in nodeList)
        {
            foreach (XmlNode node in rootNode)
            {
                if(node.Name == name)
                {
                    if(node.Attributes[dialogueCounter].Value != "" || node.Attributes[dialogueCounter].Value != "finished")
                    {
                        menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);


                    }
                    else if(node.Attributes[dialogueCounter].Value == "finished")
                    {
                        menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, true);
                        dialogueStarted = false;
                    }
                    //else
                    //{
                    //    menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);
                    //}

                }
            }
        }
        dialogueStarted = true;
        dialogueCounter++;
    }
    void Update()
    {
        print(dialogueStarted);
        if(dialogueStarted)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Dialogue();
                timer = dialogueTimer;
            }
        }
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
