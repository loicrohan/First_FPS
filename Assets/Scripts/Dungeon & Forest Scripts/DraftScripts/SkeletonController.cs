using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    [SerializeField]
    private bool chasing;
    [SerializeField]
    private Rigidbody rgb;
    [SerializeField]
    private float moveSpeed;
    private float chasingDistance = 10f, stoppingDistance = 15f;
    private Vector3 targetPoint;
    private Animator anim;
    NavMeshAgent agent;
    [SerializeField]
    private int currentHealth = 160;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerControllerLvL1.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < chasingDistance)
            {
                chasing = true;
                anim.SetBool("IsChasing", true);
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
    public void Damage(int damage)
    {
        //currentHealth--;
        currentHealth = currentHealth - damage;
        Debug.Log("Enemy life = " + currentHealth);
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy is Dead");
        }
    }
}