using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text healthText, collectableText;

    private GameManager manager;

    private int collectableCount;

    private void Start() {
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        float currentHealth = PlayerModel.Instance.getHealth();
        print("Number of Collectables: " + GameObject.FindGameObjectsWithTag("CollectableOne").Length.ToString());
        healthText.text = "Blood = " + currentHealth + "/100";

        collectableCount = GameObject.FindGameObjectsWithTag("CollectableOne").Length;

        print("collectableCount" + collectableCount);
        collectableText.text = collectableCount.ToString() + " Remaining";

        if (collectableCount <= 0) {
            print("show screen");
            manager.showGameOverScreen();
        }
    }
}
