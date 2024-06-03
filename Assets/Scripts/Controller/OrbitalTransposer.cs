using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class OrbitalTransposer : MonoBehaviour
{
    [SerializeField] private Transform basis_orbit;
    [SerializeField] private Transform basis_center;
    [SerializeField] private float lateral_difference = 40;
    [SerializeField] private float height_difference = 30;
    [SerializeField] private float lateral_slerp_speed = 10;
    [SerializeField] private float delta_affectant_mult = 10;

    private Vector3 lateral;
    private Vector3 ref_old;
    private Vector3 ref_delta;

    // Update is called once per frame
    void Update()
    {
        var lateral_off = basis_orbit.position - basis_center.position;
        lateral_off.y = 0;

        ref_delta = lateral_off - ref_old;
        ref_old = lateral_off;
        var delta_affectant = ref_delta.sqrMagnitude * delta_affectant_mult;
        delta_affectant = Mathf.Clamp01(delta_affectant_mult);

        var lateral_new = lateral_off.normalized * lateral_difference;
        if (lateral_off.sqrMagnitude == 0)
            lateral_new = -Vector3.forward * lateral_difference;


        lateral = Vector3.Slerp(lateral, lateral_new, Time.deltaTime * lateral_slerp_speed * delta_affectant);

        var final = basis_center.position;
        final.y = basis_orbit.position.y + height_difference;
        final += lateral;

        transform.position = final;
    }
}
