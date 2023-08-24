using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float speedRotation;
    public float jumpForce;
    private float x, z;
    private Animator animator;
    public Rigidbody rb;
    public bool isJump;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isJump = false;

    }

    void FixedUpdate(){
        transform.Rotate(0,x * Time.deltaTime * speedRotation, 0);
        transform.Translate(0, 0, z * Time.deltaTime * movementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        animator.SetFloat("YSpeed", Mathf.Abs(z));
        animator.SetFloat("XSpeed", Mathf.Abs(x));

        if(isJump == true)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetBool("IsJumping", true);
                rb.AddForce(new Vector3(0 , jumpForce , 0), ForceMode.Impulse);         
            }
            animator.SetBool("IsGround", true);
        }
        else{
                Falling();
            }
    }

    void Falling(){
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsGround", false);
    }

}
