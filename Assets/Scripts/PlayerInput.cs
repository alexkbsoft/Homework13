using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public Vector3 Movement {
        get => _movement;
    }
    private Vector3 _movement;

    void Update()
    {
        var h = Input.GetAxis(Constants.HorizontalAxis);
        var v = Input.GetAxis(Constants.VerticalAxis);

        _movement = new Vector3(h, 0, v);
    }
}
