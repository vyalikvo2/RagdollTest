using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform BulletSpawnTransform;
    public Transform BulletContainer;
    public GameObject BulletPrefab;
    
    private float _bulletSpeed = 5f;

    // -----------------------------------------------------------------------------
    private void Shoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag != "Enemy") return;
                
            GameObject bulletGO = Instantiate(BulletPrefab, BulletContainer) as GameObject;
            bulletGO.transform.position = BulletSpawnTransform.position;
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.Init(_bulletSpeed, (hit.point-BulletSpawnTransform.position).normalized, GameController.BulletPower);
        }
        
    }
    
    // -----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
