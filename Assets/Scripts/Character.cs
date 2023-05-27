using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int _hp;
    [SerializeField] protected bool _isKnockback;
    [SerializeField] protected Vector3 _knockbackVec;
    public int HP => _hp;

    public virtual void Damage(int dmg = 1)
    {
        Debug.Log($"{gameObject.name}にダメージ");
        _hp-=dmg;
        if(_hp <= 0)
        {
            _hp = 0;
        }

        _isKnockback = true;
        _knockbackTimer = 0.15f;
    }

    private float _knockbackTimer = 0.0f;
    protected void KnockbackUpdate()
    {
        if (!_isKnockback) return;
        _knockbackTimer -= Time.deltaTime;
        this.transform.position += _knockbackVec * Time.deltaTime;
        if(_knockbackTimer < 0.0f)
        {
            _isKnockback=false;
        }
    }
}
