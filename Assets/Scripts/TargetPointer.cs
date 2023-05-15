using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TargetPointer : MonoBehaviour
{
    [SerializeField] ShotBullet _bulletGen;


    private void Update()
    {
        //個々のやり方は仕組みによって変化します
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        this.transform.position = point;

        //差分ベクトル
        Vector3 sub = this.transform.position - _bulletGen.transform.position;
        float rad = Mathf.Atan2(sub.y, sub.x);
        _bulletGen.SetTargetRadian(rad);
    }
}
