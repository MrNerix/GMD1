using UnityEngine;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    public int currencyAmount;
    public TMP_Text shopText; // Reference to the UI text component to display currency in the shop
    public TMP_Text currencyText; // Reference to the UI text component to display currency
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currencyAmount = 0; // Initialize currency amount to 0
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCurrencyFromScore(int score)
    {
        currencyAmount += score / 100; // Convert score to currency (1 currency for every 10 score)
        CurrencyText(); // Update the UI text to reflect the new currency amount
    }

    public void CurrencyText()
    {
        currencyText.text = currencyAmount.ToString(); // Update the UI text with the current currency amount
        shopText.text = currencyAmount.ToString(); // Update the shop text with the current currency amount
    }
    public int GetCurrency()
    {
        return currencyAmount; // Return the current currency amount
    }
}
