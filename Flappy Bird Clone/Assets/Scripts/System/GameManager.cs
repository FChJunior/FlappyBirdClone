using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Pontuação")]
    [SerializeField] private TextMeshProUGUI textPoint;
    public static int points;

    [Header("Game Play")]
    public static bool inPlay;
    public static bool gameOver;

    [Header("HUD")]
    [SerializeField] private GameObject menuHUD;
    [SerializeField] private GameObject gameOverHUD;
    [SerializeField] private GameObject getReadyHUD;
    [SerializeField] private GameObject pointsHUD;

    private bool menu;
    private void Start()
    {
        points = 0;
        inPlay = false;
        gameOver = false;
        menu = true;
    }

    private void Update()
    {
        Points();
        GameOver();
    }

    private void LateUpdate()
    {
        if (!menu && Input.GetMouseButtonDown(0) && !gameOver) GetReady();
    }

    public void StartGame()
    {
        menu = false;
        menuHUD.SetActive(false);
        getReadyHUD.SetActive(true);

    }
    private void GetReady()
    {
        inPlay = true;
        getReadyHUD.SetActive(false);
        pointsHUD.SetActive(true);
    }
    private void Points()
    {
        textPoint.text = points.ToString();
    }

    private void GameOver()
    {
        if (gameOver)
        {
            gameOverHUD.SetActive(true);
            pointsHUD.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    bool pauseState = false;
    [SerializeField] Animator button;
    public void Pause()
    {
        pauseState = !pauseState;
        button.SetBool("Pause", pauseState);

        if (pauseState) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

}
