﻿using System.Collections;
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
    int dialogueCounter, index, gameRound;
    MenuManager menuManager;


    void Start()
    {
        menuManager = GetComponent<MenuManager>();
    }

    public void SetUpXML(int stationIndex, int gameRoundIndex)
    {
        gameRound = gameRoundIndex;
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

        foreach (XmlNode rootNode in nodeList)
        {
            foreach (XmlNode roundNode in rootNode)
            {
                if (roundNode.Name == "Round" + gameRound.ToString())
                {
                    foreach (XmlNode minigameNode in roundNode)
                    {
                        if (!item)
                        {
                            if (minigameNode.Name == "MiniGame" + index.ToString())
                            {

                                if (win)
                                {
                                    menuManager.ViewDialogue(minigameNode.Attributes[dialogueCounter].Value, false);
                                    dialogueCounter += 1;
                                }
                                else
                                {
                                    dialogueCounter += 2;
                                    menuManager.ViewDialogue(minigameNode.Attributes[dialogueCounter].Value, false);
                                    dialogueCounter += 1;
                                }
                            }
                        }
                        else
                        {
                            if (minigameNode.Name == "Items")
                            {
                                print("hej");
                                menuManager.ViewDialogue(minigameNode.Attributes[index].Value, true);
                            }
                        }
                    }
                }


            }
        }

    }

}
