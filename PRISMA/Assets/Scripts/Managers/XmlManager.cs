using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XmlManager : MonoBehaviour
{
    XmlDocument doc;
    XmlNodeList nodeList;
    TextAsset path;
    XmlWriter writer;
    MenuManager menuManager;

    bool trigger, newTrigger, dialogueStarted, triggerDialogueFinished, startCounting;
    string colliderName, filePath, gameVersion;
    [SerializeField]
    float dialogueTimer;
    float timer;
    int dialogueCounter, index;

    void Start()
    {
        startCounting = false;
        triggerDialogueFinished = true;
        timer = dialogueTimer;
        menuManager = GetComponent<MenuManager>();
    }
    public void SendToSetUp(bool trigger, string colliderName, int item, string gameVersion)
    {
        dialogueCounter = 0;
        this.trigger = trigger;
        if(colliderName != this.colliderName)
        {
            newTrigger = true;
        }
        
        this.colliderName = colliderName;
        this.index = item;
        this.gameVersion = gameVersion;

        StartCoroutine(SetUpXML());
    }

    IEnumerator SetUpXML()
    {
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
        if (newTrigger)
        {
            yield return new WaitUntil(() => triggerDialogueFinished);
            Dialogue();
        }
        else
        {
            Dialogue();
        }

    }
    public void Dialogue()
    {
        nodeList = doc.GetElementsByTagName("Root");

        foreach (XmlNode rootNode in nodeList)
        {
            foreach (XmlNode node in rootNode)
            {
                if (node.Name == gameVersion)
                {
                    foreach (XmlNode versionNode in node)
                    {
                        if (versionNode.Name == colliderName)
                        {
                            if (versionNode.Attributes[dialogueCounter].Value != "" || versionNode.Attributes[dialogueCounter].Value != "finished")
                            {
                                if (trigger)
                                {
                                    triggerDialogueFinished = false;
                                }
                                menuManager.ViewDialogue(versionNode.Attributes[dialogueCounter].Value, false);
                            }
                            else if (versionNode.Attributes[dialogueCounter].Value == "finished")
                            {
                                menuManager.ViewDialogue(versionNode.Attributes[dialogueCounter].Value, true);
                                dialogueStarted = false;
                                if (trigger)
                                {
                                    triggerDialogueFinished = true;
                                }
                            }
                            dialogueStarted = true;
                            dialogueCounter++;
                        }
                    }
                }
            }
        }
    }
    void Update()
    {
        if (dialogueStarted && trigger)
        {
            newTrigger = false;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Dialogue();
                timer = dialogueTimer;
            }
        }
    }
}
