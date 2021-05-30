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
        isActive = GameObject.Find("GameController").GetComponent<Flags>().getBuyPOSactive();
    }

    void Update()
    {


    }

    public void close()
    {
        isActive = false;
        GameObject.Find("GameController").GetComponent<Flags>().setBuyPOSactive(false);
        POS.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData) // 3
    {
        isActive = GameObject.Find("GameController").GetComponent<Flags>().getBuyPOSactive();
        drugName = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        price = gameObject.transform.GetChild(2).GetComponent<Text>().text;
        print("I was clicked");
        if (isActive)
        {
            Debug.Log("i am deactivated");
            isActive = false; POS.SetActive(false);
            GameObject.Find("GameController").GetComponent<Flags>().setBuyPOSactive(false);
        }
        else
        {
            isActive = true;
            Debug.Log("i am activated");
            POS.SetActive(true);
            GameObject.Find("GameController").GetComponent<Flags>().setBuyPOSactive(true);

            // GameObject.Find("DrugNameText").GetComponent<Text>().text = drugName + " $" + price;

        }

        if (POS.name == "SellModal")
        {
            GameObject.Find("GameController").GetComponent<POSUI>().setSellAmount(drugName,price);
        }
        else
        {
            GameObject.Find("GameController").GetComponent<POSUI>().setAmount(drugName,price);

        }
    }

}
