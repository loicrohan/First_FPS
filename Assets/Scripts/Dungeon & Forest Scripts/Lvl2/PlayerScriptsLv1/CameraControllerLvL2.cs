using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControllerLvL2 : MonoBehaviour
{
    [SerializeField]
    private Transform _camTrans;
    [SerializeField]
    private float mouseSensitivity = 100f;
    public Slider mouseSlider;
    private float xRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity", 100);
        mouseSlider.value = mouseSensitivity / 10f;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetFloat("Mouse Sensitivity", mouseSensitivity);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        _camTrans.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerController.instance.transform.Rotate(Vector3.up * mouseX);

        transform.position = _camTrans.position;
        transform.rotation = _camTrans.rotation;
    }

    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 1f;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(cameraPoint.position, 0.15f);
    }*/
}