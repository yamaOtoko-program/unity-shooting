using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy04 : MonoBehaviour
{
    public float speed = 4f;
    float lim = 3;
    public Transform playerTrans;
    private Transform enemyTrans;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyTrans = GetComponent<Transform>();
        playerTrans = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        Vector3 vector3 = playerTrans.position - enemyTrans.position;
        rb.AddForce(0,vector3.y,0);
        float speedY = Mathf.Clamp(rb.velocity.y, -lim, lim);
        rb.velocity = new Vector3(0, speedY);
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        this.transform.position = pos;
    }
}
