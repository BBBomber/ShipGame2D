
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private Vector2 moveDir;
    private Vector2 lastMoveDir;

    private bool InputEnabled = true;

    private void Update()
    {
        ProcessInputs();
        Animate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has the script named "OtherScript"
        Cannonball otherScript = other.GetComponent<Cannonball>();

        if (otherScript != null)
        {
            moveDir = Vector2.zero;
            InputEnabled = false;
            anim.SetTrigger("Explode");
            Invoke("Death", 1f);
        }

    }


    private void Death()
    {
        Destroy(gameObject);
    }

    private void ProcessInputs()
    {
        if (InputEnabled)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;

            if (moveDir != Vector2.zero)
            {
                lastMoveDir = moveDir;
            }
        }
       
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    void Animate()
    {
        if (moveDir == Vector2.zero)
        {
            anim.SetFloat("MoveAnimX", lastMoveDir.x);
            anim.SetFloat("MoveAnimY", lastMoveDir.y);
            anim.SetFloat("MoveAnimMagnitude", moveDir.magnitude);
        }
        else
        {
            anim.SetFloat("MoveAnimX", moveDir.x);
            anim.SetFloat("MoveAnimY", moveDir.y);
            anim.SetFloat("MoveAnimMagnitude", moveDir.magnitude);
        }
    }

}
