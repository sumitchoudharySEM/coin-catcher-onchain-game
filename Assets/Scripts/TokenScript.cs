using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;

public class TokenScript : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI tokenBalenceText;
    private const string DROP_ERC20_CONTRACT_ADDRESS = "0x686dcA8Dcf4290455C162Cd272009a5c444953f5";

    public async void GetTokenBalence()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(DROP_ERC20_CONTRACT_ADDRESS);
            var balence = await contract.ERC20.BalanceOf(address);
            tokenBalenceText.text = "$GEM: " + balence.displayValue;
            Debug.Log("Token balence: " + balence.displayValue);
        }
        catch (System.Exception e)
        {
            Debug.Log("Error getting token balence: " + e.Message);
        }
    }

    public void ResetBalance(){
        tokenBalenceText.text = "$GEM: 0";
    }
}
