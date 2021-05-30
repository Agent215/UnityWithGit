using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POSUI : MonoBehaviour
{
    public GameObject Wallet;

    public GameObject Inventory;
    public GameObject POS;
    public GameObject sellPOS;
    public int buyQuantity;

    public Slider priceSlider;
    public Slider SellPriceSlider;
    void Start()
    {

        //Adds a listener to the main slider and invokes a method when the value changes.

    }




    public void setAmount(string drugName, string price)
    {

        GameObject.Find("DrugNameText").GetComponent<Text>().text = drugName + " $" + price;
        priceSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        priceSlider = POS.transform.GetChild(0).GetChild(4).GetComponent<Slider>();
        Inventory inv = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
        string name = POS.transform.GetChild(0).GetChild(2).GetComponent<Text>().text;
        name = name.Substring(0, name.IndexOf(" "));
        Item item = inv.getItemByName(name);
        float iprice = item.getPrice();

        // set slider to be the max amount player can buy with current cash 
        int possibleBuy = ((int)(GameObject.Find("wallet").GetComponent<Wallet>().getCash()) / (int)iprice);
        if (possibleBuy > 100) //TODO change 100 to be tied to inventory size
        {
            priceSlider.maxValue = 100;
            priceSlider.value = 100;
            GameObject.Find("Amount").GetComponent<Text>().text = "100";
        }
        else
        {
            priceSlider.maxValue = possibleBuy;
            priceSlider.value = possibleBuy;
            GameObject.Find("Amount").GetComponent<Text>().text = possibleBuy.ToString();


        }

    }

    public void setSellAmount(string drugName, string price)
    {

        Inventory inv1 = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
        //  Item item1 = inv1.getItemByName(drugName);
        //  float iprice = item1.getPrice();

        GameObject.Find("DrugNameText").GetComponent<Text>().text = drugName + " paid $" + price;
        SellPriceSlider = sellPOS.transform.GetChild(0).GetChild(4).GetComponent<Slider>();
        SellPriceSlider.onValueChanged.AddListener(delegate { ValueChangeCheck1(); });
        Inventory inv = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE();
        string name = sellPOS.transform.GetChild(0).GetChild(2).GetComponent<Text>().text;
        name = name.Substring(0, name.IndexOf(" "));
        Item item = Inventory.GetComponent<Inventory>().getInventoryE().getItemByName(name);
        //float iprice = item.getPrice();

        SellPriceSlider.maxValue = item.getTotal();
        SellPriceSlider.value = item.getTotal();
        GameObject.Find("SellAmount").GetComponent<Text>().text = item.getTotal().ToString();

    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        Debug.Log(priceSlider.value);

        GameObject.Find("Amount").GetComponent<Text>().text = priceSlider.value.ToString();
    }

    public void ValueChangeCheck1()
    {
        Debug.Log(SellPriceSlider.value);

        GameObject.Find("SellAmount").GetComponent<Text>().text = SellPriceSlider.value.ToString();
    }


    public void testBuy()
    {
        Inventory inv = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
        Wallet.GetComponent<Wallet>().subtractCash(inv.getItemByName("weed").getPrice());
        GameObject weed = GameObject.Find("weed");
        Inventory inv1 = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE();
        inv1.add(weed, 1);
        GameObject.Find("GameController").GetComponent<InventoryUIController>().updateInventoryUI();
    }

    public void onSell()
    {

        string name = sellPOS.transform.GetChild(0).GetChild(2).GetComponent<Text>().text;
        name = name.Substring(0, name.IndexOf(" "));
        int amount = (int)priceSlider.value;
        Inventory inv = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
        int sellPrice = (int)inv.getItemByName(name).getPrice() * amount;
        int cash = (int)Wallet.GetComponent<Wallet>().getCash();

        Debug.Log("selling " + amount + " " + name + " for " + sellPrice);
        Wallet.GetComponent<Wallet>().addCash(inv.getItemByName(name).getPrice() * amount);
        GameObject item = GameObject.Find(name);
        Inventory inv1 = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE();
        inv1.removeFromInventory(item.GetComponent<Item>(), amount);
        GameObject.Find("GameController").GetComponent<InventoryUIController>().resetInventory();
        GameObject.Find("GameController").GetComponent<InventoryUIController>().updateInventoryUI();


    }


    public void onBuy()
    {



        string name = POS.transform.GetChild(0).GetChild(2).GetComponent<Text>().text;
        name = name.Substring(0, name.IndexOf(" "));
        int amount = (int)priceSlider.value;
        Inventory inv = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
        float price = inv.getItemByName(name).getPrice();
        int purchasePrice = (int)price * amount;

        int cash = (int)Wallet.GetComponent<Wallet>().getCash();
        //check if we can buy
        if ((purchasePrice <= cash) && amount != 0)
        {

            Debug.Log("Buying " + amount + " of " + name + " for" + purchasePrice);
            Wallet.GetComponent<Wallet>().subtractCash(price * amount);
            GameObject item = GameObject.Find(name);
            item.GetComponent<Item>().setPrice(price);
            Inventory inv1 = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE();
            inv1.add(item, amount);
            GameObject.Find("GameController").GetComponent<InventoryUIController>().updateInventoryUI();
        }
        else
        {


        }


    }
}
