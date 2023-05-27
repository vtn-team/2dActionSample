using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField] GameObject _normal;
    [SerializeField] GameObject _laser;
    float _radian = 0.0f;
    float _pushTimer = 0.0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            _pushTimer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if(_pushTimer > 1.0f)
            {
                var bullet = Instantiate(_normal, this.transform.position + new Vector3(0.5f, 0, 0), this.transform.rotation);
                var script = bullet.GetComponent<PlayerBullet>();
                script.SetVector(this.transform.right);
            }
            else
            {
                var bullet = Instantiate(_laser, this.transform.position + new Vector3(0.5f, 0, 0), this.transform.rotation);
                var script = bullet.GetComponent<LaserBullet>();
            }
            _pushTimer = 0.0f;
        }
    }

    public void SetTargetRadian(float rad)
    {
        _radian = rad;

        this.transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
