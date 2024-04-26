using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotasion : MonoBehaviour
{
    
    [SerializeField] private GameObject body;
    /// <summary>
    /// 仮の条件分岐 Enterキー
    /// </summary>
    void Update()
    {
        if(Input.GetKey(KeyCode.Return)){
            RotasionReset();
        }
    }
    /// <summary>
    /// body =回転対象
    /// </summary>
    public void RotasionReset(){
        // 上方向のベクトルを作る
        Vector3 vector3 = new Vector3(1,0,0);
        //ベクトルから回転角度を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3,Vector3.up);
        // 取得した回転値をbodyのrotationに代入
        //第三引数を大きくすれば早く方向へ向く
        body.transform.rotation = Quaternion.Slerp(body.transform.rotation, quaternion, 2f*Time.deltaTime);
    }
}
