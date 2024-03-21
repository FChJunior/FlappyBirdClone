using UnityEngine;

public class ScenaryMove : MonoBehaviour
{
    [Header("Materiais Cenário")]
    [SerializeField] private SpriteRenderer ground;
    [SerializeField] private SpriteRenderer backGround;
    [SerializeField] private float speedScenary;
    public float _speedScenary { set { speedScenary = value; } }

    void Update()
    {
        if (GameManager.gameOver) return;

        ground.material.mainTextureOffset += Vector2.right * speedScenary * Time.deltaTime;
        backGround.material.mainTextureOffset += Vector2.right * (speedScenary * 0.7f) * Time.deltaTime;
    }

}
