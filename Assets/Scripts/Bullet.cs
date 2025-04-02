using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed,lifeTime;
    [SerializeField]
    private Rigidbody rgb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <=0 )
        {
            Destroy(gameObject);
        }
        rgb.velocity = transform.forward * _bulletSpeed;
    }
}
