using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject gameController;

    public GameObject EventModal;

    private bool isOver;
    void Start()
    {
        var gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject gmo in gameObjects)
        {
            if (gmo.name == "EventModal")
            {
                this.EventModal = gmo;
            }
        }

        isOver = false;
        gameController = GameObject.Find("GameController");
    }


    public GameEvent generateRandomEvent()
    {
        GameEvent DrugBust = new GameEvent();
        int count = gameController.GetComponent<Store>().getStore().GetComponent<Inventory>().getTotalItems();
        int i = (int)Mathf.Round(Random.Range(0, count));
        Item item = gameController.GetComponent<Store>().getStore().GetComponent<Inventory>().getItemByID(i);
        int ran = Random.Range(0, 10);
        if (ran > 5)
        {

            DrugBust.setEventName("DRUG BUST");
            DrugBust.setEventDescription("Cops made a big " + item.getName() + " bust, prices are through the roof!");
            DrugBust.setPriceModifier(3f);
            DrugBust.setDrugName(item.getName());

        }
        else
        {

            DrugBust.setEventName("DRUG Shipment");
            DrugBust.setEventDescription("A big Shipment of " + item.getName() + " came in, prices are rock bottem!");
            DrugBust.setPriceModifier(.3f);
            DrugBust.setDrugName(item.getName());
        }
        //TODO add a robbery 
        //TODO return list of events for multiple events on one day

        return DrugBust;

    }


    // call this function once per day or when you want to generate an event
    public void randomChanceOfEvent()
    {

        // define some probability that an event will occur
        int prob = 2;
        int ran = Random.Range(0, 10);

        // if event occurs
        if (ran < prob)
        {

            Debug.Log("Event Occured!");
            //generate an event
            GameEvent evt = generateRandomEvent();
            // then set the UI up 
            EventModal.SetActive(true);
            //set name
            EventModal.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = evt.getEventName();
            EventModal.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = evt.getEventDescription();

            float oldPrice = gameController.GetComponent<Store>().getStore().GetComponent<Inventory>().getItemByName(evt.getDrugName()).getPrice();
            float newPrice = (int)Mathf.Round(gameController.GetComponent<Store>().getStore().GetComponent<Inventory>().getItemByName(evt.getDrugName()).getPrice() * evt.priceModifier);
            Debug.Log("Event old price " + oldPrice + " new price :" + newPrice);
            gameController.GetComponent<Store>().getStore().GetComponent<Inventory>().getItemByName(evt.getDrugName()).setPrice(newPrice);
            gameController.GetComponent<StoreUIController>().updateStoreUI();
            //and change the prices for items
        }
        else
        {
            EventModal.SetActive(false);
            //else do nothing
        }

    }


    //TODO move most of this out of main in to an eventUIcontroller class
    public void closeEvent()
    {
        EventModal.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        //game is over when days == 0
        if (gameController.GetComponent<calendar>().getDays() == 0)
        {
            isOver = true;
        }

        if (isOver)
        {
            gameController.GetComponent<SceneController>().goToGameOverScene();
            isOver = false; // should not reach here.
        }

    }
}
