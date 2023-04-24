using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Range(0, 10)] public float Speed = 1;
    [SerializeField] private ParticleSystem _deathEffect;
    public GameObject[] parts = new GameObject[0];
    private Rigidbody _rb;

    private bool _isDead;
    private GameObject _body;
    private PlayerInput _pInput;
    private Animator _anim;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pInput = GetComponent<PlayerInput>();
        _anim = GetComponent<Animator>();
        _body = transform.Find("Body").gameObject;

        _anim.SetFloat("Speed", Speed);
    }

    // void FixedUpdate()
    // {
    //     if (_isDead) return;

    //     _rb.AddForce(_pInput.Movement.normalized * Speed);
    // }

    void Update()
    {
        if (_isDead) return;

        bool isMoving = _pInput.Movement != Vector3.zero;
        _anim.SetBool("Move", isMoving);

        if (isMoving)
        {

            var direction = Camera.main.transform.TransformDirection(_pInput.Movement);
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                5 * Time.deltaTime);

            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
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
            _body.tag = "Untagged";
            _deathEffect.transform.parent = null;
            _deathEffect.Play();
            Destroy(_anim);

            foreach (GameObject onePart in parts)
            {
                onePart.SetActive(true);
                onePart.AddComponent<Rigidbody>();
                onePart.transform.parent = null;
            }

            Destroy(_body);
            Destroy(_rb);

            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(gameObject);

    }

    public void GetBonus()
    {
        Speed += 1;
        _anim.SetFloat("Speed", Speed);
    }

#if UNITY_EDITOR
    [ContextMenu("Reset values")]
    private void ResetValues()
    {
        Speed = 1;
    }
#endif
}
