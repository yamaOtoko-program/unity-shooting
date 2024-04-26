using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAircraftGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject pint;
    private float speed=0.0625f;
    [SerializeField] private Transform _self;
    [SerializeField] private Transform _target;
    // 前方の基準となるローカル空間ベクトル
    [SerializeField] private Vector3 _forward = Vector3.forward;
    double time=1.0;
    private void Start()
    {
        _target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        time-=Time.deltaTime;
        if(time<=0){
            
            shot();
            time=3.0;
        }
        else if(time<0.5)
        {

        }
        else
        {

            // 対象物と自分自身の座標からベクトルを算出してQuaternion(回転値)を取得
            Vector3 vector3 = _target.transform.position - _self.transform.position + new Vector3(-1f, 3f, 0);
            // Quaternion(回転値)を取得
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            // 取得した回転値をこのゲームオブジェクトのrotationに代入
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, speed);
        }

    }
    private void shot(){
        GameObject Bullets = Instantiate(bullet.gameObject, pint.transform.position, transform.rotation); // 弾を砲台と同じ場所、同じ向きに生成する
        Vector3 Force; // 弾にかける力
        Force = transform.forward * 800; // 弾にかける力を砲台の前方向にする
        Bullets.GetComponent<Rigidbody>().AddForce(Force); // 弾に力をかける
        Destroy(Bullets.gameObject, 5); // 弾を2秒後に消す
    }
}
