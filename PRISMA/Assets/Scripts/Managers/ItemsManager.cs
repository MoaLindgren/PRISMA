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
        items.Add(index, name);
        menuManager.InstatiateItem(name);
    }
    public void GetItem(int index)
    {
        items.TryGetValue(1, out item);

        print(item);
    }

}
