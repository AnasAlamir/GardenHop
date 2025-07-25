using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float climbSpeed = 3f; 
    private bool isClimbing = false;
    private bool isOnLadder = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (isOnLadder)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbSpeed);
                animator.SetBool("isClimbing", true); 
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -climbSpeed);
                animator.SetBool("isClimbing", true); 
            }
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            }
        }
        else
        {
            animator.SetBool("isClimbing", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false; 
        }
    }
}
