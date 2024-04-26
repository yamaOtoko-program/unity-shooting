using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    [SerializeField] GameObject Explo;
    [SerializeField] int damage = 0;
    
    void FixedUpdate()
    {
        if (this.transform.position. y < -5.46f) deleteBomb();
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            GameObject bakuha;
            bakuha = Instantiate(Explo,this.transform.position,Quaternion.Euler(0,0,0));
            HP script = collision.gameObject.GetComponent<HP>();
            if (script.hit(damage))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlusScore();
                Destroy(collision.gameObject.transform.root.gameObject);

            }

            deleteBomb();

        }

    }
    private void deleteBomb()
    {
        BombControl bc;
        GameObject obj = GameObject.Find("Player");
        bc = obj.GetComponent<BombControl>();
        bc.bomb_flag = true;
        Destroy(gameObject);
    }
}
