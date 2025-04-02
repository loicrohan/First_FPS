using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBGM : MonoBehaviour
{
    public static SingletonBGM instance;

    // Start is called before the first frame update
    private void Awake()
    {
        createSingleton();
    }

    void createSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void printMessage(int sceneNo)
    {
        Debug.Log("Game Theme playing in : " + sceneNo);
    }
}
