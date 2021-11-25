using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _moveDirectrion;
    private float _inputYaw;
    private float _inputPitch;

    public float Speed = 10.0f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
    }
    private void Movement(){
        _inputYaw = Input.GetAxisRaw("Horizontal");
        _inputPitch =  Input.GetAxisRaw("Vertical");
        _moveDirectrion = new Vector3(_inputYaw, 0.0f, _inputPitch);
        _controller.Move(_moveDirectrion.normalized * Speed * Time.deltaTime);
    }
}
