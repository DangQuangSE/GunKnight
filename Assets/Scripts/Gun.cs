using UnityEngine;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform FirePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootDeplay = 0.15f;
    private float nextShoot;
    [SerializeField] private int maxAmmo = 24;
    public int currentAmmo;
    void Start()
    {
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        RotateGun();
        Shoot();
        Shoot();
        ReloadAmmo();
    }
    void RotateGun()
    {
        if(Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        if(angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shoot()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextShoot && currentAmmo > 0)
        {
            nextShoot = Time.time + shootDeplay;
            Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
            currentAmmo--;
        }
    }
    void ReloadAmmo()
    {
        if(Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
}
