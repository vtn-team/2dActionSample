using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] GameObject _sprite;
    class CircleData
    {
        public float X;
        public float Y;
        public float Radius;
    }


    // Start is called before the first frame update
    void Start()
    {
        CircleData[] data = new CircleData[]
        {
            new CircleData(){ X = 100.0f, Y = 100.0f, Radius = 50.0f},
            new CircleData(){ X = 300.0f, Y = 250.0f, Radius = 150.0f},
            new CircleData(){ X = 250.0f, Y = 100.0f, Radius = 50.0f},
            new CircleData(){ X = 400.0f, Y =  50.0f, Radius = 150.0f},
            new CircleData(){ X =  50.0f, Y = 100.0f, Radius = 250.0f},
            new CircleData(){ X = 150.0f, Y = 200.0f, Radius = 150.0f},
            new CircleData(){ X = 300.0f, Y = 300.0f, Radius = 50.0f},
            new CircleData(){ X = 400.0f, Y = 200.0f, Radius = 150.0f},
            new CircleData(){ X = 100.0f, Y = 100.0f, Radius = 350.0f}
         };

        float x = 80.0f;
        float y = 310.0f;
        float r = 100.0f;

        var center = GameObject.Instantiate(_sprite, new Vector3(x, y, 0), Quaternion.identity);
        center.transform.localScale = new Vector3(r * 2,r * 2, r * 2);
        center.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);

        for (int i = 0; i < data.Length; ++i)
        {
            var obj = GameObject.Instantiate(_sprite, new Vector3(data[i].X, data[i].Y, 0), Quaternion.identity);
            obj.transform.localScale = new Vector3(data[i].Radius * 2, data[i].Radius * 2, data[i].Radius * 2);

            obj.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.5f);

            float len = (data[i].X - x) * (data[i].X - x) + (data[i].Y - y) * (data[i].Y - y);
            float radius = (data[i].Radius + r) * (data[i].Radius + r);

            Debug.Log(len);
            Debug.Log(radius);
            Debug.Log(len < radius);
        }

    }
}