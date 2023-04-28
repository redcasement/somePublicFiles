using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private Blood _blood;

    private Rigidbody2D _rigidbody;

    private float _elapsedTime;
    private bool _isFlying;
    private Vector2 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_isFlying)
            return;

        _rigidbody.velocity = _direction * _speed;

        _elapsedTime += Time.fixedDeltaTime;

        if (_elapsedTime >= _lifeTime)
            Destroy(gameObject);
    }

    public void FlyInDirection(Vector2 direction)
    {
        _isFlying = true;
        _direction = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject blood = Instantiate(_blood.gameObject);
            blood.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}