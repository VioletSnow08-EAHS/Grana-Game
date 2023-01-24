using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log(data.pressPosition - data.position);
    }

    public void OnEndDrag(PointerEventData data)
    {
        
    }
}
