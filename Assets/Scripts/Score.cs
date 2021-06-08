using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Bird bird;
    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>();
        score = gameObject.transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + bird.Score;
    }
}
