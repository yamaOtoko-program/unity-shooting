using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int timer = 0;
    float y;
    public int score = 0;
    private bool spawnSenkan=false;
    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject enemy05;
    public GameObject enemy06;
    public GameObject enemy07;
    public GameObject enemy08;
    [SerializeField] GameObject senkan;
    [SerializeField]Text textScore;
    [SerializeField] Text textTimer;
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (minute < 3 && (int)seconds == 59)
        {
            if (!spawnSenkan)
            {
                GameObject hune = Instantiate(senkan, new Vector3(17.8325f, -2.949404f, 0), Quaternion.Euler(0, 0, 0));
                spawnSenkan = true;
            }

        }
        else
        {
            spawnSenkan = false;
        }

        if (timer % 420 == 0)
        {
            switch (Random.Range(1,6))
            {
                case 1:
                    Pattern01();
                    break;
                case 2:
                    Pattern02();
                    break;
                case 3:
                    Pattern03();
                    break;
                case 4:
                    Pattern04();
                    break;
                case 5:
                    Pattern05();
                    break;
            }
        }
        timer++;
    }
    private void FixedUpdate()
    {
        Timer();

        if (minute < 1 && seconds < 1f)
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("GameClear");
        }

    }
    void Timer()
    {
        seconds -= Time.deltaTime;
        if (seconds < 0)
        {
            seconds = 60;
            minute--;
        }
        int sec = (int)seconds;
        textTimer.text = "Time:" + minute.ToString() + "." + sec.ToString("00");

    }
    public void PlusScore()
    {
        score++;
        textScore.text = "Score: " + score.ToString();
    }

    void Pattern01()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject e1 = Instantiate(enemy01);
            e1.transform.position =new Vector3(Random.Range(15, 30),Random.Range(-3, 6), 0);
        }
    }
    void Pattern02()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject e1 = Instantiate(enemy02);
            e1.transform.position = new Vector3(13 + i * 2, 5, 0);
            GameObject e2 = Instantiate(enemy02);
            e2.transform.position = new Vector3(14 + i * 2, -3, 0);
        }
    }
    async void Pattern03()
    {
        if (Random.Range(0,2) == 0)
        {
            y = 5;
        }
        else
        {
            y = -3;
        }
        for (int i = 0; i < 7; i++)
        {
            GameObject e1 = Instantiate(enemy02);
            e1.transform.position = new Vector3(15, y , 0);
            await Task.Delay(500);
        }
    }
    void Pattern04()
    {
        for (int i = 0; i < 7; i++)
        {
            y = Random.Range(0, 10);
            if (y == 0)
            {
                GameObject e1 = Instantiate(enemy05);
                e1.transform.position = new Vector3(Random.Range(15, 25), Random.Range(-3, 6), 0);
            }
            else if (y == 1)
            {
                GameObject e1 = Instantiate(enemy06);
                e1.transform.position = new Vector3(Random.Range(15, 25), Random.Range(1, 6), 0);
            }
            else if (y == 2)
            {
                GameObject e1 = Instantiate(enemy07);
                e1.transform.position = new Vector3(Random.Range(15, 25), Random.Range(-3, 2), 0);
            }
            else
            {
                GameObject e1 = Instantiate(enemy01);
                e1.transform.position = new Vector3(Random.Range(15, 25), Random.Range(-3, 6), 0);
            }
        }
    }
    async void Pattern05()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject e1 = Instantiate(enemy08);
            e1.transform.position = new Vector3(15, Random.Range(-3, 6), 0);
            await Task.Delay(500);
        }
    }
}
