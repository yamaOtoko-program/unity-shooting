using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
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
        this.transform.Translate(-speed * Time.deltaTime/1.5f, 0, 0);
        Vector3 vector3 = enemyTrans.position;
        rb.AddForce(0, 1-vector3.y, 0);
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        this.transform.position = pos;
    }
}
