using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject bullet;
    public GameObject pint;
    private double timer = 0;
    void Update()
    {
        
    }
    public void shot()
    {
        timer += Time.deltaTime;
        if (timer > 1 && Input.GetKey(KeyCode.C))
        {
            GameObject Bullets = Instantiate(bullet.gameObject, pint.transform.position, Quaternion.Euler(0, 0, -90)); // 弾を砲台と同じ場所、同じ向きに生成する
            Destroy(Bullets.gameObject, 2); // 弾を2秒後に消す
            timer = 0;
        }
        
    }

}
