using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectWallet : MonoBehaviour
{
    public GameObject connectPrompt;
    public CharacterMovementScript playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        connectPrompt.SetActive(true);
        playerMovementScript.runSpeed = 0f;
    }

    public void ConnectWalletFun()
    {
        connectPrompt.SetActive(false);
        playerMovementScript.runSpeed = 40f;
    }

    public void showConnectPrompt()
    {
        connectPrompt.SetActive(true);
        playerMovementScript.runSpeed = 0f;
    }
}
