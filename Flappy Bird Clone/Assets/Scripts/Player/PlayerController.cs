using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Fisica")]
    [SerializeField] private Rigidbody2D bird;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speedRotation;
    [SerializeField] private float angle;

    [Header("GameOver")]
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D coliderBird;
    [SerializeField] private LayerMask pipe;

    private void Start()
    {
        bird.gravityScale = 0f;
    }
    void Update()
    {
        Rotation();
        if (!GameManager.inPlay) return;
        bird.gravityScale = 1.5f;
        Jump();
    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bird.velocity = Vector2.zero;
            bird.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void Rotation()
    {
        if (bird.velocity.y < 0)
        {
            if (transform.eulerAngles.z > -angle) transform.eulerAngles -= Vector3.forward * speedRotation * Time.deltaTime;
            else transform.eulerAngles = Vector3.forward * -angle;
        }
        else if (bird.velocity.y > 0)
        {
            if (transform.eulerAngles.z < angle) transform.eulerAngles += Vector3.forward * speedRotation * Time.deltaTime;
            else transform.eulerAngles = Vector3.forward * angle;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Point")
        {
            GameManager.points++;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            if (!GameManager.gameOver)
            {
                bird.velocity = Vector2.zero;
                bird.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            GameManager.gameOver = true;
            GameManager.inPlay = false;
            coliderBird.excludeLayers = pipe;
            anim.SetBool("Dead", true);
        }
    }
}
