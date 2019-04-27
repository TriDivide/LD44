
using UnityEngine;

public class PlayerModel {
    
    private static PlayerModel _instance;

    [SerializeField]
    private float playerHealth = 100f;

    public static PlayerModel Instance() {
        if (_instance == null) {
            _instance = new PlayerModel();
        }
        return _instance;
    }

    public void UpdateHealth(int valueToAdd) {
        playerHealth += valueToAdd;
    }

    public float getHealth() {
        return playerHealth;
    }


}
