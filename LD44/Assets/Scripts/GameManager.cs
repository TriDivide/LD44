using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager: MonoBehaviour {

    [SerializeField]
    private GameObject gameOverPanel, portalPanel;

    private GameObject player;


    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        gameOverPanel.SetActive(false);
    }

    public void showGameOverScreen() {
        if (gameOverPanel != null) {
            gameOverPanel.SetActive(true);
        }
    }

    public void OnRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit() {
        Application.Quit();
    }

    public void SelectLevel() {
        SceneManager.LoadScene("Sandbox");
    }

    public void CancelSelect() {
        portalPanel.SetActive(false);
    }
}
