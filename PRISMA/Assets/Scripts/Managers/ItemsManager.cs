using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public Dictionary<int, string> items = new Dictionary<int, string>();
    List<string> itemList;
    string item;
    MenuManager menuManager;

    void Start()
    {
        menuManager = GetComponent<MenuManager>();
    }

    public void AddItem(int index, string name)
    {
        if(index > items.Count)
        {
            items.Add(index, name);
            menuManager.InstantianteItem(name);
        }
    }
    public void GetItem(int index)
    {
        items.TryGetValue(index, out item);
    }

}
