using UnityEngine;

public class Ink : MonoBehaviour
{
    [SerializeField] private float _inkSpeed;
    [SerializeField] private float _lifeTime;

    private float _currentTime;

    private void Update()
    {
        InkMove();
        DestroyInk();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Headgehog>(out Headgehog headgehog))
        {
            headgehog.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void InkMove()
    {
        transform.Translate(-transform.up * _inkSpeed * Time.deltaTime, Space.World);
    }

    private void DestroyInk()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _lifeTime)
            Destroy(this.gameObject);
    }
}
