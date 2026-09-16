
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Teclas Verticales")]
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;

    [Header("Teclas horizontales")]
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    [Header("Límites de cancha (X = su lado)")]
    [SerializeField] private float minX = -9.02f;
    [SerializeField] private float maxX = -0.1f;

    [Header("Color")]
    [SerializeField] private PaddleColor paddleColor;

    [Header("Movimiento")]
    [SerializeField] private float maxSpeed = 10f;
    public float speed = 15f;

    private Rigidbody2D rb;
    private Vector2 inputDirection;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
{
        if (ScoreManager.Instance != null && ScoreManager.Instance.MatchOver)
        {
            inputDirection = Vector2.zero; 
            return;
        }
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(upKey)) y = 1f;

        if (Input.GetKey(downKey)) y = -1f;

        if (Input.GetKey(rightKey)) x = 1f;
        if (Input.GetKey(leftKey)) x = -1f;

        inputDirection = new Vector2(x, y);
    }
    void FixedUpdate()
    {

        if (ScoreManager.Instance != null && ScoreManager.Instance.MatchOver)
        {
            rb.linearVelocity = Vector2.zero; //frenar en seco cuando termina

            return; // partido terminado, no se mueve más
        }
        if (inputDirection != Vector2.zero)
        {
            //empuje vertical
            rb.AddForce(inputDirection.normalized * speed);

            //limitar velocidad
            if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        // Limitar al propio lado de la cancha (no hay pared física en el medio)
        float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
        rb.position = new Vector2(clampedX, rb.position.y);
    }

void LateUpdate()
{
    float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
    if (!Mathf.Approximately(clampedX, rb.position.x))
        rb.position = new Vector2(clampedX, rb.position.y);
}
}