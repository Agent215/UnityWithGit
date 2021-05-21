using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public GameObject CashText;
   public float cash = 0;



   void Update(){

         CashText.GetComponent<UnityEngine.UI.Text>().text = "Cash: "+ getCash().ToString();
   }

    /**
     * The wallet is a basic container for currency.
     * It simply allows you to store and retrieve
     * the value inside of it.
     *
     * @param value
     */
    public Wallet(float value)
    {
        cash = value;
    }

    /**
     * Total in wallet.
     *
     * @return
     */
    public float getCash()
    {
        return cash;
    }

    /**
     * Change the value of the total.
     *
     * @param value
     */
    public void setCash(float value)
    {
        cash = value;
    }

    /**
     * Adds to the wallet's value.
     *
     * @param value
     */
    public float addCash(float value)
    {
        return cash += value;
    }

    /**
     * Adds to the wallet's value.
     *
     * @param value
     */
    public float subtractCash(float value)
    {
        return cash -= value;
    }

    public string toString()
    {
        return "\"wallet\":{" +
                "\"cash\":" + cash + "}";
    }
}
