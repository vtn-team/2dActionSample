using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _extinc = 0.3f;
    [SerializeField] float _scale = 10.0f;
    [SerializeField] float _jumpPow = 10.0f;
    float _jumpY = 0.0f;
    float _grav = 0.0f;

    private void Start()
    {
        GameManager.Instance.Register(this);
    }

    void Update()
    {
        KnockbackUpdate();
        GameManager.Instance.UpdateHitStop();

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
                _jumpY = _jumpPow;
                _grav = 0.0f;
            }
        }
        else
        {
            _grav += Time.deltaTime;
            _jumpY *= 1.0f - Time.deltaTime * _extinc;
            float y = this.transform.position.y;
            y += (_jumpY - 9.81f * _grav) * Time.deltaTime * _scale;
            if(y < -4.0f)
            {
                y = -4;
                _grav = 0;
                _jumpY = 0;
            }
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    }
    public override void Damage(int dmg = 1)
    {
        if (_isKnockback) return;

        base.Damage(dmg);
    }
}
