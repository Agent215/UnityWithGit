using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    
    float getMinPrice();

    void setMinPrice(float value);

    float getMaxPrice();

    void setMaxPrice(float value);

    float getPrice();

    void setPrice(float value);

    string getName();

    string getDescription();

    void setDescription(string value);

    void generateNewPrice();

    int getTotal();

    void setTotal(int value);

    bool isActive();

    void setActive(bool visible);
} 

