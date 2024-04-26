using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] int playerWeapon = 0;//0が7mm、1が20mm、2がミサイル。
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
            weapon.text = "スペースキーで機関銃を発射";
        }
        else if (playerWeapon == 2)
        {
            GetComponent<Shoot7>().shoot_7();
            GetComponent<Shoot20>().shoot_20();
            GetComponent<BombControl>().Shoot();
            weapon.text = "スペースキーで機関銃を発射\nCキーで爆弾を投下";
        }
        else if (playerWeapon == 3)
        {
            GetComponent<Shoot7>().shoot_7();
            GetComponent<Shoot20>().shoot_20();
            GetComponent<Missile>().shot();
            weapon.text = "スペースキーで機関銃を発射\nCキーでミサイルを発射";
        }
    }
}
