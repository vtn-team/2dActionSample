using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : Enemy
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _searchRadius = 200.0f;
    [SerializeField] float _interval = 1.0f;

    float _timer = 0.0f;

    void Update()
    {
        KnockbackUpdate();

        if (_hp <= 0)
        {
            GameManager.Instance.Remove(this);
            Destroy(gameObject);
            return;
        }

        Vector3 sub = _player.transform.position - this.transform.position;
        float len = (sub.x * sub.x) + (sub.y * sub.y);
        if (len < _searchRadius * _searchRadius)
        {
            _timer += Time.deltaTime;
            if (_timer > _interval)
            {
                _timer -= _interval;

                Instantiate(_prefab, this.transform.position + new Vector3(-0.5f, 0, 0), this.transform.rotation);
            }
        }
        else
        {
            _timer = 0.0f;
        }
    }
}