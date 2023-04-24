using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Animator _coinAnim;
    [SerializeField] private ParticleSystem _coinFlyEffect;
    [SerializeField] private ParticleSystem _bonusGotEffect;
    [SerializeField] private GameObject _coinBody;

    private bool _triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            pc.GetBonus();

            OnGetBonus();
        }
    }

    public void OnGetBonus()
    {
        if (!_triggered)
        {
            _triggered = true;

            _coinAnim.enabled = false;
            _coinFlyEffect.Stop();
            _bonusGotEffect.Play();
            
            _coinBody.transform.parent = null;
            _bonusGotEffect.transform.parent = null;

            var rb = _coinBody.AddComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
            rb.AddTorque(0, 60, 0, ForceMode.VelocityChange);

            var meshColider = _coinBody.AddComponent<MeshCollider>();
            meshColider.convex = true;
            meshColider.isTrigger = true;

            Destroy(gameObject);
            Destroy(_coinBody, 1);
        }
    }
}
