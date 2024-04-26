using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "GAMECLEAR\nSCORE:"+ score;
    }
}
