using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IGvrPointerHoverHandler
{
    public void OnGvrPointerHover(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnLookItemBox(bool isLookAt)
    {
        Debug.Log(isLookAt);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
