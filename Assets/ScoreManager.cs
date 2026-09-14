using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [Header("Textos del marcador")]
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;
    public int player1Score = 0;
    public int player2Score = 0;

    void Awake()
    {
        //patron singleton; una sola instancia accesible de todos lados

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }
     void Start()
    {
        UpdateScoreText();
    }
    public void AddPointPlayer1()
    {
        player1Score++;
        UpdateScoreText();
    }
    public void AddPointPlayer2()
    {
        player2Score++;
        UpdateScoreText();
    }
    

   private void UpdateScoreText()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }
}
   