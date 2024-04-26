using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        HP script = collision.gameObject.GetComponent<HP>();
        if (collision.gameObject.tag == "enemy")
        {
            if (script.hit(damage))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlusScore();
                Destroy(collision.gameObject.transform.root.gameObject);
            }
            
        }
    }
}
