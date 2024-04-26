using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-0.5f*Time.deltaTime,0,0);
    }

}
