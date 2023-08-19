using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    private CharacterController characterController;
    private Animator animator;

    public float speed;
    public float gravity;
    public new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speedMove = 0;
        Vector3 movement = Vector3.zero;

        if(horizontal != 0 || vertical != 0)
        {
          Vector3 forward = camera.forward;
          forward.y = 0;
          forward.Normalize();

          Vector3 right = camera.right;
          right.y = 0;
          right.Normalize();

          Vector3 direction = forward * vertical + right * horizontal;
          speedMove = Mathf.Clamp01(direction.magnitude);

          direction.Normalize();
          
          movement = direction * speed * speedMove * Time.deltaTime;
          transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);

        }

        movement.y += gravity * Time.deltaTime;
        characterController.Move(movement); 
        animator.SetFloat("Speed", speedMove); 

    }
}
