using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    [Header("Pipes")]
    [SerializeField] private GameObject pipes;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float timer;

    public float _timeSpawn { set { timeSpawn = value; } }
    void Update()
    {
       if (!GameManager.inPlay) return;
        Spawn();
    }

    void Spawn()
    {
        if (timer >= timeSpawn)
        {
            timer = 0;
            float y = Random.Range(0, 4f);
            Instantiate(pipes, new Vector2(transform.position.x, y), Quaternion.identity);
        }
        timer += Time.deltaTime;
    }
}
