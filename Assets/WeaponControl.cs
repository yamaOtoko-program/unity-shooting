using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] int playerWeapon = 0;//0��7mm�A1��20mm�A2���~�T�C���B
    [SerializeField] Text weapon;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        GameManager getScore = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (getScore.score > 15)
        {
            playerWeapon = 1;

        }
        if (getScore.score > 30)
        {
            playerWeapon = 2;
        }

        if(getScore.score > 60)
        {
            playerWeapon = 3;
        }

        if (GetComponent<HP>().isDamage) return;
        if (playerWeapon == 0) GetComponent<Shoot7>().shoot_7();
        else if (playerWeapon == 1)
        {
            GetComponent<Shoot7>().shoot_7();
            GetComponent<Shoot20>().shoot_20();
            weapon.text = "�X�y�[�X�L�[�ŋ@�֏e�𔭎�";
        }
        else if (playerWeapon == 2)
        {
            GetComponent<Shoot7>().shoot_7();
            GetComponent<Shoot20>().shoot_20();
            GetComponent<BombControl>().Shoot();
            weapon.text = "�X�y�[�X�L�[�ŋ@�֏e�𔭎�\nC�L�[�Ŕ��e�𓊉�";
        }
        else if (playerWeapon == 3)
        {
            GetComponent<Shoot7>().shoot_7();
            GetComponent<Shoot20>().shoot_20();
            GetComponent<Missile>().shot();
            weapon.text = "�X�y�[�X�L�[�ŋ@�֏e�𔭎�\nC�L�[�Ń~�T�C���𔭎�";
        }
    }
}
