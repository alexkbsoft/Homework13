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

            _coinBody.AddComponent<Rigidbody>();
            var meshColider = _coinBody.AddComponent<MeshCollider>();
            meshColider.convex = true;

            Destroy(gameObject);
        }
    }
}
