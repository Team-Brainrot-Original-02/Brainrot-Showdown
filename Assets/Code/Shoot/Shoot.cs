using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingMuzzle;
    public GameObject bulletPrefab;
    public float fireRate;
    public bool canShoot;

    private void Start()
    {
        canShoot = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            ShootBullet();
            canShoot = false;
            StartCoroutine(ShootCoolDown());
        }
    }

    IEnumerator ShootCoolDown()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, shootingMuzzle.position, shootingMuzzle.rotation);
    }
}
