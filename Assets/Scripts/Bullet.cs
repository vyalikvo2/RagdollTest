using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MAX_LIFETIME = 2f;
    
    private float _power;
    public float Power
    {
        get { return _power; }
    }
    
    private float _speed;
    public float Speed
    {
        get { return _speed; }
    }
    
    private Vector3 _direction;
    public Vector3 Direction
    {
        get { return _direction; }
    }

    private bool _inited = false;
    private float _lifetime = 0f;

    // -----------------------------------------------------------------------------
    public void Init(float speed, Vector3 direction, float power)
    {
        if (_inited) return;
        
        _speed = speed;
        _direction = direction.normalized;
        _power = power;
        
        _inited = true;
    }
    
    // -----------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            GEvent.BulletHitEnemy.Invoke(new GEventData_BulletHitEnemy(
                    transform.position,
                    _direction,
                    other.gameObject.GetComponent<Rigidbody>(),
                    _power
                )
            );
            
            Destroy(gameObject);
        }
    }
    
    // -----------------------------------------------------------------------------
    void Update()
    {
        if (_inited)
        {
            _lifetime += Time.deltaTime;
            transform.position += Direction * Speed * Time.deltaTime;

            if (_lifetime > MAX_LIFETIME)
            {
                Destroy(gameObject);
            }
        }
    }
}
