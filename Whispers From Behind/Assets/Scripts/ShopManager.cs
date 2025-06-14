using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public GameObject player;
    public TMP_Text healthCountText;
    public TMP_Text chaseBufferCountText;
    public TMP_Text multiplierCountText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyChaseBuffer()
    {
        if (gameObject.GetComponent<CurrencyManager>().GetCurrency() < 25)
        {
            Debug.Log("Not Enough Currency!");
            return;
        }
        else if (gameObject.GetComponent<ChaseManager>().GetProgressSlow() >= 2)
        {
            Debug.Log("Max Chase Buffer Reached!");
            return;
        }
        else
        {
            gameObject.GetComponent<CurrencyManager>().currencyAmount -= 25;
            gameObject.GetComponent<CurrencyManager>().CurrencyText();
            Debug.Log("Chase Buffer Purchased!");

            gameObject.GetComponent<ChaseManager>().SetProgressSlow(2);
        }
        chaseBufferCountText.text = gameObject.GetComponent<ChaseManager>().GetProgressSlow().ToString() + " / 2";
    }
    public void BuyHealthUpgrade()
    {
        if (player.GetComponent<Health>().GetMaxHealth() >= 5)
        {
            Debug.Log("Max Health Reached!");
            return;
        }
        else if (gameObject.GetComponent<CurrencyManager>().GetCurrency() < 10)
        {
            Debug.Log("Not Enough Currency!");
            return;
        }
        else
        {
            gameObject.GetComponent<CurrencyManager>().currencyAmount -= 10;
            gameObject.GetComponent<CurrencyManager>().CurrencyText();
            Debug.Log("Health Upgrade Purchased!");

            player.GetComponent<Health>().IncreceMaxHealth(1);

        }
        healthCountText.text = player.GetComponent<Health>().GetMaxHealth().ToString() + " / 5";


    }
    public void BuyMultiplier()
    {
        if (gameObject.GetComponent<ScoreManager>().GetMultiplier() >= 3)
        {
            Debug.Log("Max Score Multiplier Reached!");
            return;
        }
        else if (gameObject.GetComponent<CurrencyManager>().GetCurrency() < 5)
        {
            Debug.Log("Not Enough Currency!");
            return;
        }
        else
        {
            gameObject.GetComponent<CurrencyManager>().currencyAmount -= 5;
            gameObject.GetComponent<CurrencyManager>().CurrencyText();
            gameObject.GetComponent<ScoreManager>().IncreaseMultiplier(1);
            Debug.Log("Score Multiplier Purchased!");
        }
        multiplierCountText.text = gameObject.GetComponent<ScoreManager>().GetMultiplier().ToString() + " / 3";
    }
    
    public void SetUpgradeCounts()
    {
        healthCountText.text = player.GetComponent<Health>().GetMaxHealth().ToString() + " / 5";
        chaseBufferCountText.text = gameObject.GetComponent<ChaseManager>().GetProgressSlow().ToString() + " / 2";
        multiplierCountText.text = gameObject.GetComponent<ScoreManager>().GetMultiplier().ToString() + " / 3";
    }
}
