using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SkeletonAIController : MonoBehaviour
{
    [SerializeField]
    private bool chasing;
    [SerializeField]
    private Rigidbody rgb;
    [SerializeField]
    private float moveSpeed;
    private float chasingDistance = 300f, stoppingDistance = 505f;
    private Vector3 targetPoint;
    private Animator anim;
    [SerializeField]
    private int currentHealth = 100;
    public Animator anim2;
    NavMeshAgent EnemyAgent;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim2 = GetComponent<Animator>();
        EnemyAgent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;
        //agentmove();
        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < chasingDistance)
            {
                chasing = true;
                anim.SetTrigger("IsChasing");
            }
        }
        else
        {
            transform.LookAt(targetPoint);
            rgb.velocity = transform.forward * moveSpeed;
            //Agent.destination = targetPoint;
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
        //Debug.Log("Enemy life = " + currentHealth);
        if (currentHealth < 0)
        {
            //ScoreCounter sc = GetComponent<ScoreCounter>();
            GameObject sc = GameObject.Find("ScoreCanvas");
            sc.GetComponent<ScoreCounter>().UpdateScore();
            EnemyAgent.speed = 0f;
            anim2.SetTrigger("IsDead");
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<SkeletonAIController>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(this.gameObject, 1.2f);
            //Debug.Log("Enemy is Dead");
        }
    }

    public void AttackPlayer()
    {
        anim.SetTrigger("IsAttacking");
    }
}