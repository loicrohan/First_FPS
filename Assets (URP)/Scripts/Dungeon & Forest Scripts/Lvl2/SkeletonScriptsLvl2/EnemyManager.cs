using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject m_EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            Vector3 pos = new Vector3(Random.Range(-1f,100f), transform.position.y,transform.position.z);
            Instantiate(m_EnemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
}