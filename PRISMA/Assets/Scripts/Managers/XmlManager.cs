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

    bool trigger, dialogueStarted;
    string colliderName, filePath;
    [SerializeField]
    float dialogueTimer;
    float timer;
    int dialogueCounter, index;

    void Start()
    {
        timer = dialogueTimer;
        menuManager = GetComponent<MenuManager>();
    }

    public void SetUpXML(bool trigger, string colliderName, int item)
    {
        dialogueCounter = 0;
        this.trigger = trigger;
        this.colliderName = colliderName;
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
                if(node.Name == colliderName)
                {
                    if(colliderName == "Achievement")
                    {

                    }
                    else
                    {
                        if (node.Attributes[dialogueCounter].Value != "" || node.Attributes[dialogueCounter].Value != "finished")
                        {
                            menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, false);
                        }
                        else if (node.Attributes[dialogueCounter].Value == "finished")
                        {
                            menuManager.ViewDialogue(node.Attributes[dialogueCounter].Value, true);
                            dialogueStarted = false;
                        }
                        dialogueStarted = true;
                        dialogueCounter++;
                    }

                }
            }
        }

    }
    void Update()
    {
        if(dialogueStarted && trigger)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Dialogue();
                timer = dialogueTimer;
            }
        }
    }
}
