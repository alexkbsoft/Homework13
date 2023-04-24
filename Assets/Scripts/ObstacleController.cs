using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void SelectNextAnimation() {
        var animationIndex = Random.Range(0, 3);
        string[] names = {"Rotate", "TranslateVertical", "Scale"};

        _anim.SetTrigger(names[animationIndex]);
    }
}
