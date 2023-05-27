using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _spawnTime = 1.0f;
    
    float _timer = 0.0f;
    GameObject _target = null;

    private void Update()
    {
        if (_target) return;

        _timer += Time.deltaTime;
        if(_timer >= _spawnTime)
        {
            _timer = 0.0f;
            _target = GameObject.Instantiate(_prefab, this.transform.position, this.transform.rotation);
        }
    }
}
