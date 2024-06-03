using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSpawner : MonoBehaviour
{
    [Header("Soil")]
    [SerializeField] private GameObject soil;
    [SerializeField] private GameObject soil_coverup;
    [SerializeField] private int depth;
    [SerializeField] private float start_depth;
    [SerializeField] private float gap;
    [Header("Water")]
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject water_cover;
    [SerializeField] private int water_per_depth;
    [Header("Triggers")]
    [SerializeField] private GameObject trigger;

    private void Start()
    {
        for (int i = 0; i < depth + 2; i++)
        {
            var newpos = new Vector3(0, start_depth - (gap * i), 0);

            var newsoil = Instantiate(soil, transform);
            newsoil.transform.localPosition = newpos;

            var newsoil_coverup = Instantiate(soil_coverup, transform);
            newsoil_coverup.transform.localPosition = newpos;

            if (i == 0)
                continue;

            for (int j = 0; j < water_per_depth; j++)
            {
                var depthposition = new Vector3(Random.Range(0, gap), Random.Range(0, gap), Random.Range(0, gap));
                depthposition -= Vector3.one * (gap / 2);

                var waterpos = newpos + depthposition;

                var newwater = Instantiate(water, transform);
                var newwatercover = Instantiate(water_cover, transform);
                newwater.transform.position = waterpos;
                newwatercover.transform.position = waterpos;
            }
        }
    }
}
