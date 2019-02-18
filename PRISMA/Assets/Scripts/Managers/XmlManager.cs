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
    GameManager gameManager;

    bool trigger, newTrigger, dialogueStarted, dialogueFinished, startCounting;
    string colliderName, filePath, gameVersion;
    [SerializeField]
    float dialogueTimer;
    float timer;
    int dialogueCounter, index;

    public bool DialogueFinished
    {
        set { dialogueFinished = value; }
    }

    void Start()
    {
        startCounting = false;
        dialogueFinished = true;
        timer = dialogueTimer;
        menuManager = GetComponent<MenuManager>();
        gameManager = GetComponent<GameManager>();

    }
    public void SendToSetUp(bool trigger, string colliderName, int index)
    {
        StartCoroutine(SetUpXML(trigger, colliderName, index));
    }

    IEnumerator SetUpXML(bool trigger, string colliderName, int index)
    {
        gameVersion = gameManager.GameVersion;
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

        yield return new WaitUntil(() => dialogueFinished);
        dialogueCounter = 0;
        this.trigger = trigger;
        this.colliderName = colliderName;
        this.index = index;
        Dialogue();

    }
    public void Dialogue()
    {
        print(gameVersion);
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
                                    dialogueFinished = false;
                                }
                                menuManager.ViewDialogue(versionNode.Attributes[dialogueCounter].Value, trigger);
                            }
                            else if (versionNode.Attributes[dialogueCounter].Value == "finished")
                            {
                                menuManager.ViewDialogue(versionNode.Attributes[dialogueCounter].Value, trigger);
                            }
                            dialogueCounter++;
                        }
                    }
                }
            }
        }
    }
    void Update()
    {
        if (!dialogueFinished && trigger)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Dialogue();
                timer = dialogueTimer;
            }
        }
    }
}
