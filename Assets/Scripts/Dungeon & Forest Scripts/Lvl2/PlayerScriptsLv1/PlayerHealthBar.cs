using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public float fullHealth = 180f;
    public static float currentHealth;
    public Canvas playerCanvas;
    public Slider playerHealthSlider;
    //public Image playerHealthImage;
    public bool playerDied = false;
    PlayerController pController;
    [SerializeField]
    private GameOver _gameOver;
    [SerializeField]
    private AudioClip _GameOverClip;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = fullHealth;
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;
        //playerHealthImage=GetComponent<Image>();   
        pController = GetComponent<PlayerController>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        //playerHealthImage.fillAmount = currentHealth;
        playerHealthSlider.value = currentHealth;
        
        if (currentHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(_GameOverClip, Camera.main.transform.position, 1f);
            playerDied = true;
            playerCanvas.enabled = false;
            pController.enabled = false;
            _gameOver.SetGameOver();
            Cursor.lockState = CursorLockMode.None;
        }

    }

}
