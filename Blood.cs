using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;

    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _lifeTime)
            Destroy(gameObject);
    }
}