using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e����
public class BombControl : MonoBehaviour
{
    public GameObject prefab_bomb;
    //true: �e���Ȃ��Ƃ�
    //false: �e������Ƃ�
    public bool bomb_flag = true;
    GameObject bomb;
    void Update()
    {
       

    }

    public void Shoot()
    {
    if (Input.GetKeyDown(KeyCode.C))
    {
        if (bomb_flag) //�e���Ȃ��Ȃ�
        {
            bomb_flag = false;
            //�e�̎�������
            bomb = Instantiate(prefab_bomb, transform.position, Quaternion.Euler(0, 90, 0));

            //�e�̔����ʒu�̍��W������

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
        }
    }
    }
}
