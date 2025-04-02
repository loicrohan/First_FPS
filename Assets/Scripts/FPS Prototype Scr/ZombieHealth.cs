using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField]
    private int currentHealth = 160;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(this.gameObject);
            Debug.Log("Enemy is Dead");
        }
    }
}