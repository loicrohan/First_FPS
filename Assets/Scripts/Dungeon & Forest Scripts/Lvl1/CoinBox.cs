using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField]
    private GameObject boxDestruction;
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private AudioClip boxDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletShot")
        {
            AudioSource.PlayClipAtPoint(boxDestroyed, Camera.main.transform.position, 1f);
            box.SetActive(false);
            boxDestruction.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;

        }
    }
}
