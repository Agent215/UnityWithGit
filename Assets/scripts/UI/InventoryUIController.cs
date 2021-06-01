using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{

    //get how many items we have in store
    // get each item in store
    // for each item create a new header
    // set each header field
    // Start is called before the first frame update

    GameObject Inventory;

    public GameObject Parent;


    public GameObject Weed;
    public GameObject Speed;
    public GameObject Crack;
    public GameObject Heroin;
    public List<GameObject> Drugs;

    public GameObject InventoryText;
    int totalInvCount;

    void Start()
    {

        totalInvCount = 0;
        GameObject parent = GameObject.FindGameObjectWithTag("InventoryParent");
        GameObject row1 = (GameObject)Resources.Load("prefabs/InventoryRow", typeof(GameObject));
        GameObject row2 = (GameObject)Resources.Load("prefabs/InventoryRow", typeof(GameObject));
        GameObject row3 = (GameObject)Resources.Load("prefabs/InventoryRow", typeof(GameObject));
        GameObject row4 = (GameObject)Resources.Load("prefabs/InventoryRow", typeof(GameObject));
        GameObject row5 = (GameObject)Resources.Load("prefabs/InventoryRow", typeof(GameObject));
        GameObject row6 = (GameObject)Resources.Load("prefabs/InventoryRow", typeof(GameObject));

        Instantiate(row1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row2, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row3, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row4, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row5, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(row6, new Vector3(0, 0, 0), Quaternion.identity);

        GameObject[] rows = GameObject.FindGameObjectsWithTag("InventoryRow");

        foreach (GameObject gmo in rows)
        {
            gmo.transform.parent = parent.transform;
            Drugs.Add(gmo);
            gmo.SetActive(false);
        }




    }

    public void resetInventory()
    {

        for (int i = 0; i < 4; i++)
        {
            Drugs[i].SetActive(false);
            Drugs[i].transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
            Drugs[i].transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
            Drugs[i].transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        }

    }

    public void updateInventoryUI()
    {

        int TotalItems = GameObject.Find("Inventory").GetComponent<Inventory>().getTotalItems();
        int i;
        Inventory inv = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE();
        totalInvCount = GameObject.Find("Inventory").GetComponent<Inventory>().getCurrentTotal();
        InventoryText.GetComponent<Text>().text = totalInvCount + "/100";
        //StartCoroutine(waiter());
        for (i = 0; i < TotalItems; i++)
        {

            if (inv.getItemByID(i) != null)
            {
                Drugs[i].SetActive(true);
                string name = inv.getItemByID(i).getName().ToString() + "  ";
                string avail = inv.getItemByID(i).getTotal().ToString();
                string price = inv.getItemByID(i).getPrice().ToString();
                Drugs[i].transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = name;
                Drugs[i].transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = avail;
                Drugs[i].transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = price;

            }
            else
            {
                Drugs[i].SetActive(false);
                Drugs[i].transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
                Drugs[i].transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
                Drugs[i].transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
            }

        }


    }

}
