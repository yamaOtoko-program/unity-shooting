using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    private GameObject target;
    Transform enemy;
    public float time = 2f;
    private float speed = 1f;
    void Start()
    {
        target = serchTag(gameObject, "enemy");
        enemy = target.transform;
    }
    void Update()
    {
        Transform enemy = target.transform;
        Vector3 homing = target.transform.position - transform.position;
        transform.Translate(homing * speed * Time.deltaTime);
        /*target���悯��v���O����
        Vector3 homing =target.transform.position- transform.position;
        homing.y = -1f;
        transform.Translate(homing * speed * Time.deltaTime);
         * */

    }
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        GameObject targetObj = null; //�I�u�W�F�N�g

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        return targetObj;
    }
}