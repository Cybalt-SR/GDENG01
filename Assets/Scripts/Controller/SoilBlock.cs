using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


[RequireComponent(typeof(Collider))]
public class SoilBlock : MonoBehaviour
{
    [SerializeField] private float health_difference;
    [SerializeField] private Transform renderer_object;
    [SerializeField] private float minimum_scale = 0.25f;
    [SerializeField] private int layerofsmall = 4;

    private bool splitting = false;
    private bool shrinking = false;

    private void Awake()
    {
        splitting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Digger>(out _))
        {
            Split();
        }
    }

    public void Split()
    {
        if (splitting || shrinking)
            return;

        StartCoroutine(SplitCoroutine());
    }

    IEnumerator SplitCoroutine()
    {
        splitting = true;

        if (transform.localScale.x > minimum_scale)
        {
            List<GameObject> subs = new();
            Vector3[] sides = {
                new Vector3(1, 1, 1),
                new Vector3(1, -1, 1),
                new Vector3(-1, 1, 1),
                new Vector3(-1, -1, 1),
                new Vector3(1, 1, -1),
                new Vector3(1, -1, -1),
                new Vector3(-1, 1, -1),
                new Vector3(-1, -1, -1),
                };

            for (int i = 0; i < sides.Length; i++)
            {
                var newObj = Instantiate(this.gameObject);
                subs.Add(newObj);
                newObj.transform.parent = transform.parent;

                var side = sides[i];
                var newScale = this.transform.localScale / 2;

                newObj.transform.localScale = newScale;
                newObj.transform.position = transform.position + (side * (this.transform.localScale.x / 4));

                if (newScale.x / 2 < minimum_scale)
                {
                    newObj.TryGetComponent(out SoilBlock block);
                    block.renderer_object.gameObject.layer = layerofsmall;
                    block.Appear();
                }

            }

            yield return new WaitForEndOfFrame();
        }

        var eventparams = new Parameters();
        eventparams.PutExtra("HP", health_difference);

        EventBroadcaster.Instance.PostEvent("EATBLOCK", eventparams);

        Destroy(this.gameObject);
    }

    public void Appear()
    {
        if (shrinking)
            return;

        StartCoroutine(AppearRoutine());
    }
    public void Dissolve()
    {
        if (shrinking)
            return;

        StartCoroutine(ShrinkRoutine());
    }

    IEnumerator ShrinkRoutine()
    {
        shrinking = true;

        while (renderer_object.localScale.y > 0.05f)
        {
            renderer_object.localScale = Vector3.Lerp(renderer_object.localScale, Vector3.zero, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        Destroy(this.gameObject);
    }
    IEnumerator AppearRoutine()
    {
        renderer_object.localScale = Vector3.zero;

        while (renderer_object.localScale.y < 0.99f)
        {
            renderer_object.localScale = Vector3.Lerp(renderer_object.localScale, Vector3.one, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();

            if (shrinking)
                break;
        }

        renderer_object.localScale = Vector3.one;
    }

}
