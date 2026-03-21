using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject hudPanel;
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
            healthText.text = $"Health: {Mathf.Round(player.GetHealth())}";
            medkitText.text = $"Medkits: {player.medkitsCollected}";

            float time = Time.timeSinceLevelLoad;
            timerText.text = $"{FormatTime(time)}";
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }

    public void GameOver(int medkits, float timeSurvived)
    {
        hudPanel.SetActive(false); // 🔥 Hide all HUD

        gameOverPanel.SetActive(true);

        string formattedTime = FormatTime(timeSurvived);

        finalScoreText.text =
            $"<size=150%><b>GAME OVER</b></size>\n\n" +
            $"<b>Time Survived</b>\n{formattedTime}\n\n" +
            $"<b>Medkits Collected</b>\n{medkits}";

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 🏠 Go to Main Menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); // Make sure scene name matches exactly
    }

    // ❌ Quit Game
    public void QuitGame()
    {
        Debug.Log("Game Quit"); // Helps in editor

        Application.Quit();
    }
}