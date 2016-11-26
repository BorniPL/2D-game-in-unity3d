using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    public float HeroSpeed;
    public float HeroJump;
    private Rigidbody2D rgdbody;

    public Transform GroundCheck;
    public LayerMask whatIsMask;
    public float groundCheckRadius;
       
    public bool isGrounded;
    private Animator myAnimator;
	// Use this for initialization
	void Start () {
        rgdbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsMask);


        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rgdbody.velocity = new Vector3(HeroSpeed, rgdbody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(Input.GetAxisRaw("Horizontal")< 0f)
        {
            rgdbody.velocity = new Vector3(-HeroSpeed, rgdbody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            rgdbody.velocity = new Vector3(0f, rgdbody.velocity.y, 0f);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rgdbody.velocity = new Vector3(rgdbody.velocity.x, HeroJump, 0f);
        }

        myAnimator.SetFloat("Speed", Mathf.Abs( rgdbody.velocity.x));
        myAnimator.SetBool("Grounded", isGrounded);
	}
}
