using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour, IPointerClickHandler
{

    public GameObject POS;

    public bool isActive;

    private string drugName = "";
    private string price = "";


    void Start()
    {

        // get all gameobjects
        var gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // set correct POS for this item to use
        // we are using buy pos
        if (gameObject.name == "StoreHeader(Clone)" || gameObject.name == "GameController")
        {
            foreach (GameObject gmo in gameObjects)
            {
                if (gmo.name == "BuyModal")
                {
                    this.POS = gmo;
                }
            }
        }
        else
        {  // we are using sell pos
            foreach (GameObject gmo in gameObjects)
            {
                if (gmo.name == "SellModal")
                {
                    this.POS = gmo;
                }
            }
        }

        // is a pos active
        isActive = GameObject.Find("GameController").GetComponent<Flags>().getBuyPOSactive();
    }


    public void close()
    {
        isActive = false;
        GameObject.Find("GameController").GetComponent<Flags>().setBuyPOSactive(false);
        POS.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData) // 3
    {

        //is pos active
        isActive = GameObject.Find("GameController").GetComponent<Flags>().getBuyPOSactive();
        drugName = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        price = gameObject.transform.GetChild(2).GetComponent<Text>().text;
        print("Item was clicked");
        if (isActive)
        {
            isActive = false; POS.SetActive(false);
            GameObject.Find("GameController").GetComponent<Flags>().setBuyPOSactive(false);
        }
        else
        {
            isActive = true;
            Debug.Log("i am activated");
            POS.SetActive(true);
            GameObject.Find("GameController").GetComponent<Flags>().setBuyPOSactive(true);
        }


        // set the amount on modal depending on if we are selling or buying
        if (POS.name == "SellModal")
        {
            GameObject.Find("GameController").GetComponent<POSUI>().setSellAmount(drugName, price);
        }
        else
        {
            GameObject.Find("GameController").GetComponent<POSUI>().setAmount(drugName, price);

        }
    }

}
