using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class PaddleColor : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SetLimitColor()
    {
        sr.color = Color.black;
    }

    public void SetRandomColor()
    {
        sr.color = new Color(Random.value, Random.value, Random.value);
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
      

        if (collision.gameObject.CompareTag("Ball"))
        {
            SetRandomColor();
        }
       else if (collision.gameObject.CompareTag("TopWall") || collision.gameObject.CompareTag("BottomWall"))
        {
            SetLimitColor();       
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
