using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
    * The map represent a collection of collections.
    * It tracks the current and last location visited.
    */
public class Locations : MonoBehaviour
{

    public int currentLocation = 0;
    public int lastID;
    public ArrayList locations;

    public GameObject Text;





    void Start()
    {
        locations = new ArrayList();
        add("Philadelphia");
        add("New York");
        add("Chicago");
        add("Boston");

        gotoLocationByName("New York");
    }

    void Update()
    {

        Text.GetComponent<UnityEngine.UI.Text>().text = getCurrentLocation();
    }


    public void nextLocation()
    {
        if (currentLocation == locations.Count-1)
        {
            gotoLocation(0);
        }
        else
        {
            gotoLocation(currentLocation + 1);

        }

    }

    public void previousLocation()
    {
       

        if (currentLocation == 0)
        {
            gotoLocation(locations.Count-1);
        }
        else
        {
          gotoLocation(currentLocation - 1);

        }
    }


    public int add(string value)
    {
        if (!locations.Contains(value))
            locations.Add(value);

        return locations.IndexOf(value);
    }

    /**
     * Tells the map what location is currently
     * being visited.
     *
     * @param id
     */
    public string gotoLocationByID(int id)
    {
        lastID = currentLocation;

        currentLocation = id;

        string str = locations[currentLocation].ToString();
        return str;
    }

    public void gotoLocation(int id)
    {
        gotoLocationByID(id);
    }


    /**
     * Returns the current location.
     *
     * @return
     */
    public string getCurrentLocation()
    {
        string str = locations[currentLocation].ToString();
        return str;
    }

    /**
     * Returns the location itself by ID.
     *
     * @param id
     * @return
     */
    public string getLocation(int id)
    {
        string str = locations[locations.IndexOf(id)].ToString();
        return str;
    }

    /**
     * returns the last location visited.
     *
     * @return
     */
    public string getLastLocation()
    {
        string str = locations[locations.IndexOf(lastID)].ToString();
        return str;

    }

    public int getLastLocationID()
    {
        return lastID;
    }

    public int getTotal()
    {
        return locations.Count;
    }

    public void gotoLocationByName(string name)
    {
        gotoLocationByID(locations.IndexOf(name));
    }

    public int getCurrentLocationID()
    {
        return currentLocation;
    }


}
