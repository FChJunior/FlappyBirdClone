using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Pontuação")]  // Define uma seção de cabeçalho para variáveis de pontuação.
    [SerializeField] private TextMeshProUGUI textPoint;  // Referência ao objeto de texto para exibir a pontuação.
    public static int points;  // Pontuação atual do jogador.

    [Header("Game Play")]  // Define uma seção de cabeçalho para variáveis de jogabilidade.
    public static bool inPlay;  // Estado do jogo (se o jogo está em andamento).
    public static bool gameOver;  // Estado do jogo (se o jogo terminou).
    private float timerDifficulty = 0;  // Contador para controlar a dificuldade do jogo.
    private float countPoits = 0;  // Contador para controlar a pontuação.
    [SerializeField] private SpawnPipes spawnPipes;  // Referência ao script responsável por criar obstáculos.
    [SerializeField] private ScenaryMove scenaryMove;  // Referência ao script responsável por mover o cenário.

    [Header("HUD - Telas")]  // Define uma seção de cabeçalho para objetos de interface do usuário (HUD).
    [SerializeField] private GameObject menuHUD;  // Objeto que contém o menu do jogo.
    [SerializeField] private GameObject gameOverHUD;  // Objeto que contém a tela de fim de jogo.
    [SerializeField] private GameObject getReadyHUD;  // Objeto que contém a tela de preparação para o jogo.
    [SerializeField] private GameObject pointsHUD;  // Objeto que contém a pontuação durante o jogo.

    [Header("HUD - Placar")]  // Define uma seção de cabeçalho para objetos de pontuação na HUD.
    [SerializeField] private TextMeshProUGUI scroreHUD;  // Objeto de texto para exibir a pontuação atual na HUD.
    [SerializeField] private TextMeshProUGUI bestHUD;  // Objeto de texto para exibir a melhor pontuação na HUD.
    [SerializeField] private float score = 0;  // Pontuação atual (usada para animação de contagem regressiva).
    [SerializeField] private int best = 0;  // Melhor pontuação registrada.
    [SerializeField] private GameObject newImage;  // Objeto que exibe uma imagem quando o jogador bate o recorde anterior.
    [SerializeField] private Animator medal;  // Controlador de animação para exibir medalhas de conquista.
    [SerializeField] private Animator button;  // Controlador de animação para o botão de pausa.
    public static bool pauseState = false;  // Estado de pausa do jogo.
    private bool newBest = false;  // Indica se o jogador alcançou uma nova melhor pontuação.
    private bool menu;  // Estado do menu do jogo.

    private void Start()
    {
        points = 0;  // Inicializa a pontuação como zero no início do jogo.
        inPlay = false;  // Define o estado do jogo como não iniciado no início.
        gameOver = false;  // Define o estado do jogo como não terminado no início.
        menu = true;  // Define o estado do menu como visível no início.
    }

    private void Update()
    {
        Points();  // Atualiza a exibição da pontuação.
        GameOver();  // Verifica se o jogo terminou.
        if (inPlay) Difficulty();  // Ajusta a dificuldade do jogo se estiver em execução.
        if (gameOver) BestScore();  // Atualiza a melhor pontuação quando o jogo termina.
    }

    private void LateUpdate()
    {
        if (!menu && Input.GetMouseButtonDown(0) && !gameOver && !inPlay) GetReady();  // Inicia o jogo quando o jogador toca na tela.
    }

    public void StartGame()
    {
        AudioManager.Swoosh();  // Toca um som de início de jogo.
        menu = false;  // Define o estado do menu como não visível.
        menuHUD.SetActive(false);  // Desativa o menu do jogo.
        getReadyHUD.SetActive(true);  // Ativa a tela de preparação para o jogo.
    }

    private void GetReady()
    {
        AudioManager.Swoosh();  // Toca um som de início de jogo.
        inPlay = true;  // Define o estado do jogo como em execução.
        getReadyHUD.SetActive(false);  // Desativa a tela de preparação para o jogo.
        pointsHUD.SetActive(true);  // Ativa a exibição da pontuação durante o jogo.
    }

    private void Points()
    {
        textPoint.text = points.ToString();  // Atualiza o texto da pontuação na HUD.
    }

    private void GameOver()
    {
        if (gameOver)
        {
            gameOverHUD.SetActive(true);  // Exibe a tela de fim de jogo.
            pointsHUD.SetActive(false);  // Oculta a exibição da pontuação durante o jogo.
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);  // Reinicia o jogo recarregando a cena atual.
    }

    public void Pause()
    {
        pauseState = !pauseState;  // Alterna o estado de pausa.
        button.SetBool("Pause", pauseState);  // Atualiza a animação do botão de pausa.

        if (pauseState) Time.timeScale = 0;  // Pausa o tempo do jogo se o jogo estiver pausado.
        else Time.timeScale = 1;  // Restaura o tempo do jogo se o jogo não estiver pausado.
    }

    void BestScore()
    {
        if (points > score)  // Verifica se a pontuação atual é maior que a pontuação de animação.
        {
            score += Time.deltaTime * 10;  // Atualiza a pontuação de animação gradualmente.
            scroreHUD.text = score.ToString("0");  // Atualiza o texto da pontuação na HUD.
            return;
        }

        if (points > PlayerPrefs.GetInt("bestScore"))  // Verifica se a pontuação atual é maior que a melhor pontuação registrada.
        {
            newImage.SetActive(true);  // Exibe a imagem de nova melhor pontuação.
            PlayerPrefs.SetInt("bestScore", points);  // Atualiza a melhor pontuação registrada.
            best = points;  // Atualiza a melhor pontuação atual.
            newBest = true;  // Indica que o jogador alcançou uma nova melhor pontuação.
        }
        else
        {
            best = PlayerPrefs.GetInt("bestScore");  // Obtém a melhor pontuação registrada.
        }

        bestHUD.text = best.ToString();  // Atualiza o texto da melhor pontuação na HUD.

        if (points > (best * 0.5f)) medal.gameObject.SetActive(true);  // Ativa a exibição da medalha se o jogador alcançou pelo menos metade da melhor pontuação.
        if (points == best && newBest) medal.SetFloat("Medal", 2);  // Define a animação da medalha para 2 (medalha especial) se o jogador bateu o recorde anterior.
        else if (points >= (best * 0.8f)) medal.SetFloat("Medal", 1);  // Define a animação da medalha para 1 (medalha de prata) se o jogador alcançou 80% ou mais da melhor pontuação.
        else if (points >= (best * 0.5f)) medal.SetFloat("Medal", 0);  // Define a animação da medalha para 0 (medalha de bronze) se o jogador alcançou 50% ou mais da melhor pontuação.
    }

    void Difficulty()
    {
        if (timerDifficulty != points)  // Verifica se houve um aumento na pontuação.
        {
            timerDifficulty = points;  // Atualiza o temporizador de dificuldade com a pontuação atual.
            countPoits++;  // Incrementa o contador de pontos.
        }
        if (countPoits == 10)  // Se o contador atingiu 10 pontos.
        {
            countPoits = 0;  // Reinicia o contador.
            spawnPipes.SetTimer(0.1f);  // Ajusta o intervalo de tempo para a geração de obstáculos.
            scenaryMove.SetTimer(0.01f);  // Ajusta o intervalo de tempo para o movimento do cenário.
        }
    }
}
