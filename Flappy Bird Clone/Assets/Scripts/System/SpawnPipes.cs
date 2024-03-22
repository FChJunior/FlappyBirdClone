using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    [Header("Pipes")]
    [SerializeField] private GameObject pipes; // Prefab dos canos
    [SerializeField] private float timeSpawn; // Intervalo de tempo para spawn dos canos
    [SerializeField] private float timer; // Contador de tempo

    void Update()
    {
        if (!GameManager.inPlay) return; // Se o jogo não estiver em andamento, não faz nada
        Spawn(); // Chama a função de spawn dos canos
    }

    void Spawn()
    {
        if (timer >= timeSpawn) // Se o contador de tempo alcançou o intervalo de spawn
        {
            timer = 0; // Reinicia o contador de tempo
            float y = Random.Range(0, 4f); // Define uma posição aleatória em y para o spawn dos canos
            Instantiate(pipes, new Vector2(transform.position.x, y), Quaternion.identity); // Instancia os canos na posição adequada
        }
        timer += Time.deltaTime; // Atualiza o contador de tempo
    }

    public void SetTimer(float t)
    {
        timeSpawn -= t; // Ajusta o intervalo de tempo para o spawn dos canos
        pipes.GetComponent<PipeMove>().SetSpeed(0.2f); // Ajusta a velocidade dos canos
    }
}
