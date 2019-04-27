using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerModel {
    
    private static PlayerModel _instance;

    private int playerHealth;

    public static PlayerModel Instance {
        get {
            if (_instance == null) {
                _instance = new PlayerModel();
            }
            return _instance;
        }
    }

    private PlayerModel() {
        playerHealth = 100;
        
    }

    public void UpdateHealth(int valueToAdd) {
        playerHealth += valueToAdd;        
    }

    public float getHealth() {
       // print("playerHealth: " + playerHealth);  
        return playerHealth;
    }


}
