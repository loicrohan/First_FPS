using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private float _speed, gravityModifier, jumpForce, runSpeed;

    [SerializeField]
    private CharacterController cC;
    private Vector3 moveInput;
    Vector2 mouseInput;

    [SerializeField]
    private Transform _camTrans, groundCheckPoint, _firePoint;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private bool canJump,canDoubleJump,canRun;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private AudioSource _gunshot;

    [SerializeField]
    private AudioClip _clip;

    [SerializeField]
    private GameOver _gameOver;

    private void Awake()
    {
        transform.position = new Vector3(8.16f, 0.41f, 10.76f);
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
    void Update()
    {
        float yStore = moveInput.y;
        
        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizMove = transform.right * Input.GetAxis("Horizontal");
        
        moveInput = vertMove + horizMove;
        moveInput.Normalize();
        moveInput.y = yStore;

        //Where we Apply Gravity to our player
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;
        if (cC.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        canRun = Physics.OverlapSphere(groundCheckPoint.position, 0.25f, _groundLayer).Length > 0;

        canJump = Physics.OverlapSphere(groundCheckPoint.position, 0.25f, _groundLayer).Length > 0;
        //playerJump();

        if (Input.GetKey(KeyCode.LeftShift) && canRun)
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
        if (Input.GetKeyDown(KeyCode.Space) && canJump )
        {
            moveInput.y = jumpForce;
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            moveInput.y = jumpForce;
            canDoubleJump = false;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            _gameOver.SetGameOver();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}