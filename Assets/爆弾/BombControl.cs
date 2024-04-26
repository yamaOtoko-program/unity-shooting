using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//弾発射
public class BombControl : MonoBehaviour
{
    public GameObject prefab_bomb;
    //true: 弾がないとき
    //false: 弾があるとき
    public bool bomb_flag = true;
    GameObject bomb;
    void Update()
    {
       

    }

    public void Shoot()
    {
    if (Input.GetKeyDown(KeyCode.C))
    {
        if (bomb_flag) //弾がないなら
        {
            bomb_flag = false;
            //弾の自動生成
            bomb = Instantiate(prefab_bomb, transform.position, Quaternion.Euler(0, 90, 0));

            //弾の発生位置の座標を決定

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
        }
    }
    }
}
