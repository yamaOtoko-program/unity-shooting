using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] GameObject Explo;
    [SerializeField] int damage = 5;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            HP script = collision.gameObject.GetComponent<HP>();
            if (script.hit(damage))
            {
                GameObject bakuha;
                bakuha = Instantiate(Explo, collision.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                GameObject.Find("GameManager").GetComponent<GameManager>().PlusScore();
                Destroy(collision.gameObject.transform.root.gameObject);
            }
            Destroy(gameObject);
        }
    }
}

