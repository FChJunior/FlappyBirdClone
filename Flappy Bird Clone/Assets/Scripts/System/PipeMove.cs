using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private float speed; // Velocidade de movimento do cano

    void Update()
    {
        if (!GameManager.inPlay) return; // Se o jogo não estiver em andamento, não faz nada

        transform.Translate(Vector3.left * speed * Time.deltaTime); // Move o cano para a esquerda
        if (transform.position.x <= -10f) Destroy(gameObject); // Destroi o cano quando ele sair da tela
    }

    public void SetSpeed(float s)
    {
        speed += s; // Ajusta a velocidade do cano
    }
}
