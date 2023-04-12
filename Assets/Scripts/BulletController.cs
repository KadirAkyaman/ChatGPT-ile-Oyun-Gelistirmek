using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera mainCamera;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    private float fireCountdown = 0f;

    public float bulletLifeTime = 10f;

    void Update()
    {
        if (Input.GetButton("Fire1") && fireCountdown <= 0f)
        {
            fireCountdown = fireRate;
            Shoot();
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Vector3 cameraCenter = new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(cameraCenter);
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            // 1000 birim mesafede hedef oluþtur
            targetPoint = mainCamera.transform.position + mainCamera.transform.forward * 1000f;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (targetPoint - firePoint.position).normalized * bulletSpeed;

        Destroy(bullet, bulletLifeTime);
    }
}