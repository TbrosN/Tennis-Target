using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToNextLevel() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentIndex + 1;
        int max = SceneManager.sceneCountInBuildSettings;
        if (nextLevel >= max) {
            nextLevel = 0;
        }
        Debug.Log(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            RestartLevel();
        }
        // if (Input.GetKeyDown(KeyCode.N)) {
        //     GoToNextLevel();
        // }
    }
}
