using System.Collections;

using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    private GameObject target;
    [SerializeField] GameObject Explo;
    [SerializeField] float speed = 15f;
    [SerializeField] int damage;
    private Rigidbody HomingRigidbody;
    private Vector3 Max = new Vector3(10f, 10f, 0);
    private Transform _transform;
    // 前フレームのワールド位置
    private Vector3 _prevPosition;
    void Start()
    {
        target = serchTag(gameObject, "enemy");
        HomingRigidbody = this.GetComponent<Rigidbody>();
        _transform = transform;
        _prevPosition = _transform.position;
    }
    void Update()
    {

        if (target == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(10, 0, 0), speed * Time.deltaTime);
            return;
        }
        Homing();
        LookObject();

    }
    private void Homing()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void LookObject()
    {
        Vector3 vector3 = target.transform.position - transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3) * Quaternion.Euler(90, 0, 0);
        // 取得した回転値をこのゲームオブジェクトのrotationに代入
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, 0.125f);
    }
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;
        float nearDis = 0;
        GameObject targetObj = null;

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);


            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        return targetObj;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameObject bakuha;
            bakuha = Instantiate(Explo, this.transform.position, Quaternion.Euler(0, 0, 0));
            HP script = collision.gameObject.GetComponent<HP>();
            if (script.hit(damage))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlusScore();
                Destroy(collision.gameObject.transform.root.gameObject);

            }
            Destroy(gameObject);
        }
            
    }
}