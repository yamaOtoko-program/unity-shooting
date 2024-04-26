using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * @ HP
 */
public class HP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int hp = 10;
    [SerializeField] bool isPlayer = false;
    [SerializeField] float speed, flashInterval;
    //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] int loopCount;
    [SerializeField] Text hptext;
    //�_�ł����邽�߂�SpriteRenderer
    [SerializeField] GameObject body;
    [SerializeField] GameObject miffy;
    public bool isDamage= false;

    void FixedUpdate()
    {
        if (isPlayer)
        {
            hptext.text = "HP: " + hp.ToString();
        }
    }
    public bool hit(int damage)
    {

        if (isDamage) return false;
        hp -= Mathf.Abs(damage);
        if(isPlayer) StartCoroutine(OnDamage());
        return hp<=0;
    }
    public IEnumerator OnDamage()
    {
        isDamage = true;
        GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < loopCount; i++)
        {
            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I�t
            body.SetActive(false);
            miffy.SetActive(false);
            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I��
            body.SetActive(true);
            miffy.SetActive(true);
        }
        // �ʏ��Ԃɖ߂�
        GetComponent<BoxCollider>().enabled = true;
        isDamage = false;


    }
}
