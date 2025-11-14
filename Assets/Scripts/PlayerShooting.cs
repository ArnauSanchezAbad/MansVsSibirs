using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    void Update()
    {
        // Simulador / Editor: clic izquierdo
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
#endif

        // Móvil real
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Camera cam = Camera.main;

        GameObject p = Instantiate(
            projectilePrefab,
            cam.transform.position,
            cam.transform.rotation
        );

        p.GetComponent<Projectile>().speed = projectileSpeed;
    }
}
