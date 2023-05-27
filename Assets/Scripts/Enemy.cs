using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField, PreviewButton] protected Player _player;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        GameManager.Instance.Register(this);
    }
}
