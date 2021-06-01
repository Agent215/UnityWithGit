using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, GameObject> inventory;
    public ArrayList itemNames;
    public int maxTotal = 0;
    public int currentTotal = 0;
    public GameObject Text;
    

    private string iventoryAsString;

    /**
     * Inventory is a basic collection class which allows
     * you to addCash an item and specify the total amount of
     * that item. Since this is a departure from the base
     * class AbstractCollection, the default addCash and removed
     * are not used. In their place is addToInventory and
     * removeFromInventory.
     */

    void Start()
    {
    
        iventoryAsString = "";
        this.inventory = new Dictionary<string, GameObject>();
        itemNames = new ArrayList();


    }

    void Update()
    {

        Text.GetComponent<UnityEngine.UI.Text>().text = toString();
    }

    public int getMaxTotal()
    {
        return maxTotal;
    }

    /**
     * Max Total represent the total amount of items the inventory
     * can carry. MaxTotal can not be set to a value lower then
     * the current total or it will throw an error.
     *
     * @param value
     */
    public void setMaxTotal(int value)
    {
        if (maxTotal == value)
            return;
        else if (value < currentTotal && value > -1)
            throw new System.Exception("New MaxTotal is lower then current total");

        this.maxTotal = value;
    }

    /**
     * Gets the inventories total. If the MaxTotal is set to -1 this
     * will always return 0.
     *
     * @return
     */
    public int getCurrentTotal()
    {
        return currentTotal;
    }

    /**
     * @param value
     */
    //TODO need to add tests for this
    protected void subtractFromTotal(int value)
    {
        if (maxTotal == -1)
            return;

        currentTotal -= value;
        if (currentTotal < 0)
            currentTotal = 0;//TODO this should throw an error -> throw new Error("Current total cannon go below 0.");
    }

    /**
     * @param value
     */
    //TODO need to add tests for this
    protected void addToTotal(int value)
    {
        if (maxTotal == -1)
            return;

        currentTotal += value;
        if (getCurrentTotal() > maxTotal)
            throw new System.Exception("Current total can't go above the Max Total.");
    }

    /**
     * Adds an item to the inventory along with a amount
     * for that item.
     *
     * @param item
     * @return
     */
    public void add(GameObject item, int amount)
    {

        addToTotal(amount);

        if (inventory.ContainsKey(item.GetComponent<Item>().getName()))
        {
            addToItemTotal(item.GetComponent<Item>().getName(), amount);
            return;
        }
        item.GetComponent<Item>().setTotal(amount);
        Debug.Log("adding to inventory %s", item);
        Debug.Log(item);
        inventory.Add(item.GetComponent<Item>().getName(), item);
        itemNames.Add(item.GetComponent<Item>().getName());
        Debug.Log(inventory.Count);

    }

    /**
     * Completely removes and item from the Inventory.
     *
     * @param name
     * @return
     */
    public bool remove(string name)
    {
        if (inventory.ContainsKey(name))
        {

            // Remove item's total from inventory total before removing item
            subtractFromTotal(((Item)inventory[name].GetComponent<Item>()).getTotal());
            inventory.Remove(name);
            itemNames.Remove(name);
               Debug.Log("removing from inventory");
            return true;
        }
        else
        {
                           Debug.Log("error removing from inventory");
            return false;

        }

    }

    /**
     * Removes some amount of an item from the inventory
     * and returns what is left for that item.
     *
     * @param id
     * @param amount
     * @return
     */
    public int removeFromInventory(Item id, int amount)
    {
        if (!hasItem(id.getName()))
        {
            return 0;
        }
        else
        {
            int remainder = getItemTotal(id.getName()) - amount;
            inventory[id.getName()].GetComponent<Item>().setTotal(remainder);
            if (remainder <= 0)
            {
                remove(id.getName());
            }
            subtractFromTotal(amount);

            return remainder;
        }

    }

    public int getTotalItems()
    {
        return inventory.Count;
    }

    public int getItemTotal(string name)
    {
        return inventory[name].GetComponent<Item>().getTotal();
    }

    public Item get(string name)
    {
        return inventory[name].GetComponent<Item>();
    }

    public int addToItemTotal(string name, int value)
    {
        Item tmpItem = inventory[name].GetComponent<Item>();

        tmpItem.setTotal(tmpItem.getTotal() + value);
       // addToTotal(value);

        return tmpItem.getTotal();
    }

    public bool hasItem(string name)
    {
        return inventory.ContainsKey(name);
    }

    //TODO this needs to be tested
    public string[] getInventoryAsArray()
    {
        //TODO this needs to have some sort of invalidation
        return convert(inventory);
    }

    protected string[] convert(Dictionary<string, GameObject> things)
    {

        string[] tArray = new string[things.Count];
        things.Keys.CopyTo(tArray, 0);

        Array.Sort(tArray);
        return tArray;
    }

    public int getTotalLeft()
    {
        return maxTotal - currentTotal;
    }

    public void clear()
    {
        inventory.Clear();
        itemNames.Clear();
    }

    public Item getItemByID(int i)
    {
        return get(getInventoryAsArray()[i]);
    }


    public String toString()
    {

        String output = "\"inventory\":{\"maxTotal\":" + getMaxTotal() + ",\"currentTotal\":" + getCurrentTotal() + ",\"items\":[";

        int i;
        int total = getTotalItems();

        for (i = 0; i < total; i++)
        {
            output += getItemByID(i).toString() + " ";
        }

        return output.Substring(0, output.Length - 1) + "]}";
    }

    public ArrayList getItemNames()
    {
        return itemNames;
    }

      public  Dictionary<string, GameObject> getInventory()
    {
        return inventory;
    }

    public Item getItemByName(string itemName)
    {
              
        return inventory[itemName].GetComponent<Item>();
    }

    public string getItemTotalToString(string itemName){

        return getItemByName(itemName).getTotal().ToString();
    }

      public string getItemPriceToString(string itemName){

        return getItemByName(itemName).getPrice().ToString();
    }

      public  Inventory getInventoryE()
    {
        return this;
    }
}

