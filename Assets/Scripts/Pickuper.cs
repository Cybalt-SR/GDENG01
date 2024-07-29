using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuper : MonoBehaviour
{
    [SerializeField] private float pickup_dist = 0.6f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out var hit, pickup_dist))
        {
            if (hit.collider.gameObject.TryGetComponent(out Pickupable pickupable))
            {
                pickupable.Pickup();
            }
        }
    }
}
