using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _muzzle;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.transform.position = _muzzle.position;

        Vector3 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - _muzzle.position;
        bullet.FlyInDirection(direction);
    }
}