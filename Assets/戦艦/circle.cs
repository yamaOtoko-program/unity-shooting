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
        /*targetをよけるプログラム
        Vector3 homing =target.transform.position- transform.position;
        homing.y = -1f;
        transform.Translate(homing * speed * Time.deltaTime);
         * */

    }
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
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