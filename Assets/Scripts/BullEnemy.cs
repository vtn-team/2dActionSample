using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : Enemy
{
    [SerializeField] float _searchRadius = 10.0f;
    [SerializeField] float _atkTimer = 3.0f;
    [SerializeField] float _speed = 5.0f;

    enum State
    {
        Stay,
        Attack
    }

    bool _isHit = false;
    float _hitTimer = 0.0f;
    float _timer = 0.0f;
    State _state = State.Stay;
    Vector3 _vecMove = Vector3.zero;

    void Update()
    {
        KnockbackUpdate();

        if (_hp <= 0)
        {
            GameManager.Instance.Remove(this);
            Destroy(gameObject);
            return;
        }

        switch (_state)
        {
            case State.Stay:
                {
                    Vector3 sub = _player.transform.position - this.transform.position;
                    float len = (sub.x * sub.x) + (sub.y * sub.y);
                    if (len < _searchRadius * _searchRadius)
                    {
                        _timer += Time.deltaTime;
                        if (_timer > _atkTimer)
                        {
                            _timer = 0.0f;
                            _state = State.Attack;
                            _vecMove = _player.transform.position - this.transform.position;
                            _vecMove.Normalize();
                        }
                    }
                }
                break;

            case State.Attack:
                {
                    if (_isHit)
                    {
                        _hitTimer -= Time.deltaTime;
                        if (_hitTimer < 0.0f)
                        {
                            _isHit = false;
                        }
                    }

                    _timer += Time.deltaTime;
                    this.transform.position += _vecMove * _speed * Time.deltaTime;

                    if (Mathf.Abs(this.transform.position.x - _player.transform.transform.position.x) < (_player.transform.localScale.x + this.transform.localScale.x) / 2 &&
                        Mathf.Abs(this.transform.position.y - _player.transform.transform.position.y) < (_player.transform.localScale.y + this.transform.localScale.y) / 2)
                    {
                        if (!_isHit)
                        {
                            _player.Damage();
                            _hitTimer = 1.0f;
                        }
                    }
                }
                break;
        }
    }

    private void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
}