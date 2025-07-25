
using NUnit.Framework;
using UnityEngine;

public class player_move : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box ;
    private Animator an;
    private SpriteRenderer sp;
    float dirX;
    public float speed = 7f;
    public static float forceJump = 14f;
    public enum MoveState { idle, run, jump, fall }
    public static MoveState state = MoveState.idle;
    [SerializeField] AudioSource jumpSound ;
    public LayerMask jumpOnce ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(dirX * speed, rb.linearVelocity.y);

        
        if (Input.GetButtonDown("Jump") && isGround())
        {
            jumpSound.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forceJump);
        }

        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        

        if (dirX > 0)
        {
            state = MoveState.run;
            sp.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MoveState.run;
            sp.flipX = true;
        }
        else
        {
            state = MoveState.idle;
        }

        if (rb.linearVelocity.y > 0.1f)
        {
            state = MoveState.jump;
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            state = MoveState.fall;
        }

        an.SetInteger("state", (int)state);
    }
    private bool isGround (){
        return Physics2D.BoxCast(box.bounds.center , box.bounds.size,0f,Vector2.down,.1f,jumpOnce);
        

    }
}
