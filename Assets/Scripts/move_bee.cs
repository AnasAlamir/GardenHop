using UnityEngine;

public class move_bee : MonoBehaviour
{
   public GameObject pointA;
    public GameObject pointB;

    private Vector3 target;
    public float speed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = pointB.transform.position;
        FaceTarget();
    }

    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            target = (target == pointB.transform.position) ? pointA.transform.position : pointB.transform.position;
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        if (target.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1); 
        else
            transform.localScale = new Vector3(1, 1, 1);  
    }
}
