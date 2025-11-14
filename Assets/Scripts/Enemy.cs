using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 1f;
    public int damage = 1;
    public int life = 1;

    [Header("Sprites")]
    public Sprite spriteA;
    public Sprite spriteB;
    public Sprite spriteHit;
    public Sprite spriteEscape;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip loopSound;
    public AudioClip hitSound;
    public AudioClip attackSound;

    private SpriteRenderer sr;
    private Transform player;
    private GameManager gm;

    private bool dying = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = Camera.main.transform;
        gm = FindFirstObjectByType<GameManager>();

        InvokeRepeating(nameof(SwapWalkSprite), 0.2f, 0.2f);

        if (audioSource && loopSound)
        {
            audioSource.clip = loopSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (dying) return;

        if(Time.timeScale == 0f) audioSource.Pause();
        else audioSource.UnPause();

        transform.LookAt(player.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void SwapWalkSprite()
    {
        if (dying) return;

        sr.sprite = (sr.sprite == spriteA) ? spriteB : spriteA;
    }

    public void TakeDamage(int dmg)
    {
        if (dying) return;

        life -= dmg;


        if (audioSource && hitSound)
            audioSource.PlayOneShot(hitSound);

        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dying = true;
        CancelInvoke(nameof(SwapWalkSprite));

        gm.AddScore(1);

        GetComponent<Collider>().enabled = false;

        sr.sprite = spriteHit;

        speed = 0f;

        audioSource.loop = false;

        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dying) return;

        if (other.CompareTag("Player"))
        {
            gm.LoseLife(damage);

            if (audioSource && attackSound)
                audioSource.PlayOneShot(attackSound);

            EscapeAndDie();
        }
    }

    void EscapeAndDie()
    {
        dying = true;
        CancelInvoke(nameof(SwapWalkSprite));

        GetComponent<Collider>().enabled = false;

        sr.sprite = spriteEscape;

        audioSource.loop = false;

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 0.5f, ForceMode.Impulse);

        Destroy(gameObject, 1.2f);
    }
}
