using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager: MonoBehaviour {

    [SerializeField]
    private GameObject gameOverPanel, portalPanel, completePanel, promptPanel;

    [SerializeField]
    private Text promptText;

    private GameObject player;


    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        gameOverPanel.SetActive(false);
        completePanel.SetActive(false);
        promptPanel.SetActive(false);
    }

    public void showGameOverScreen() {
        if (gameOverPanel != null) {
            gameOverPanel.SetActive(true);
        }
    }

    private void Update() {
        if (PlayerModel.Instance.GetHealth() <= 0) {
            gameOverPanel.SetActive(true);
        }
    }

    public void showCompleteScreen() {
        if (completePanel != null) {
            completePanel.SetActive(true);
        }
    }

    public void hideCompleteScreen() {
        completePanel.SetActive(false);
    }

    public void OnRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit() {
        Application.Quit();
    }

    public void SelectLevel() {
        if (PlayerModel.Instance.HasBroughtLevel()) {
            SceneManager.LoadScene("LevelGeneratorSandbox");
        }
        else {
            print("no buy");
            promptText.text = "You have not paid for access to this rift location. Go to the merchant to pay the blood toll.";
            promptPanel.SetActive(true);
        }
    }

    public void CancelSelect() {
        portalPanel.SetActive(false);
    }

    public void returnToHub() {
        if (PlayerModel.Instance.GetHealth() + 10 <= 100) {
            PlayerModel.Instance.setLevelUnlock();
            PlayerModel.Instance.UpdateHealth(10);
        }
        SceneManager.LoadScene("HubScene");
    }
}
