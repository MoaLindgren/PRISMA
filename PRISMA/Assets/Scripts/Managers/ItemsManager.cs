using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public Dictionary<int, string> items = new Dictionary<int, string>();
    List<string> itemList;
    string item;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    [SerializeField]
    GameObject player;
    public int itemIndex;

    void Start()
    {
        menuManager = GetComponent<MenuManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }

    public void AddItem(int index, string name)
    {
        if(index > items.Count)
        {
            items.Add(index, name);
            menuManager.InstantianteItem(index, name);
        }
    }
    public void GetItem(int index, bool selectItem)
    {
        items.TryGetValue(index, out item);
        if(selectItem)
        {
            itemIndex = index;
        }
    }

}
