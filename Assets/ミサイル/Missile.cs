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
            GameObject Bullets = Instantiate(bullet.gameObject, pint.transform.position, Quaternion.Euler(0, 0, -90)); // �e��C��Ɠ����ꏊ�A���������ɐ�������
            Destroy(Bullets.gameObject, 2); // �e��2�b��ɏ���
            timer = 0;
        }
        
    }

}
