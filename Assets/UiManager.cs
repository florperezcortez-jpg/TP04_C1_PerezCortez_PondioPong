using UnityEngine.UI;
using UnityEngine;


public class UiManager : MonoBehaviour
{

    [Header("Jugadores")]

    [SerializeField] private GameObject player1Object; //cuadrado
    [SerializeField] private GameObject player2Object; //circulo
    [Header ("Main Menu Buttons")]
        [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;


    [Header("Pause Menu Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnPauseSettings;
    [SerializeField] private Button btnPauseCredits;
    [SerializeField] private Button btnPauseExit;

    [Header("Back Buttons")]
    [SerializeField] private Button btnSettingsBack;
    [SerializeField] private Button btnCreditsBack;

    [Header("Panels")]
    [SerializeField] private GameObject panelBack;   
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Fondos")]
    [SerializeField] private GameObject menuBackground;
    [SerializeField] private GameObject gameBackground;
    private bool isPaused = false;
    private bool gameStarted = false;

    private GameObject previousMenu;

    private void Awake()
    {
        //menu principal
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnSettings.onClick.AddListener(() => OpenSettings(panelBack));
        btnCredits.onClick.AddListener(() => OpenCredits(panelBack));
        btnExit.onClick.AddListener(OnExitClicked);
        //menu de pausa
        btnContinue.onClick.AddListener(OnContinuePressed);
        btnPauseSettings.onClick.AddListener(() => OpenSettings(pauseMenuPanel));
        btnPauseCredits.onClick.AddListener(() => OpenCredits(pauseMenuPanel));
        btnPauseExit.onClick.AddListener(OnExitClicked);
        //Botones Back
        btnSettingsBack.onClick.AddListener(OnBackPressed);
        btnCreditsBack.onClick.AddListener(OnBackPressed);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelBack.SetActive(true);
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        player1Object.SetActive(false);
        player2Object.SetActive(false);
        menuBackground.SetActive(true);
        gameBackground.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && Input.GetKeyDown(KeyCode.Escape))
 
            { 
            TogglePause();
        }
        }

    void OnPlayClicked()

    {
    panelBack.SetActive(false);
        player1Object.SetActive(true);
        player2Object.SetActive(true);
        gameStarted = true;
        menuBackground.SetActive(false);
        gameBackground.SetActive(true);
        Time.timeScale = 1f;

        }

void OpenSettings(GameObject callerMenu)
{
        previousMenu = callerMenu;
        callerMenu.SetActive(false);
  settingsPanel.SetActive(true);
}
void OpenCredits (GameObject callerMenu)
{
        previousMenu = callerMenu;
        callerMenu.SetActive(false);
        creditsPanel.SetActive(true);
}

void OnExitClicked()
{
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

 void OnBackPressed()
{
    settingsPanel.SetActive(false);
    creditsPanel.SetActive(false);
        if (previousMenu != null)
            previousMenu.SetActive(true);
}

void TogglePause()
{
    isPaused = !isPaused;
    pauseMenuPanel.SetActive(isPaused);
    Time.timeScale = isPaused ? 0f : 1f;
}

 void OnContinuePressed()
{
    TogglePause();
}
}
