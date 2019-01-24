using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Achievements : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    PointerEventData pointerData;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
