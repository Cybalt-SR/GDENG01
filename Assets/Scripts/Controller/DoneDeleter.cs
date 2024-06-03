using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneDeleter : MonoBehaviour
{
    [SerializeField] private float y_offset = 5;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SoilBlock soil))
            soil.Dissolve();
    }

    private void Update()
    {
        var newPos = transform.position;
        newPos.y = ISingleton<Digger>.Instance.transform.position.y + y_offset;

        this.transform.position = newPos;
    }
}
