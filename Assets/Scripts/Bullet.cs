using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType
    {
        Invalid,
        Player,
        Enemy,
    }

    [SerializeField] BulletType _type;
    [SerializeField] Vector3 _power;

    public void SetVector(Vector3 vec)
    {
        _power = vec * _power.magnitude;
    }

    bool isHitRect(Transform target)
    {
        if(Mathf.Abs(this.transform.position.x - target.transform.position.x) < (target.localScale.x + this.transform.localScale.x) / 2 &&
           Mathf.Abs(this.transform.position.y - target.transform.position.y) < (target.localScale.y + this.transform.localScale.y) / 2)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        this.transform.position += _power * Time.deltaTime;

        switch(_type)
        {
            case BulletType.Player:
                {
                    var enList = GameManager.Instance.Enemies;
                    foreach (var enemy in enList)
                    {
                        if (isHitRect(enemy.transform))
                        {
                            enemy.Damage();
                            Destroy(gameObject);
                        }
                    }
                }
                break;

            case BulletType.Enemy:
                {
                    var player = GameManager.Instance.Player;
                    if (isHitRect(player.transform))
                    {
                        player.Damage();
                        Destroy(gameObject);
                    }
                }
                break;
        }
    }
}
