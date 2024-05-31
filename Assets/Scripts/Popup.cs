using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour, ISingleton<Popup>
{
    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popup_text;

    private void Awake()
    {
        ISingleton<Popup>.Instance = this;
    }

    public void Send(string message)
    {
        popup.SetActive(true);
        popup_text.text = message;
    }
}
