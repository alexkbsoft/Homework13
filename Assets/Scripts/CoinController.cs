using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Animator _anim;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void DestroySomething() {
        Destroy(FindObjectOfType<MeshFilter>().gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        _anim.SetTrigger("Collect");
        Destroy(gameObject, 0.7f);
    }
}
