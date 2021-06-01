using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour
{

    public bool sellPOSactive;
    public bool buyPOSactive;
    // Start is called before the first frame update


    public bool getSellPOSactive()
    {

        return this.sellPOSactive;
    }

    public void setSellPOSactive(bool flag)
    {

        this.sellPOSactive = flag;
    }
    public bool getBuyPOSactive()
    {

        return this.buyPOSactive;
    }
    public void setBuyPOSactive(bool flag)
    {

        this.buyPOSactive = flag;
    }
    void Start()
    {
        sellPOSactive = false;
        buyPOSactive = false;
    }

    // Update is called once per frame


}
