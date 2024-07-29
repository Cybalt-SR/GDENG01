using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public CharacterController mCharacterController { get; private set; }
    public Rigidbody mRigidbody { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        mCharacterController = GetComponent<CharacterController>();
        mRigidbody = GetComponent<Rigidbody>();
    }
}
