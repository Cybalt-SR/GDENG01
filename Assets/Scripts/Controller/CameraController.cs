using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour, ISingleton<CameraController>
{
    private Camera m_Camera;
    public Camera Camera { get { return m_Camera; } }

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
        ISingleton<CameraController>.Instance = this;
    }
}
