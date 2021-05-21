using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{

    public GameObject storeInventory;

    public List<GameObject> listOfItems;
    public GameObject selectedItem;

    public GameObject StoreText;

    public void setSelectedItem(GameObject Item)
    {

        selectedItem = Item;
    }


    public GameObject getSelectedItem(GameObject Item)
    {

        return selectedItem;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        StoreText.GetComponent<UnityEngine.UI.Text>().text = toString();
    }


    // store will have its own inventory object.


    //generateNewRandomInventory()  will generate a new random inventory for the store.

    public void generateNewRandomInventory()
    {
        // storeInventory.GetComponent<Inventory>().clear();
        foreach (GameObject Item in listOfItems)
        {
         
            storeInventory.GetComponent<Inventory>().remove(Item.GetComponent<Item>().getName());
        }
        foreach (GameObject Item in listOfItems)
        {
            Item.GetComponent<Item>().generateNewPrice();
            storeInventory.GetComponent<Inventory>().add(Item, (int)Mathf.Round(Random.Range(10f, 100f)));
        }
    }
    //Buy(string itemName, int amount)   this is a buy from player perspective so substract given amount from store inventory
    public void Buy(Item item, int amount)
    {

        storeInventory.GetComponent<Inventory>().removeFromInventory(item, amount);

    }

    //Sell(string itemName, int amount)   this is a sell from player perspective so add given amount from store inventory
    public void Sell(GameObject item, int amount)
    {

        storeInventory.GetComponent<Inventory>().add(item, amount);

    }


    public string toString()
    {

        return storeInventory.GetComponent<Inventory>().toString();
    }


    public GameObject getStore(){

        return storeInventory;
    }
}
