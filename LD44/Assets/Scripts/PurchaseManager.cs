using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PurchaseArrows() {
        float currentBlood = PlayerModel.Instance.GetHealth();

        if (currentBlood > 20) {
            PlayerModel.Instance.UpdateAmmoCount(5);
            PlayerModel.Instance.UpdateHealth(-20);
        }
        else {
            print("Not enough blood. Try getting a transfusion at the bank");
        }
    }

    public void PurchaseLeech() {
        float currentBlood = PlayerModel.Instance.GetHealth();

        if (currentBlood > 10) {
            //PlayerModel.Instance.SetLeech(true);
            PlayerModel.Instance.setLevelUnlock();
            PlayerModel.Instance.UpdateHealth(-30);
        }
        else {
            print("Not enough blood. try getting a transfusion at the bank");
        }
    }
}
