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

    [SerializeField] 
    private AudioClip[] _playableFootstepSounds;

    [SerializeField] 
    private float _footstepDistance;

    private AudioSource _audioSource;
    
    private Vector3 _playerVel;

    private CharacterController _controller;
    
    private bool _isGrounded;
    
    private bool _isCrouching;

    private Vector3 _lastFootstepPosition;

    private bool _playFootstepOnLand;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
        _lastFootstepPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;

        if (_isGrounded && _playerVel.y < 0)
        {
            _playerVel.y = 0;
            if (_playFootstepOnLand)
            {
                Footstep();
                _playFootstepOnLand = false;
            }
        }
        
        _controller.Move(GetVelocity() * Time.deltaTime * _speed);
        CheckCrouch();
        CheckFootstep();
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _playerVel.y = _jumpHeight;
            _playFootstepOnLand = true;
        }

        _playerVel.y += _gravity * Time.deltaTime;_controller.Move(_playerVel * Time.deltaTime); 
    }

    Vector3 GetVelocity()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        return Vector3.ClampMagnitude(move, 1f);
    }
    
    private void CheckCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (_isGrounded && !_isCrouching)
            {
                _speed /= 2;
                _jumpHeight /= 2;
                Vector3 old = transform.localScale;
                transform.localScale = new Vector3(old.x, old.y / 2, old.z);
                _isCrouching = true;
            }
        }
        else 
        {
            if (_isCrouching)
            {
                _speed *= 2;
                _jumpHeight *= 2;
                Vector3 old = transform.localScale;
                transform.localScale = new Vector3(old.x, old.y * 2, old.z);
                _isCrouching = false;
            }
        }
    }

    private void CheckFootstep()
    {
        if (_isCrouching) return;

        if (_isGrounded && Vector3.Distance(_lastFootstepPosition, transform.position) >= _footstepDistance)
        {
            Footstep();
        }
    }
    
    private void Footstep()
    {
        _audioSource.PlayOneShot(_playableFootstepSounds[Random.Range(0, _playableFootstepSounds.Length)]);
        _lastFootstepPosition = transform.position;
    }
}
