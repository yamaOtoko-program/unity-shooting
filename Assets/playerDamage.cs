using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] GameObject Explo;
    [SerializeField] private bool isSenkan = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        HP script = collision.gameObject.GetComponent<HP>();
        if (collision.gameObject.tag == "player")
        {
      
            if (script.hit(damage))
            {
                
                GameObject bakuha;
                bakuha = Instantiate(Explo, collision.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                SceneManager.LoadScene("GameOver");
                Destroy(collision.gameObject.transform.root.gameObject);
            }

            if (!isSenkan)
            {
                GameObject bakuha2;
                bakuha2 = Instantiate(Explo, this.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
            

        }
    }
}
