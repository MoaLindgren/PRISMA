using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public Dictionary<int, string> items = new Dictionary<int, string>();
    string item;
    int itemIndex;

    MenuManager menuManager;

    public int ItemIndex
    {
        get { return itemIndex; }
    }

    void Start()
    {
        menuManager = GetComponent<MenuManager>();
    }
    //public void AddItem(int index, string name)
    //{
    //    if(index > items.Count)
    //    {
    //        items.Add(index, name);
    //        menuManager.InstantianteItem(index, name);
    //    }
    //}
    public void GetItem(int index, bool selectItem)
    {
        items.TryGetValue(index, out item);
        if(selectItem)
        {
            itemIndex = index;
        }
    }
}
