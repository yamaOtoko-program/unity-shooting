using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//’e”­Ë
public class BombControl : MonoBehaviour
{
    public GameObject prefab_bomb;
    //true: ’e‚ª‚È‚¢‚Æ‚«
    //false: ’e‚ª‚ ‚é‚Æ‚«
    public bool bomb_flag = true;
    GameObject bomb;
    void Update()
    {
       

    }

    public void Shoot()
    {
    if (Input.GetKeyDown(KeyCode.C))
    {
        if (bomb_flag) //’e‚ª‚È‚¢‚È‚ç
        {
            bomb_flag = false;
            //’e‚Ì©“®¶¬
            bomb = Instantiate(prefab_bomb, transform.position, Quaternion.Euler(0, 90, 0));

            //’e‚Ì”­¶ˆÊ’u‚ÌÀ•W‚ğŒˆ’è

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
        }
    }
    }
}
