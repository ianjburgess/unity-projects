using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    private int score;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        score = 0;
        setCountText();
    }

    // Update is called once per frame
    void Update()
    {
        score += 100;
        setCountText();
    }

    void setCountText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}