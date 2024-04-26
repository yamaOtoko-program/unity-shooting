using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float speed = 5f;
    private float currentAngleX;
    [SerializeField] private float rotateSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
            transform.Rotate(-rotateSpeed, 0f, 0f);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
            transform.Rotate(rotateSpeed, 0f, 0f);
        }
        else
        {
            RotasionReset();
        }
        

        currentAngleX = transform.eulerAngles.x;

        // 角度制限
        // 角度が-180〜180の範囲内になるように補正
        if (currentAngleX > 180)
        {
            currentAngleX = currentAngleX - 360;
        }


        // 角度制限
        // Clam関数を使って、-45度から45度の範囲内に制限
        currentAngleX = Mathf.Clamp(currentAngleX, -30, 30);
        transform.eulerAngles = new Vector3(currentAngleX, 0, 0);
        Vector3 pos = this.transform.position;
        pos.z = 0f;
        this.transform.position = pos;
    }

    public void RotasionReset()
    {
        // 上方向のベクトルを作る
        Vector3 vector3 = new Vector3(1, 0, 0);
        //ベクトルから回転角度を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3, Vector3.up);
        // 取得した回転値をbodyのrotationに代入
        //第三引数を大きくすれば早く方向へ向く
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, 10f * Time.deltaTime);
    }
}
