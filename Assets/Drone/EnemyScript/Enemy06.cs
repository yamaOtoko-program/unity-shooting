using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy06 : MonoBehaviour
{
    public float speed = 3f;
    public int r = 2;
    private int f = 0;
    float time = 0;
    private float p;
    float x, y;
    Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < 3&&f==0)
        {
            f = 1;
            vec = new Vector3(transform.position.x,transform.position.y-r,0);
            p = transform.position.y;
        }
        if (f == 1 && p - r > transform.position.y)
        {
            f = 2;
        }
        if (f == 2 && transform.position.y > p - 0.1)
        {
            f = 3;
        }
        if (f==0||f==3)
        {
            this.transform.Translate(-speed * Time.deltaTime*1.5f, 0, 0);
        }
        else
        {
            x = r * Mathf.Sin(time * -speed);
            y = r * Mathf.Cos(time * -speed);
            transform.position = new Vector3(x + vec.x, y + vec.y, vec.z);
            time+=0.01f;
        }
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        this.transform.position = pos;
    }
}
