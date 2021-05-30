using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


[System.Serializable]
public class Item : MonoBehaviour, IItem
{ 
    public float minPrice = 0;
    public float maxPrice = 0;
    public float price = 0;
    public string ItemName = "undefined";
    public string description = "";
    public int total;
    public bool active;
    public ArrayList priceHistory;

 void Start()
    {
        priceHistory = new ArrayList();
    }


    public int getMaxHistory()
    {
        return maxHistory;
    }

    public void setMaxHistory(int maxHistory)
    {
        this.maxHistory = maxHistory;
    }

    protected int maxHistory = -1;
    /**
     * Returns is the item is flagged as active.
     *
     * @return
     */
    public bool isActive()
    {
        return active;
    }

    /**
     * Sets the active value of the item.
     *
     * @param active
     */
    public void setActive(bool active)
    {
        this.active = active;
    }


    /**
     * Returns the min price for the item.
     *
     * @return
     */
    public float getMinPrice()
    {
        return minPrice;
    }

    /**
     * Sets the Minimum Price for the Item. This is used when
     * randomly generating a new price.
     *
     * @param value
     */
    public void setMinPrice(float value)
    {
        minPrice = value < 0 ? 0 : value;
    }

    /**
     * @return
     */
    public float getMaxPrice()
    {
        return maxPrice;
    }

    /**
     * Sets the Maximum price for the Item. This is used when
     * randomly generating a new price.
     *
     * @param value
     */
    public void setMaxPrice(float value)
    {
        maxPrice = value <= minPrice ? minPrice : value;
    }

    /**
     * @return
     */
    public float getPrice()
    {
        return price;
    }

    /**
     * Returns the price of the item.
     *
     * @param value
     */
    public void setPrice(float value)
    {
        price = value < 0 ? 0 : value;
        //TODO need to addCash in logic to limit the max number of price history.
        addToHistory(price);
    }

    protected void addToHistory(float value)
    {
        priceHistory.Add(value);
        
        if(maxHistory > 0 && priceHistory.Count > maxHistory)
        {
            priceHistory.RemoveAt(0);
        }
    }

    /**
     * Returns the name of the Item. The name is read only and
     * lock in at the time of construction.
     *
     * @return
     */
    public string getName()
    {
        return ItemName;
    }

    public void setName(string name)
    {
         this.ItemName = name;
    }

    /**
     * Returns the description of the Item.
     *
     * @return
     */
    public string getDescription()
    {
        return description;
    }

    /**
     * Sets a description for the item.
     *
     * @param value
     */
    public void setDescription(string value)
    {
        description = value;
    }

    /**
     * This generates a new price for the Item based on it's
     * min/max price. It returns the new price.
     *
     * @return
     */
    public void generateNewPrice()
    {
        setPrice(Mathf.Round(Random.Range((float)minPrice,(float)maxPrice)));
      
    }

    /**
     * Returns total number of items in an instance.
     *
     * @return
     */
    public int getTotal()
    {
        return total;
    }

    /**
     * Sets a new total for the items of an instance. This overrides
     * any previous value.
     *
     * @param value
     */
    public void setTotal(int value)
    {
        if (value == total)
            return;

        total = value < 0 ? 0 : value;
    }

   
    public ArrayList getPriceHistory()
    {
        return priceHistory;
    }

    public string priceHistoryToString(string delimiter)
    {
        if (delimiter == null)
            delimiter = ",";
        StringBuilder sb = new StringBuilder();
        int total = priceHistory.Count;
        int i;
        for (i = 0; i < total; i++)
        {
            sb.Append(priceHistory[i].ToString());
            if (i + 1 < total)
                sb.Append(delimiter);
        }

        return sb.ToString();
    }



    public string toString()
    {
        return "{\"name\":\"" + getName() + "\"," +
                "\"minPrice\":" + minPrice + "," +
                "\"maxPrice\":" + maxPrice + "," +
                "\"price\":" + price + "," +
                "\"total\":" + total + "," +
                "\"description\":\"" + description + "\"," +
                "\"history\":[" + priceHistoryToString(",") + "]," +
                "\"active\":" + active + "" +
                "}";
    }


}
