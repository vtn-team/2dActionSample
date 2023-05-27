using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] float _appear = 0.2f;
    [SerializeField] float _hitTime = 0.1f;

    float _timer = 0.0f;
    bool _isHit = false;

    // 2次元ベクトルの外積を返す
    private float Cross(Vector3 vector1, Vector3 vector2)
        => vector1.x * vector2.y - vector1.y * vector2.x;

    bool IsCross(Vector3 startPoint1, Vector3 endPoint1, Vector3 startPoint2, Vector3 endPoint2)
    {
        // ベクトルP1Q1
        var vector1 = endPoint1 - startPoint1;
        // ベクトルP2Q2
        var vector2 = endPoint2 - startPoint2;
        //
        // 以下条件をすべて満たすときが交差となる
        //
        //    P1Q1 x P1P2 と P1Q1 x P1Q2 が異符号
        //                かつ
        //    P2Q2 x P2P1 と P2Q2 x P2Q1 が異符号
        //
        return Cross(vector1, startPoint2 - startPoint1) * Cross(vector1, endPoint2 - startPoint1) < 0 &&
                Cross(vector2, startPoint1 - startPoint2) * Cross(vector2, endPoint1 - startPoint2) < 0;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _hitTime && !_isHit)
        {
            bool hit = false;
            var enList = GameObject.FindObjectsOfType<Enemy>();
            foreach (var enemy in enList)
            {
                //線分と矩形の判定
                bool isHit = false;

                Vector3 posA = this.transform.position;
                Vector3 posB = this.transform.position + this.transform.rotation * Vector3.right * 30;

                Vector3 lefttop = enemy.transform.position + new Vector3(-enemy.transform.localScale.x/2.0f, -enemy.transform.localScale.y/ 2.0f);
                Vector3 righttop = enemy.transform.position + new Vector3(enemy.transform.localScale.x/ 2.0f, -enemy.transform.localScale.y/ 2.0f);
                Vector3 leftbottom = enemy.transform.position + new Vector3(-enemy.transform.localScale.x/ 2.0f, +enemy.transform.localScale.y/ 2.0f);
                Vector3 rightbottom = enemy.transform.position + new Vector3(enemy.transform.localScale.x/ 2.0f, +enemy.transform.localScale.y/ 2.0f);
                if (IsCross(lefttop, leftbottom, posA, posB)) isHit = true;
                if (IsCross(righttop, rightbottom, posA, posB)) isHit = true;
                if (IsCross(rightbottom, leftbottom, posA, posB)) isHit = true;
                if (IsCross(lefttop, righttop, posA, posB)) isHit = true;

                if(isHit)
                {
                    enemy.Damage(3);
                    hit = true;
                }
            }
            if(hit)
            {
                GameManager.Instance.HitStop(0.25f);
            }
            _isHit = true;
        }

        if (_timer > _appear)
        {
            Destroy(this.gameObject);
        }
    }
}
