using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
        Brick.breakableCount = 0;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadNextLevel() {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void BrickDestroyed() {
        if (Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }
}