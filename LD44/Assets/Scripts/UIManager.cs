using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text healthText, collectableText;
	
	// Update is called once per frame
	void Update () {
        float currentHealth = PlayerModel.Instance.getHealth();
        print("Number of Collectables: " + GameObject.FindGameObjectsWithTag("CollectableOne").Length.ToString());
        healthText.text = "Blood = " + currentHealth + "/100";
        collectableText.text = GameObject.FindGameObjectsWithTag("CollectableOne").Length.ToString() + " Remaining";

    }
}
