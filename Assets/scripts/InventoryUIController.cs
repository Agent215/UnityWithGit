using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{

    //get how many items we have in store
    // get each item in store
    // for each item create a new header
    // set each header field
    // Start is called before the first frame update

    GameObject Inventory;
    public GameObject rowPrefab;
    public GameObject Parent;


    public GameObject Weed;
    public GameObject Speed;
    public GameObject Crack;
    public GameObject Heroin;
    public List<GameObject> Drugs;
    void Start()
    {

        Drugs.Add(Weed);
        Drugs.Add(Crack);
        Drugs.Add(Speed);
        Drugs.Add(Heroin);

    }

    public void updateInventoryUI()
    {
      
        int TotalItems = GameObject.Find("Inventory").GetComponent<Inventory>().getTotalItems();
        int i;
        Inventory inv = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE();
        //StartCoroutine(waiter());
        for (i = 0; i < TotalItems; i++)
        {

            if (inv.getItemByID(i) != null)
            {
                string name = inv.getItemByID(i).getName().ToString() + "  ";
                string avail = inv.getItemByID(i).getTotal().ToString();
                string price = inv.getItemByID(i).getPrice().ToString();
                Drugs[i].transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = name;
                Drugs[i].transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = avail;
                Drugs[i].transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = price;

            }




        }
    }

}
