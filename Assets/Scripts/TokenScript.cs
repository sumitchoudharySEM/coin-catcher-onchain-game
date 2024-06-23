using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;

public class TokenScript : MonoBehaviour
{
    public GemCollectorScript gemCollectorScript;
    public GameObject HasNotClamed;
    public GameObject Clamining;
    public GameObject Clamed;
    private int gemsToClaim;
    [SerializeField] public TMPro.TextMeshProUGUI EarnedTokenText;
    [SerializeField] private TMPro.TextMeshProUGUI tokenBalenceText;
    private const string DROP_ERC20_CONTRACT_ADDRESS = "0x686dcA8Dcf4290455C162Cd272009a5c444953f5";

    void Start()
    {
        HasNotClamed.SetActive(true);
        Clamining.SetActive(false);
        Clamed.SetActive(false);
    }

    void Update()
    {
        EarnedTokenText.text = "Earned Token: " + gemCollectorScript.gemCount.ToString();
        gemsToClaim = gemCollectorScript.gemCount;

    }

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

    public async void MintERC20()
    {
        try
        {
            Debug.Log("Minting token");
            var address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(DROP_ERC20_CONTRACT_ADDRESS);
            HasNotClamed.SetActive(false);
            Clamining.SetActive(true);
            var results = await contract.ERC20.Claim(gemsToClaim.ToString());
            Debug.Log("Minted: " + results);
            GetTokenBalence();
            Clamining.SetActive(false);
            Clamed.SetActive(true);
        }
        catch (System.Exception e)
        {
            Debug.Log("Error minting token: " + e.Message);
        }
    }
}
