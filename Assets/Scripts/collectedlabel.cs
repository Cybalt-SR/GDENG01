using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collectedlabel : MonoBehaviour
{
    TextMeshProUGUI m_TextMeshProUGUI;

    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_TextMeshProUGUI.text = Pickupable.currentscore + "/" + Pickupable.pickupables.Count;
    }
}
