using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSUI : MonoBehaviour
{
    public GameObject Wallet;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    

    public void testBuy(){
   Inventory inv = GameObject.Find("GameController").GetComponent<Store>().getStore().GetComponent<Inventory>().getInventoryE();
          Wallet.GetComponent<Wallet>().subtractCash(inv.getItemByName("weed").getPrice());     
          GameObject weed = GameObject.Find("weed");
          Inventory inv1 = GameObject.Find("Inventory").GetComponent<Inventory>().getInventoryE(); 
          inv1.add(weed,1);
          GameObject.Find("GameController").GetComponent<InventoryUIController>().updateInventoryUI();
    }

    public void onSell(){


    }
}
