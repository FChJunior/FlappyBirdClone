using UnityEngine;

public class ScenaryMove : MonoBehaviour
{
    [Header("Materiais Cenário")]  // Define uma seção de cabeçalho para os materiais do cenário.
    [SerializeField] private SpriteRenderer ground;  // Referência ao sprite do chão.
    [SerializeField] private SpriteRenderer backGround;  // Referência ao sprite do plano de fundo.
    [SerializeField] private float speedScenary;  // Velocidade de movimento do cenário.

    void Update()
    {
        if (GameManager.gameOver) return;  // Se o jogo terminou, interrompe o movimento do cenário.

        // Move os materiais do cenário com base na velocidade definida.
        ground.material.mainTextureOffset += Vector2.right * speedScenary * Time.deltaTime;
        backGround.material.mainTextureOffset += Vector2.right * (speedScenary * 0.7f) * Time.deltaTime;
    }

    // Método para ajustar a velocidade do cenário.
    public void SetTimer(float t)
    {
        speedScenary += t;  // Ajusta a velocidade do cenário com base no valor passado como parâmetro.
    }
}
