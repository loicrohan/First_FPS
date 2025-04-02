using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenController : MonoBehaviour
{
    public static EllenController instance;

    private float Ymin = -10f;
    private float Ymax = 0.23f;

    [SerializeField]
    private float _speed, mouseSensitivity, gravityModifier, jumpForce, runSpeed;

    [SerializeField]
    private CharacterController cC;
    private Vector3 moveInput;
    Vector2 mouseInput;

    [SerializeField]
    private Transform _camTrans, groundCheckPoint, _firePoint;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private bool invertX, invertY, canJump, canDoubleJump, canRun;

    [SerializeField]
    private GameObject bulletPrefab;

    private void Awake()
    {
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
        playerJump();

        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            moveInput = moveInput * runSpeed;
        }

        cC.Move(moveInput * _speed * Time.deltaTime);
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        _camTrans.rotation = Quaternion.Euler(_camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(_camTrans.position, _camTrans.forward, out hitInfo, 50f))
            {
                if (Vector3.Distance(_camTrans.position, hitInfo.point) > 2f)
                {
                    _firePoint.LookAt(hitInfo.point);
                }
            }
            else
            {
                _firePoint.LookAt(_camTrans.position + (_camTrans.forward * 30f));
            }

            Instantiate(bulletPrefab, _firePoint.position, _firePoint.rotation);
        }
    }

    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.25f);
    }

    void Respawn()
    {
        if (transform.position.y < Ymin)
        {
            transform.position = new Vector3(transform.position.x, Ymax, transform.position.z);
        }
    }
}