
//using UnityEngine;

public class PlayerModel {
    
    private static PlayerModel _instance;

    public static PlayerModel Instance() {
        if (_instance == null) {
            _instance = new PlayerModel();
        }
        return _instance;
    }
}
