using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{

    public string eventName;

    public string eventDescription;


    public float priceModifier;

    public string DrugName;



    public string getEventName()
    {

        return this.eventName;
    }

    public void setEventName(string name)
    {

        this.eventName = name;
    }

    public string getDrugName()
    {

        return this.DrugName;
    }

    public void setDrugName(string name)
    {

        this.DrugName = name;
    }

    public string getEventDescription()
    {

        return this.eventDescription;
    }

    public void setEventDescription(string description)
    {

        this.eventDescription = description;
    }



    public float getPriceModifier()
    {

        return this.priceModifier;
    }

    public void setPriceModifier(float modifier)
    {

        this.priceModifier = modifier;
    }
}
