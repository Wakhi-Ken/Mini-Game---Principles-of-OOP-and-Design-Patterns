using UnityEngine;
using TMPro; // TextMeshPro namespace
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI medkitText;
    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    private PlayerController player;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (player != null)
        {
            healthText.text = "Health: " + Mathf.Round(player.GetHealth());
            medkitText.text = "Medkits: " + player.medkitsCollected;
            timerText.text = "Time: " + Mathf.Floor(Time.timeSinceLevelLoad) + "s";
        }
    }

    public void GameOver(int medkits, float timeSurvived)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Survived: " + Mathf.Floor(timeSurvived) + "s\nMedkits: " + medkits;

        Time.timeScale = 0f; // Freeze game

        // Show mouse cursor for Game Over menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}