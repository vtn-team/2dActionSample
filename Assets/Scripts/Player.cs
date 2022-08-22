using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] float _speed = 5.0f;
    float _jumpY = 0.0f;
    float _jump = 0.0f;
    float _grav = 0.0f;

    private void Start()
    {
        GameManager.Instance.Register(this);
    }

    void Update()
    {
        if (_hp <= 0)
        {
            //ゲームオーバー
            //return;
        }

        float v = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(v, 0, 0) * Time.deltaTime * _speed;

        if (_jumpY < 0.001f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpY = 20.0f;
                _jump = 0.0f;
                _grav = 0.0f;
            }
        }
        else
        {
            _grav += Time.deltaTime;
            if (_jump < 0.3f)
            {
                _jump += Time.deltaTime;
            }
            float y = -4.0f + _jumpY * _jump -9.81f * _grav;
            if(y < -4.0f)
            {
                y = -4;
                _grav = 0;
                _jumpY = 0;
            }
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    }
}
