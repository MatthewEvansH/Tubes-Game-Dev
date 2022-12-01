using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    private void Awake()
    {
        // Get Rigidbody & Animatior from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Move Left & Right
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player when moving Left & Right
        if(horizontalInput > 0.01f){
            transform.localScale = Vector3.one;
        } else if (horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKey(KeyCode.UpArrow) && IsGrounded()){
            Jump();
        }

        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Crouch", Crouch());
        anim.SetBool("Grounded", IsGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
    }

    public bool Crouch()
    {
        return horizontalInput == 0 && Input.GetKey(KeyCode.DownArrow) && IsGrounded();
    }
    
    private bool IsGrounded() //untuk cek sedang di ground atau tidak
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down , 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttackWithMelee()
    {
        return true; //gada syarat
    }

    public bool CanAttackWithGun()
    {
        return horizontalInput == 0 && IsGrounded(); //lagi diem dan di ground
    }
}
