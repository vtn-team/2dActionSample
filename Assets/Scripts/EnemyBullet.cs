using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Player _player = null;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        this.transform.position += Vector3.left * 5 * Time.deltaTime;

        if (Mathf.Abs(this.transform.position.x - _player.transform.transform.position.x) < (_player.transform.localScale.x + this.transform.localScale.x) / 2 &&
            Mathf.Abs(this.transform.position.y - _player.transform.transform.position.y) < (_player.transform.localScale.y + this.transform.localScale.y) / 2)
        {
            _player.Damage();
            Destroy(gameObject);
        }
    }
}
