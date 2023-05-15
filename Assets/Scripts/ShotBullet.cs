using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    float _radian = 0.0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            var bullet = Instantiate(_prefab, this.transform.position + new Vector3(0.5f, 0, 0), this.transform.rotation);
            var script = bullet.GetComponent<Bullet>();
            script.SetVector(this.transform.right);
        }
    }

    public void SetTargetRadian(float rad)
    {
        _radian = rad;

        this.transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
