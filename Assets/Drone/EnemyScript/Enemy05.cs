using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy05 : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody rb;
    private Transform enemyTrans;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (enemyTrans.position.x < -7)
        {
            speed = -speed;
        }
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        this.transform.position = pos;
    }
}
