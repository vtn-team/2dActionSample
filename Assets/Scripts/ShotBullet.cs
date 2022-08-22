using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Instantiate(_prefab, this.transform.position + new Vector3(0.5f, 0, 0), this.transform.rotation);
        }
    }
}
