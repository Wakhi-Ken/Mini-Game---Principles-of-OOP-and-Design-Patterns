using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance;
    // UI References
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
        // Find the player in the scene
        player = FindObjectOfType<PlayerController>();

        PlayerController.OnHealthChanged += UpdateHealthUI;

        gameOverPanel.SetActive(false);
    }



    void Update()
    {
        // Update medkit count and timer
        if (player != null)
        {
            medkitText.text = $"Medkits: {player.medkitsCollected}";

            float time = Time.timeSinceLevelLoad;
            timerText.text = $"{FormatTime(time)}";
        }
    }

    void UpdateHealthUI(float health)
    {
        // Update health text with rounded value
        healthText.text = $"Health: {Mathf.Round(health)}";
    }

    string FormatTime(float time)
    {
        // Format time as MM:SS
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }

    public void GameOver(int medkits, float timeSurvived)
    {
        // Show game over screen with final stats
        hudPanel.SetActive(false);
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
        // Restart the current scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        // Load the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        
        Debug.Log("Game Quit");
        Application.Quit();
    }
}