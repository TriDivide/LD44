using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEventManager : MonoBehaviour {
    [SerializeField]
    private GameObject merchantPanel, bankerPanel, promptPanel, portalPanel;
        
    [SerializeField]
    private Text promptText;

    private static int BANK_PROMPT_STATE = 1;
    private static int MERCHANT_PROMPT_STATE = 2;
    private static int MERCHANT_SCREEN_STATE = 4;
    private static int BANK_SCREEN_STATE = 5;
    private static int STATE_NORMAL = 3;

    private int currentState = 3;
    private bool prompted = false;


	// Use this for initialization
	void Start () {
        promptPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (currentState == MERCHANT_PROMPT_STATE) {
            promptText.text = "Press \"SPACE\" to barter with your blood";
        }
        else if (currentState == BANK_PROMPT_STATE) {
            promptText.text = "Press \"SPACE\" to request blood";
        }

        if (currentState == MERCHANT_PROMPT_STATE) {
            merchantPanel.SetActive(false);
            promptPanel.SetActive(true);
            bankerPanel.SetActive(false);
        } else if (currentState == BANK_PROMPT_STATE) {
            merchantPanel.SetActive(false);
            promptPanel.SetActive(true);
            bankerPanel.SetActive(false);
        }

        if (Input.GetKeyDown("space") && prompted) {
            if (currentState == BANK_PROMPT_STATE) {
                currentState = BANK_SCREEN_STATE;
            }
            
            if (currentState == MERCHANT_PROMPT_STATE) {
                currentState = MERCHANT_SCREEN_STATE;
            }
             if (currentState == MERCHANT_SCREEN_STATE) {
                merchantPanel.SetActive(true);
                promptPanel.SetActive(false);
                bankerPanel.SetActive(false);
            }
            else if (currentState == BANK_SCREEN_STATE) {
                merchantPanel.SetActive(false);
                promptPanel.SetActive(false);
                bankerPanel.SetActive(true);
            }
        }
        if (currentState == STATE_NORMAL) {
            merchantPanel.SetActive(false);
         //   promptPanel.SetActive(false);
            bankerPanel.SetActive(false);   
        }	
	}

    void OnTriggerEnter(Collider other) {
        print("collided with object: " + other.gameObject.tag);
        if (other.gameObject.tag == "CollectableOne") {
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "MerchantTrigger") {
            currentState = MERCHANT_PROMPT_STATE;
            prompted = true;
        } else if (other.gameObject.tag == "BankTrigger") {
            currentState = BANK_PROMPT_STATE;
            prompted = true;
        } else if (other.gameObject.tag == "PortalTrigger") {
            portalPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "MerchantTrigger") {
            currentState = STATE_NORMAL;
            prompted = false;
            promptPanel.SetActive(false);
        }
        else if (other.gameObject.tag == "BankTrigger") {
            currentState = STATE_NORMAL;
            prompted = false;
            promptPanel.SetActive(false);
        } else if (other.gameObject.tag == "PortalTrigger") {
            portalPanel.SetActive(false);
            promptPanel.SetActive(false);
        }
    }
}
