using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    public float _moveSpeed = 0.5f;
     public float jumpForce = 2.0f;
      public bool isGrounded;
      Rigidbody rb;
    public Vector3 jump;

    // Start is called before the first frame update

     void OnCollisionStay(){
        isGrounded = true;
    }
    void Start()
    {
         rb = GetComponent<Rigidbody>();
        //_characterController = GetComponent<CharacterController>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
       
        //_characterController.SimpleMove(moveDir * _moveSpeed*Time.deltaTime);

        Vector3 move= new Vector3 (Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position+(move*_moveSpeed*Time.deltaTime));
    

         if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
