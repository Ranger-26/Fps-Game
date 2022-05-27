using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _gravity = -9.81f;

    [SerializeField]
    private float _jumpHeight = 5f;

    private Vector3 _playerVel;

    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = _controller.isGrounded;

        if (grounded && _playerVel.y < 0)
        {
            _playerVel.y = 0;
        }
        
        _controller.Move(GetVelocity() * Time.deltaTime * _speed);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            _playerVel.y = _jumpHeight;
        }

        _playerVel.y += _gravity * Time.deltaTime;_controller.Move(_playerVel * Time.deltaTime); 
    }

    Vector3 GetVelocity()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        return Vector3.ClampMagnitude(move, 1f);
    }
}
