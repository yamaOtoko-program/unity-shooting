using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy08 : MonoBehaviour
{
    public float speed = 4f;
    private float yspeed = 0;
    public Transform playerTrans;
    private Transform enemyTrans;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyTrans = GetComponent<Transform>();
        playerTrans = GameObject.Find("Player").transform;
        yspeed = (enemyTrans.position.y - playerTrans.position.y)*speed / (enemyTrans.position.x - playerTrans.position.x) - 0.1f;

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(-speed * Time.deltaTime, -yspeed*Time.deltaTime, 0);
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        this.transform.position = pos;
    }
}
