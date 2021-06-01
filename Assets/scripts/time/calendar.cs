using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calendar : MonoBehaviour
{


    public int days;
    public int totalDays;

    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Update()
    {
        int i = getTotalDays() - getDays();
        string str = "Day:" + i + "/" + getTotalDays().ToString();
        Text.GetComponent<UnityEngine.UI.Text>().text = str;
    }


    /**
     * Returns the number of days left in the
     * calendar.
     *
     * @return
     */
    public int getDays()
    {
        return days;
    }

    /**
     * Sets the total number of days in the
     * calender.
     *
     * @param value
     */
    public void setDays(int value)
    {
        days = value;
    }

    /**
     * Returns the total number of days in the
     * calender.
     *
     * @return
     */
    public int getTotalDays()
    {
        return totalDays;
    }

    /**
     * Sets total Days
     *
     * @param value
     * @return
     */
    public void setTotalDays(int value)
    {
        totalDays = value;
    }

    /**
     * Checks to see if a day exists.
     *
     * @return
     */
    public bool hasNextDay()
    {
        return days < 1 ? false : true;
    }

    /**
     * Decreases the number of days by 1
     */
    public void nextDay()
    {
        days -= 1;
    }


    public string toString()
    {
        return "\"calendar\":" +
                "{\"days\":" + days + "," +
                "\"totalDays\":" + totalDays + "}";
    }
}
