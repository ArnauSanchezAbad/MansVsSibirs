using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 1;
    public int life = 1;

    Transform player;
    GameManager gm;

    void Start()
    {
        player = Camera.main.transform;
        gm = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        transform.LookAt(player.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void TakeDamage(int dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            gm.AddScore(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.LoseLife(damage);
            Destroy(gameObject);
        }
    }
}
