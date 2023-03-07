using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField]
    private bool chasing;
    [SerializeField]
    private Rigidbody rgb;
    [SerializeField]
    private float moveSpeed;
    private float chasingDistance = 10f, stoppingDistance = 15f;
    private Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < chasingDistance)
            {
                chasing = true;
            }
        }
        else
        {
            transform.LookAt(targetPoint);
            rgb.velocity = transform.forward * moveSpeed;
            if (Vector3.Distance(transform.position, targetPoint) > stoppingDistance)
            {
                chasing = false;
            }
        }
    }
}
