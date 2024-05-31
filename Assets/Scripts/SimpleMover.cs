using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float rotSpeed = 45;

    // Update is called once per frame
    void Update()
    {
        var forward_flat = transform.forward;
        forward_flat.y = 0;
        forward_flat = forward_flat.normalized;

        var delta = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += forward_flat * delta;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= forward_flat * delta;

        if (Input.GetKey(KeyCode.RightArrow))
            transform.localEulerAngles += Vector3.up * rotSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.localEulerAngles -= Vector3.up * rotSpeed * Time.deltaTime;
    }
}
