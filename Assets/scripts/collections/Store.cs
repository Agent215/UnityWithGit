using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{


    // store will have its own inventory object.
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
        GameObject weed = (GameObject)Resources.Load("prefabs/weed", typeof(GameObject));
        Instantiate(weed, new Vector3(0, 0, 0), Quaternion.identity);
        listOfItems.Add(GameObject.Find("weed(Clone)"));

        GameObject crack = (GameObject)Resources.Load("prefabs/crack", typeof(GameObject));
        Instantiate(crack, new Vector3(0, 0, 0), Quaternion.identity);
        listOfItems.Add(GameObject.Find("crack(Clone)"));

        GameObject speed = (GameObject)Resources.Load("prefabs/speed", typeof(GameObject));
        Instantiate(speed, new Vector3(0, 0, 0), Quaternion.identity);
        listOfItems.Add(GameObject.Find("speed(Clone)"));

        GameObject heroin = (GameObject)Resources.Load("prefabs/heroin", typeof(GameObject));
        Instantiate(heroin, new Vector3(0, 0, 0), Quaternion.identity);
        listOfItems.Add(GameObject.Find("heroin(Clone)"));

         GameObject acid = (GameObject)Resources.Load("prefabs/acid", typeof(GameObject));
        Instantiate(acid, new Vector3(0, 0, 0), Quaternion.identity);
        listOfItems.Add(GameObject.Find("acid(Clone)"));


         GameObject cocaine = (GameObject)Resources.Load("prefabs/cocaine", typeof(GameObject));
        Instantiate(cocaine, new Vector3(0, 0, 0), Quaternion.identity);
        listOfItems.Add(GameObject.Find("cocaine(Clone)"));

        StartCoroutine(LateStart(.01f));

    }

    public void generateStore()
    {
        generateNewRandomInventory();
        GameObject.Find("GameController").GetComponent<StoreUIController>().updateStoreUI();
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        generateStore();
    }
    void Update()
    {

        // StoreText.GetComponent<UnityEngine.UI.Text>().text = toString();
    }


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


    public GameObject getStore()
    {

        return storeInventory;
    }
}
