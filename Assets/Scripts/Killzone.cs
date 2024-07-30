using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Killzone : MonoSingleton<Killzone>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            Die();
        }
    }

    public void Die()
    {
        Player.Instance.mCharacterController.Move(StartPosition.Instance.transform.position - Player.Instance.transform.position);

        Pickupable.Reset();
    }
}
