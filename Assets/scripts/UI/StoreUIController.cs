using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUIController : MonoBehaviour
{


    //get how many items we have in store
    // get each item in store
    // for each item create a new header
    // set each header field
    // Start is called before the first frame update

    public GameObject storeInventory;
    public GameObject Parent;


    public List<GameObject> DrugRows;
    void Start()
    {


        GameObject parent = GameObject.FindGameObjectWithTag("StoreParent");
        GameObject row1 = (GameObject)Resources.Load("prefabs/StoreHeader", typeof(GameObject));
        GameObject row2 = (GameObject)Resources.Load("prefabs/StoreHeader", typeof(GameObject));
        GameObject row3 = (GameObject)Resources.Load("prefabs/StoreHeader", typeof(GameObject));
        GameObject row4 = (GameObject)Resources.Load("prefabs/StoreHeader", typeof(GameObject));
        GameObject row5 = (GameObject)Resources.Load("prefabs/StoreHeader", typeof(GameObject));
        GameObject row6 = (GameObject)Resources.Load("prefabs/StoreHeader", typeof(GameObject));

        Instantiate(row1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row2, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row3, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row4, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row5, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row6, new Vector3(0, 0, 0), Quaternion.identity);

        GameObject[] rows = GameObject.FindGameObjectsWithTag("StoreRow");

        foreach (GameObject gmo in rows)
        {
            gmo.transform.parent = parent.transform;
            DrugRows.Add(gmo);
        }
        // updateStoreUI();
        // DrugRows.Add(row1);
        // DrugRows.Add(row2);
        // DrugRows.Add(row3);
        // DrugRows.Add(row4);

    }

    public void updateStoreUI()
    {
        storeInventory = GameObject.Find("GameController").GetComponent<Store>().getStore();



        int TotalItems = storeInventory.GetComponent<Inventory>().getTotalItems();
        int i;
        Inventory inv = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
        //StartCoroutine(waiter());
        for (i = 0; i < TotalItems; i++)
        {



            string name = inv.getItemByID(i).getName().ToString() + "  ";
            string avail = inv.getItemByID(i).getTotal().ToString();
            string price = inv.getItemByID(i).getPrice().ToString();
            DrugRows[i].transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = name;
            DrugRows[i].transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = avail;
            DrugRows[i].transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = price;


        }
    }


}
