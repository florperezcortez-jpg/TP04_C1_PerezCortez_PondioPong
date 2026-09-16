using TMPro;
using Unity.VisualScripting;

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Configuracion del partido")]
    [SerializeField] private GameSettings settings;

    [Header("Textos del marcador")]
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;

    [Header("Fin del partido")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text winText;


    [Header("Timer por gol")]
    [SerializeField] private Transform ball;
    [SerializeField] private TMP_Text timerText;
    private float goalTimer;
    public int player1Score = 0;
    public int player2Score = 0;

    public bool MatchOver { get; private set; } = false;

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
      

        if (winPanel != null)
            winPanel.SetActive(false);

        ResetGoalTimer();
    }
    void Update()
    {
        if (MatchOver) return;
        goalTimer -= Time.deltaTime;

        if (timerText != null)
            timerText.text = Mathf.CeilToInt(Mathf.Max(goalTimer, 0f)).ToString();

        if (goalTimer <= 0f)
        {
            //se acaba el tiempo: gol en contra de quien tenga la pelota de su lado
            if (ball.position.x < 0f)
                AddPointPlayer2();
            else
                AddPointPlayer1();
        }
    }
    public void ResetGoalTimer()
    {
        goalTimer = settings.goalTimeLimit;
    }
    public void AddPointPlayer1()
    {
        if (MatchOver) return; //no sumar puntos cuando terminó
        player1Score++;
        UpdateScoreText();
        ResetGoalTimer();
        CheckForWinner();
    }
    public void AddPointPlayer2()
    {
        if (MatchOver) return;
        player2Score++;
        UpdateScoreText();
        ResetGoalTimer();
        CheckForWinner();
    }
    
    private void CheckForWinner()
    { 
        if (player1Score >= settings.pointsToWin)
    {
        EndMatch("¡Ganó el jugador 1!");
    }
    else if (player2Score >= settings.pointsToWin)
        {
            EndMatch("¡Ganó el jugador 2!");
        }
    }
    private void EndMatch(string message)
    {
        MatchOver = true;
            if (winText != null)
    
            {
                winText.gameObject.SetActive(true); 
                winText.text = message;
            }

        if (winPanel != null)
            winPanel.SetActive(true);
    }

    private void UpdateScoreText()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }
}
   