using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHealth : MonoBehaviour
{
    [SerializeField]
    private int currentHealth = 160;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        //currentHealth--;
        currentHealth = currentHealth - damage;
        Debug.Log("Enemy life = " + currentHealth);
        if (currentHealth < 0)
        {
            anim.SetTrigger("IsDead");
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<SkeletonHealth>().enabled= false;  
            GetComponent<SkeletonAIController>().enabled= false;
            //Destroy(this.gameObject, 0.8f);
            Debug.Log("Enemy is Dead");
        }
    }
}