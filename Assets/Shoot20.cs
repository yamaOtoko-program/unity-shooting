using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot20 : MonoBehaviour
{
    public GameObject prefab_bullet;
    [SerializeField] GameObject shot20;
    [SerializeField] Vector3 force = new Vector3(20f, 0, 0);
    [SerializeField] private float interval = 0.2f; // 何秒間隔で撃つか
    private float timer = 0.0f;　// 時間カウント用のタイマー

    // Start is called before the first frame update

    // Update is called once per frame
    public void shoot_20()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (timer <= 0.0f)
            {

                GameObject bullet;
                Rigidbody rb;

                bullet = Instantiate(prefab_bullet);
                rb = bullet.GetComponent<Rigidbody>();
                bullet.transform.position = shot20.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                rb.AddForce(force, ForceMode.Impulse);
                timer = interval;
            }
            //anim.SetBool("isShot", true);
        }
        else
        {
            //anim.SetBool("isShot", false);
        }
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
    }
}
