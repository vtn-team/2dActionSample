using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector3 _power = Vector3.right;

    public void SetVector(Vector3 vec)
    {
        _power = vec;
    }

    void Update()
    {
        this.transform.position += _power * 5 * Time.deltaTime;

        var enList = GameObject.FindObjectsOfType<Enemy>();
        foreach (var enemy in enList)
        {
            if (Mathf.Abs(this.transform.position.x - enemy.transform.transform.position.x) < (enemy.transform.localScale.x + this.transform.localScale.x) / 2 &&
                Mathf.Abs(this.transform.position.y - enemy.transform.transform.position.y) < (enemy.transform.localScale.y + this.transform.localScale.y) / 2)
            {
                enemy.Damage();
                GameManager.Instance.HitStop(0.08f);
                Destroy(gameObject);
            }
        }
    }
}
