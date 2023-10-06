using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Vector2 _move;
    public Vector2 Move => _move;

    private Vector2 _mousePostion;

    public Vector2 MousePostion => _mousePostion;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        _move = value.Get<Vector2>();
    }

    public void OnMousePostion(InputValue value)
    {
        _mousePostion = value.Get<Vector2>();
    }
}