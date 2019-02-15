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

    bool trigger, dialogueStarted, triggerDialogueFinished;
    string colliderName, filePath, gameVersion;
    [SerializeField]
    float dialogueTimer;
    float timer;
    int dialogueCounter, index;

    void Start()
    {
        triggerDialogueFinished = true;
        timer = dialogueTimer;
        menuManager = GetComponent<MenuManager>();
    }

    public void SetUpXML(bool trigger, string colliderName, int item, string gameVersion)
    {
        if(trigger)
        {
            triggerDialogueFinished = false;
        }
        dialogueCounter = 0;
        this.trigger = trigger;
        this.colliderName = colliderName;
        this.index = item;
        this.gameVersion = gameVersion;

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

        StartCoroutine(Dialogue());
    }
    public void SendToDialogue()
    {
        StartCoroutine(Dialogue());
    }
    public IEnumerator Dialogue()
    {
        if (trigger)
        {
            yield return new WaitUntil(() => triggerDialogueFinished);
        }
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
                                menuManager.ViewDialogue(versionNode.Attributes[dialogueCounter].Value, false);
                            }
                            else if (versionNode.Attributes[dialogueCounter].Value == "finished")
                            {
                                if (trigger)
                                {
                                    triggerDialogueFinished = true;
                                }
                                menuManager.ViewDialogue(versionNode.Attributes[dialogueCounter].Value, true);
                                dialogueStarted = false;
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
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                StartCoroutine(Dialogue());
                timer = dialogueTimer;
            }
        }
    }
}
