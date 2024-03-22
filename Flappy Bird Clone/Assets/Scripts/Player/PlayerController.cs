using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Fisica")]
    [SerializeField] private Rigidbody2D bird; // Referência para o Rigidbody do pássaro
    [SerializeField] private float jumpForce; // Força do pulo
    [SerializeField] private float speedRotation; // Velocidade de rotação
    [SerializeField] private float angle; // Ângulo de inclinação

    [Header("GameOver")]
    [SerializeField] private Animator anim; // Referência para o Animator
    [SerializeField] private Collider2D coliderBird; // Referência para o Collider do pássaro
    [SerializeField] private LayerMask pipe; // Máscara de camada para os canos

    private void Start()
    {
        bird.gravityScale = 0f; // Desliga a gravidade no início
    }

    void Update()
    {
        Rotation(); // Função de controle da rotação do pássaro
        if (!GameManager.inPlay) return; // Se o jogo não estiver em andamento, não faz nada
        bird.gravityScale = 1.5f; // Liga a gravidade do pássaro
        Jump(); // Função de controle do pulo
    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi pressionado
        {
            AudioManager.Wing(); // Chama o som de asa batendo
            bird.velocity = Vector2.zero; // Zera a velocidade atual do pássaro
            bird.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica uma força para cima no pássaro
        }
    }

    void Rotation()
    {
        if (bird.velocity.y < 0) // Se o pássaro estiver descendo
        {
            if (transform.eulerAngles.z > -angle) transform.eulerAngles -= Vector3.forward * speedRotation * Time.deltaTime; // Rotação para baixo
            else transform.eulerAngles = Vector3.forward * -angle; // Mantém a inclinação máxima
        }
        else if (bird.velocity.y > 0) // Se o pássaro estiver subindo
        {
            if (transform.eulerAngles.z < angle) transform.eulerAngles += Vector3.forward * speedRotation * Time.deltaTime; // Rotação para cima
            else transform.eulerAngles = Vector3.forward * angle; // Mantém a inclinação máxima
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Point" && GameManager.inPlay) // Se colidir com um objeto de ponto e o jogo estiver em andamento
        {
            AudioManager.Point(); // Chama o som de pontuação
            GameManager.points++; // Incrementa a pontuação
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GameOver" && !GameManager.gameOver) // Se colidir com um objeto de final de jogo e o jogo não estiver encerrado
        {
            if (!GameManager.gameOver) // Se o jogo ainda não estiver encerrado
            {
                AudioManager.Hit(); // Chama o som de colisão
                bird.velocity = Vector2.zero; // Zera a velocidade do pássaro
                bird.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica uma força para cima no pássaro
            }
            GameManager.gameOver = true; // Define o estado de jogo como encerrado
            GameManager.inPlay = false; // Define o estado de jogo como não em andamento
            coliderBird.excludeLayers = pipe; // Exclui a camada do pássaro para evitar colisões com canos
            anim.SetBool("Dead", true); // Define a animação de morte como verdadeira
            AudioManager.Die(); // Chama o som de morte
        }
    }
}
