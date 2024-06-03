using Assets.Scripts.Gameplay.Controller.Extensions;
using Assets.Scripts.Library;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(EventDebugger))]
public class Digger : MonoBehaviour, ISingleton<Digger>
{
    private EventDebugger mEventDebugger;
    private Rigidbody mRigidbody;
    [SerializeField] private float Health;
    [SerializeField] private float Max_Health;
    [SerializeField] private float distance_multiplier;
    [Header("References")]
    [SerializeField] private Transform mBall;
    [SerializeField] private TrailRenderer mTrail;

    [SerializeField] private float turn_speed = 5;

    [SerializeField] private float maximum_scale = 3;
    [SerializeField] private float minimum_scale = 0.01f;
    [SerializeField] private float spawn_time = 0.1f;
    [SerializeField] private float dig_dist = 3f;

    private RaycastHit[] dig_list = new RaycastHit[200];

    private void Awake()
    {
        mEventDebugger = GetComponent<EventDebugger>();

        ISingleton<Digger>.Instance = this;
        mRigidbody = GetComponent<Rigidbody>();

        EventBroadcaster.Instance.AddObserver("EATBLOCK", OnEatEvent);
    }

    private void Start()
    {
        //mEventDebugger.RegisterHasParams("EATBLOCK");
    }

    private void OnEatEvent(Parameters parameters)
    {
        var hpdiff = parameters.GetFloatExtra("HP", 0);
        Health += hpdiff;
        Health = Mathf.Clamp(Health, 0, Max_Health);
    }

    private void FixedUpdate()
    {
        var reference = ISingleton<CameraController>.Instance.transform;
        var ref_forward = reference.forward;
        ref_forward.y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            mRigidbody.velocity += ref_forward * Time.fixedDeltaTime * turn_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            mRigidbody.velocity -= ref_forward * Time.fixedDeltaTime * turn_speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            mRigidbody.velocity += reference.right * Time.fixedDeltaTime * turn_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            mRigidbody.velocity -= reference.right * Time.fixedDeltaTime * turn_speed;
        }

        if (Input.GetKey(KeyCode.Space) && this.transform.localScale.x > minimum_scale)
        {
            Physics.SphereCastNonAlloc(new Ray(transform.position, mRigidbody.velocity), 0.5f, dig_list, dig_dist);
            foreach (var block in dig_list)
            {
                if (block.collider == null)
                    continue;

                if (block.collider.gameObject.TryGetComponent(out SoilBlock soil))
                {
                    soil.Split();
                }
            }
        }

        mBall.transform.localScale = Vector3.Lerp(Vector3.one * minimum_scale, Vector3.one * maximum_scale, Health / Max_Health);
    }
}
