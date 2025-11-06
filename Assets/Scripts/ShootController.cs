using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float range = 50f;
    public LayerMask enemyLayer;
    public Camera arCamera;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(arCamera.transform.position, arCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyLayer))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Defeat();
            }
        }
    }
}
