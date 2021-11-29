using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _moveDirectrion;
    private float _inputYaw;
    private float _inputPitch;

    //variables for weapon swapping
    public GameObject weapon1;
    public GameObject weapon2;
    public bool melee = true;

    public float Speed = 10.0f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
        
        //weapon swap
        if (Input.GetKeyDown("e"))
        {
            //swap to hammer
           if (melee == true)
            {
                Debug.Log("swap to bow");
                weapon1.SetActive(false);
                weapon2.SetActive(true);
            }
           //swap to bow
           if (melee == false)
            {
                Debug.Log("swap to hammer");
                weapon1.SetActive(true);
                weapon2.SetActive(false);
            }
           //toggle between melee and ranged state
            melee = !melee;
        }
    }
    private void Movement(){
        _inputYaw = Input.GetAxisRaw("Horizontal");
        _inputPitch =  Input.GetAxisRaw("Vertical");
        _moveDirectrion = new Vector3(_inputYaw, 0.0f, _inputPitch);
        if(_moveDirectrion != Vector3.zero){
            _controller.Move(_moveDirectrion.normalized * Speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(_moveDirectrion);
        }
    }
}
