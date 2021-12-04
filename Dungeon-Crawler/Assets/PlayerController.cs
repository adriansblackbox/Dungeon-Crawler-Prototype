using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _moveDirectrion;
    private float _inputYaw;
    private float _inputPitch;
    private float _attackTimer;

    //variables for weapon swapping
    public Transform CameraRoot;
    public Collider AttackRange;
    public SpriteRenderer Swoosh;
    public GameObject weapon1;
    public GameObject weapon2;
    public bool melee = true;
    public float AttackTime = 0.5f;

    //variables for icon swapping
    public GameObject hammerIcon;
    public GameObject bowIcon;

    public float Speed = 10.0f;
    public float CameraFollowDelay = 20f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Lerp camera position to player to avoid any stuttering
        CameraRoot.position = Vector3.Lerp(CameraRoot.position, this.transform.position, Time.deltaTime *  CameraFollowDelay);
        if(melee) Attack();
        else Shoot();
        Movement();
        WeaponSwap();
    }
    private void Movement(){
        _inputYaw = Input.GetAxisRaw("Horizontal");
        _inputPitch =  Input.GetAxisRaw("Vertical");
        _moveDirectrion = new Vector3(_inputYaw, 0.0f, _inputPitch);
        if(_moveDirectrion != Vector3.zero && !AttackRange.enabled){
            _controller.Move(_moveDirectrion.normalized * Speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(_moveDirectrion);
        }else{
            _controller.Move(_moveDirectrion.normalized * Speed/2 * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(_moveDirectrion);
        }
    }
    private void WeaponSwap(){
        // Weapon swap
        if (Input.GetKeyDown("e")){
            // Toggle between melee and ranged state
            melee = !melee;
            // Swap to hammer
            if (melee == false){
                Debug.Log("swap to bow");
                weapon1.SetActive(false);
                hammerIcon.SetActive(false);
                weapon2.SetActive(true);
                bowIcon.SetActive(true);
            }
            // Swap to bow
            if (melee == true){
                Debug.Log("swap to hammer");
                weapon1.SetActive(true);
                hammerIcon.SetActive(true);
                weapon2.SetActive(false);
                bowIcon.SetActive(false);
            }
        }
    }
    private void Attack(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            _attackTimer = AttackTime;
            AttackRange.enabled = true;
            Swoosh.enabled = true;
        }
        if( _attackTimer > 0.0f) _attackTimer -= Time.deltaTime;
        else{
            Swoosh.enabled = false;
            AttackRange.enabled = false;
        }
    }
    private void Shoot(){
        _attackTimer = 0.0f;
        // code for shooting
    }
}
