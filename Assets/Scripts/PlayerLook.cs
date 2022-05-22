using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity;

    [SerializeField]
    private float _xLimit;

    [SerializeField]
    private Transform _pivot;

    private float _rotX = 0f;

    private float _rotY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _rotX += -Input.GetAxis("Mouse Y") * _sensitivity;
        _rotX = Mathf.Clamp(_rotX, -_xLimit, _xLimit);
        _rotY = Input.GetAxis("Mouse X") * _sensitivity;
        UpdateCamera();
    }

    public void UpdateCamera()
    {
        _pivot.localRotation = Quaternion.Euler(_rotX, 0, 0);
        transform.rotation *= Quaternion.Euler(0 , _rotY, 0);
    }
}
