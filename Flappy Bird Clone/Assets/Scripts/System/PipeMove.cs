using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private float speed;
    public float _speed { set { speed = value; } }

    void Update()
    {
        if (!GameManager.inPlay) return;

        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= -10f) Destroy(gameObject);

    }

}
