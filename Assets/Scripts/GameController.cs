using UnityEngine;

public enum BulletPowerMode
{
    LIGHT,
    MEDIUM,
    HEAVY,
}

public class GameController : MonoBehaviour
{
    [Header("Bullet Power Settings")] [SerializeField] private BulletPowerMode _bulletPower;

    public static float BulletPower
    {
        get
        {
            switch (_instance?._bulletPower)
            {
                case BulletPowerMode.LIGHT:
                    return 10f;
                case BulletPowerMode.MEDIUM:
                    return 80f;
                case BulletPowerMode.HEAVY:
                    return 250f;
            }
            return 10f;
        }
    }
    
    [Header("GameObject Links")] 
    
    public GameObject EnemyPrefab;
    public Transform EnemySpawnTransform;

    private EnemyController _enemy;
    private GameObject _enemyGO;

    private static GameController _instance;
    
    // -----------------------------------------------------------------------------
    GameController()
    {
        _instance = this;
    }

    // -----------------------------------------------------------------------------
    void Start()
    {
        ResetEnemy();
        GEvent.BulletHitEnemy.Subscribe(OnBulletHitEnemy);
    }
    
    // -----------------------------------------------------------------------------
    public void ResetEnemy()
    {
        if (_enemyGO != null)
        {
            Destroy(_enemyGO);
            _enemy = null;
        }
        Time.timeScale = 1f;
        _enemyGO = Instantiate(EnemyPrefab, transform);
        _enemyGO.transform.position = EnemySpawnTransform.position;
        _enemy = _enemyGO.GetComponent<EnemyController>();
    }

    public void OnBulletHitEnemy(GEventData_BulletHitEnemy eventData)
    {
        Debug.Log("hit rigid body: " + eventData.RigidBody);
        Time.timeScale = 0.3f;
        _enemy.Hit(eventData.HitDirection * eventData.Power, eventData.HitPosition, eventData.RigidBody);
    }
}
