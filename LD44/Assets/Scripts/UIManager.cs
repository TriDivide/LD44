using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text healthText;
	
	// Update is called once per frame
	void Update () {
        float currentHealth = PlayerModel.Instance.getHealth();
        //print("playerHealth: " + currentHealth);
        healthText.text = "Blood = " + currentHealth + "/100";

    }
}
