using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseClick : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    World world;
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        world.Click = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        world.Click = false;
    }
}
