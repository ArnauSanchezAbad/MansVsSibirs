using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    Transform player;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    public void Defeat()
    {
        // Aquí puedes poner animación o efectos
        Destroy(gameObject);
    }
}
