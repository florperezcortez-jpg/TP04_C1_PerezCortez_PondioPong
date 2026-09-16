
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.1f;
    [SerializeField] private float maxSpeed = 15f;
    public float speed = 4f;
    private Rigidbody2D rb;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Start()
    {
        ResetBall();
    }


    void Update()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.MatchOver) 
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.MatchOver)
            return; // partido terminado, no hacer nada más

        if (other.CompareTag("LeftWall"))
        {

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddPointPlayer2();
        ResetBall();
    }
  else if (other .CompareTag("RightWall"))
        {
        if (ScoreManager.Instance != null)
        ScoreManager.Instance.AddPointPlayer1();
        ResetBall();
        }
    }

public void ResetBall ()
{
    transform.position = Vector3.zero;

       float dirX = UnityEngine.Random.value < 0.5f ? -1f : 1f;
        float dirY = UnityEngine.Random.value < 0.5f ? -1f : 1f;
    Vector2 direction = new Vector2(dirX, dirY).normalized;

rb.linearVelocity = direction * speed;
}
    void OnCollisionEnter2D(Collision2D collision)
    {
 

        rb.linearVelocity *= speedMultiplier;
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
    }
