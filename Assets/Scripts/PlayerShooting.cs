using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireCooldown = 0.3f;
    private bool canShoot = true;

    [Header("UI Arma")]
    public Image weaponImage;
    public Sprite spriteReady;
    public Sprite spriteShooting;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip shootSound;

    void Update()
    {
        if(Time.timeScale == 0f) audioSource.Pause();
        else audioSource.UnPause();

#if UNITY_EDITOR
        if (canShoot && Input.GetMouseButtonDown(0))
            Shoot();
#endif

        if (canShoot && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            Shoot();
    }

    void Shoot()
    {
        canShoot = false;
        weaponImage.sprite = spriteShooting;   // mostrar sprite “disparando”

        Camera cam = Camera.main;

        GameObject p = Instantiate(
            projectilePrefab,
            cam.transform.position,
            cam.transform.rotation
        );

        p.GetComponent<Projectile>().speed = projectileSpeed;

        if (audioSource && shootSound)
        audioSource.PlayOneShot(shootSound);

        Invoke(nameof(ResetWeapon), fireCooldown);
    }

    void ResetWeapon()
    {
        weaponImage.sprite = spriteReady; // sprite “lista”
        canShoot = true;
    }
}
