using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    // Use this for initialization
    int max;
    int min;
    int guess;

    public int maxGuessesAllowed = 10;

    public Text text;

    void Start () {
        StartGame();
	}

    void StartGame () {
        max = 1000;
        min = 1;
        NextGuess();
    }

    public void GuessLower() {
        max = guess;
        NextGuess();
    }

    public void GuessHigher() {
        min = guess;
        NextGuess();
    }

    void NextGuess() {
        // CHOOSE RANDOM NUMBER BETWEEN 1 - 1000
        guess = Random.Range(min, max + 1);
        text.text = guess.ToString();
        maxGuessesAllowed = maxGuessesAllowed - 1;
        if (maxGuessesAllowed <= 0) {
            SceneManager.LoadScene("Win");
        }
    }
}
