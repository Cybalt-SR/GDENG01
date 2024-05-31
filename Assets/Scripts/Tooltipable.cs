using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltipable : MonoBehaviour, IPointerClickHandler
{
    [TextArea]
    [SerializeField] private string message;

    public void OnPointerClick(PointerEventData eventData)
    {
        ISingleton<Popup>.Instance.Send(message);
    }
}
