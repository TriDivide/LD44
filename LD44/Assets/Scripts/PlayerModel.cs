using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerModel {
    
    private static PlayerModel _instance;

    private int playerHealth, playerAmmo;

    private bool hasLeech = false;

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

    public void UpdateAmmoCount(int valueToAdd) {
        playerAmmo += valueToAdd;
    }

    public int GetAmmo() {
        return playerAmmo;
    }

    public bool PlayerHasLeech() {
        return hasLeech;
    }

    public void SetLeech(bool newLeechState) {
        hasLeech = newLeechState;
    }

    public float GetHealth() {
       // print("playerHealth: " + playerHealth);  
        return playerHealth;
    }


}
