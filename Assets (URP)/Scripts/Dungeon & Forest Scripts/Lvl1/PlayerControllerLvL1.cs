using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerControllerLvL1 : MonoBehaviour
{
    public static PlayerControllerLvL1 instance;

    [SerializeField]
    private float _speed, gravityModifier, runSpeed, jumpForce;
    
    [SerializeField]
    private CharacterController cC;
    private Vector3 moveInput;
    Vector2 mouseInput;

    [SerializeField]
    private Transform _camTrans, groundCheckPoint, _firePoint;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private bool canJump, canRun;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    ChestBox _box;
    [SerializeField]
    ChestBox2 _box2;
    [SerializeField]
    ChestBox3 _box3;
    [SerializeField]
    private AudioClip _clip, _clip2, _clip3;
    [SerializeField]
    private GameOverLvl1 _gameOverLvL1;
    [SerializeField]
    private GameObject Bottle,Bottle2,Bottle3;
    [SerializeField]
    private GameObject colliderEffect;
    [SerializeField]
    private AudioSource _gunshot;

    private void Awake()
    {
        transform.position = new Vector3(-3.34f, -0.477f, 3.08f);
        makeSingleton();
    }

    private void makeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        float yStore = moveInput.y;
        
        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizMove = transform.right * Input.GetAxis("Horizontal");
        
        moveInput = vertMove + horizMove;
        moveInput.Normalize();
        moveInput.y = yStore;

        //Where we Apply Gravity to our player
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;
        if(cC.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        canRun = Physics.OverlapSphere(groundCheckPoint.position, 0.25f, _groundLayer).Length > 0;

        canJump = Physics.OverlapSphere(groundCheckPoint.position, 0.25f, _groundLayer).Length > 0;
        playerJump();

        if (Input.GetKey(KeyCode.LeftShift) && canRun )
        {
            moveInput = moveInput * runSpeed;
        }

        cC.Move(moveInput * _speed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(_camTrans.position, _camTrans.forward, out hitInfo, 50f))
            {
                if(Vector3.Distance(_camTrans.position, hitInfo.point) > 2f )
                {
                    _firePoint.LookAt(hitInfo.point);
                }
            }
            else
            {
                _firePoint.LookAt(_camTrans.position + (_camTrans.forward * 30f));
            }

            _gunshot.Play();
            Instantiate(bulletPrefab, _firePoint.position, _firePoint.rotation);
        }
    }

    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            moveInput.y = jumpForce;
            //canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) /*&& canDoubleJump*/)
        {
            moveInput.y = jumpForce;
            //canDoubleJump = false;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            _box.OpenChest();
            GetComponent<PlayerControllerLvL1>()._speed = 0f;
            GameObject sc = GameObject.Find("Chest Box Canvas");
            sc.GetComponent<TreasureCounter>().UpdateScore();
            Bottle3.SetActive(true);
            Destroy(Bottle3, 5f);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(_clip2, Camera.main.transform.position, 1f);
            _gameOverLvL1.SetGameOver();
            Cursor.lockState = CursorLockMode.None;
        }
        else if (other.gameObject.tag == "Box2")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            _box2.OpenChest();
            Bottle.SetActive(true);
            Destroy(Bottle,5f);
        }
        else if (other.gameObject.tag == "Box3")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            _box3.OpenChest();
            Bottle2.SetActive(true);
            Destroy(Bottle2, 5f);
        }
        else if (other.gameObject.tag == "Coins")
        {
            AudioSource.PlayClipAtPoint(_clip3, Camera.main.transform.position, 1f);
            GameObject sc = GameObject.Find("Chest Box Canvas");
            sc.GetComponent<CoinCounter>().UpdateScore();
            Destroy(other.gameObject);
            Instantiate(colliderEffect,transform.position,transform.rotation);
        }
    }
}