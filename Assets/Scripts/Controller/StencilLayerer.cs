using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class StencilLayerer : MonoBehaviour
{
    [SerializeField] private LayerMask default_layer;
    [SerializeField] private LayerMask stencil_layer;
    [SerializeField] private float radius;
    private RaycastHit[] stencils_prev = new RaycastHit[100];
    private RaycastHit[] stencils_now = new RaycastHit[100];

    private int LayermaskToLayerint(LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber;
    }

    private void FixedUpdate()
    {
        var campos = ISingleton<CameraController>.Instance.transform.position;
        var dir = this.transform.position - campos;
        Physics.SphereCastNonAlloc(new Ray(campos, dir), radius, stencils_now);

        for (int i = 0; i < stencils_now.Length; i++)
        {
            if (stencils_now[i].collider == null)
                continue;

            var other = stencils_now[i].collider.gameObject;
            var delta = other.transform.position - campos;

            if (delta.sqrMagnitude < dir.sqrMagnitude)
            {
                other.layer = LayermaskToLayerint(stencil_layer);
                stencils_prev[i] = stencils_now[i];
                Debug.Log("Converted");
            }
        }

        foreach (var prev in stencils_prev)
        {
            if (prev.collider == null)
                continue;

            bool stillHere = false;

            foreach (var now in stencils_now)
            {
                if (now.collider == null)
                    continue;

                if (now.collider.gameObject != prev.collider.gameObject)
                    continue;

                stillHere = true;
                break;
            }

            if (stillHere)
                continue;

            prev.collider.gameObject.layer = LayermaskToLayerint(default_layer);
            break;
        }
    }
}
