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

    void Update()
    {
        this.transform.position += _power * Time.deltaTime;

        switch(_type)
        {
            case BulletType.Player:
                break;

            case BulletType.Enemy:
                {
                    var player = GameManager.Instance.Player;
                    if (this.transform.position.x - this.transform.localScale.x / 2 < player.transform.position.x &&
                        this.transform.position.x + this.transform.localScale.x / 2 > player.transform.position.x &&
                        this.transform.position.y - this.transform.localScale.y / 2 < player.transform.position.y &&
                        this.transform.position.y + this.transform.localScale.y / 2 > player.transform.position.y)
                    {
                        player.Damage();
                        Destroy(gameObject);
                    }
                }
                break;
        }
    }
}
