using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Range(0, 10)] public float Speed = 1;
    [SerializeField] private ParticleSystem _deathEffect;
    public GameObject[] parts = new GameObject[0];
    private Rigidbody _rb;
    private Vector3 _movement;
    private bool _isDead;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var h = Input.GetAxis(Constants.HorizontalAxis);
        var v = Input.GetAxis(Constants.VerticalAxis);

        _movement = new Vector3(h, 0, v);
    }

    void FixedUpdate()
    {
        _rb.AddForce(_movement.normalized * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    private void Die()
    {
        if (!_isDead)
        {
            _isDead = true;
            _deathEffect.transform.parent = null;
            _deathEffect.Play();
            foreach(GameObject onePart in parts) {
                onePart.SetActive(true);
                onePart.AddComponent<Rigidbody>();
                onePart.transform.parent = null;
            }
            Destroy(gameObject);
        }
    }


#if UNITY_EDITOR
    [ContextMenu("Reset values")]
    private void ResetValues()
    {
        Speed = 1;
    }
#endif
}
