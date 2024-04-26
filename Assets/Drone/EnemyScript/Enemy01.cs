using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        this.transform.position = pos;
    }
}
