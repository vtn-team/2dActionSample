using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int _hp;
    public int HP => _hp;

    public void Damage()
    {
        Debug.Log($"{gameObject.name}にダメージ");
        _hp--;
        if(_hp <= 0)
        {
            _hp = 0;
        }
    }
}
