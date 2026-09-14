
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Teclas de Mmovimiento")]
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;

    [Header("Limites de cancha")]
    [SerializeField] private float minY = -3.93f;
    [SerializeField] private float maxY = 3.94f;
public float speed = 5f;
    
    void Update()
{
    float step = speed * Time.deltaTime;
    if (Input.GetKey(upKey))
                transform.Translate(Vector2.up * step);
        if (Input.GetKey(downKey))
            transform.Translate(Vector2.down * step);

//que no se escape de la cancha
float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
}
 }