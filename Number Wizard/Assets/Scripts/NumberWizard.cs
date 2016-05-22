using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    // Use this for initialization
    int max;
    int min;
    int guess;

    void Start () {
        StartGame();
	}

    void StartGame () {
        max = 1000;
        min = 1;

        // CHOOSE RANDOM NUMBER BETWEEN 1 - 1000
        guess = Random.Range(1, 1000);

        print("========================");
        print("Welcome to Number Wizard");
        print("Pick a number in your head, but don't tell me.");



        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower than " + guess + "?");
        print("Up = higher, down = lower, return = equal.");

        max += 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up")) {
            // print("Up key was pressed");
            min = guess;
            NextGuess();
        } else if (Input.GetKeyDown("down")) {
            // print("Down key was pressed");
            max = guess;
            NextGuess();
        } else if (Input.GetKeyDown("return")) {
            print("I won!");
            StartGame();
        }
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess);
        print("Up = higher, down = lower, return = equal.");
    }
}
