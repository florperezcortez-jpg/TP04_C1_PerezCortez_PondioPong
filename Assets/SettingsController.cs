
using TMPro;
using UnityEngine;
    using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Movimiento de Jugadores")]
    [SerializeField] private Mover player1;
    [SerializeField] private Mover player2;

    [Header("Colliders de Jugadores (para que el alto también los afecte)")]
    [SerializeField] private BoxCollider2D player1Collider;
    [SerializeField] private BoxCollider2D player2Collider;

    [Header("Sprites de Jugadores (para alto y color)")]
    [SerializeField] private SpriteRenderer player1Sprite;
    [SerializeField] private SpriteRenderer player2Sprite;


    [Header("Sliders de velocidad")]
    [SerializeField] private Slider sliderP1;
    [SerializeField] private TMP_Text textP1;
    [SerializeField] private Slider sliderP2;
    [SerializeField] private TMP_Text textP2;

    [Header("Sliders de Alto de Paleta")]
    [SerializeField] private Slider sliderHeightP1;
    [SerializeField] private TMP_Text textHeightP1;
    [SerializeField] private Slider sliderHeightP2;
    [SerializeField] private TMP_Text textHeightP2;

    [Header("Sliders de Color)")]
    [SerializeField] private Slider sliderColorP1;
    [SerializeField] private Slider sliderColorP2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //velocidad
        sliderP1.value = player1.speed;
        sliderP2.value = player2.speed;
        textP1.text = player1.speed.ToString("F1");
        textP2.text = player2.speed.ToString("F1");

        sliderP1.onValueChanged.AddListener(OnP1SpeedChanged);
        sliderP2.onValueChanged.AddListener(OnP2SpeedChanged);

        //alto de paleta
        sliderHeightP1.value = player1Sprite.size.y;
        sliderHeightP2.value = player2Sprite.size.y;
        textHeightP1.text = player1Sprite.size.y.ToString("F1");
        textHeightP2.text = player2Sprite.size.y.ToString("F1");

        sliderHeightP1.onValueChanged.AddListener(OnP1HeightChanged);
        sliderHeightP2.onValueChanged.AddListener(OnP2HeightChanged);

        // Color
        sliderColorP1.onValueChanged.AddListener(OnP1ColorChanged);
        sliderColorP2.onValueChanged.AddListener(OnP2ColorChanged);
    }
    void OnP1SpeedChanged (float value)
    {
        player1.speed = value;

        textP1.text = value.ToString("F1");

    }
    void OnP2SpeedChanged (float value)
    {
        player2.speed = value;
        textP2.text = value.ToString("F1");
    }
    void OnP1HeightChanged(float value)
    {
        //solo cambia alto
        player1Sprite.size = new Vector2(player1Sprite.size.x, value);
        if (player1Collider != null)
            player1Collider.size = new Vector2(player1Collider.size.x, value);
        textHeightP1.text = value.ToString("F1");
    }
    void OnP2HeightChanged(float value)
    {
        player2Sprite.size = new Vector2(player2Sprite.size.x, value);
        if (player2Collider != null)
            player2Collider.size = new Vector2(player2Collider.size.x, value);
        textHeightP2.text = value.ToString("F1");
    }
          
    void OnP1ColorChanged(float value)
    {
        player1Sprite.color = Color.HSVToRGB(value, 1f, 1f);
    }

    void OnP2ColorChanged(float value)
    {
        player2Sprite.color = Color.HSVToRGB(value, 1f, 1f);
    }
}
