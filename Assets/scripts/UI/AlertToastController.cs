using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertToastController : MonoBehaviour
{

    public GameObject Toast;
    void Start()

    {
        Color currentColor = Color.clear;
        Toast.SetActive(false);
        textHolder.GetComponent<Text>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
    }


    public GameObject textHolder;



    public void CantBuy()
    {
        StartCoroutine(showToastCOR("Not Enough Money To buy", 2));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = textHolder.GetComponent<Text>().color;

        textHolder.GetComponent<Text>().text = text;
        textHolder.GetComponent<Text>().enabled = true;

        //Fade in
        Toast.SetActive(true);
        yield return fadeInAndOut(textHolder.GetComponent<Text>(), true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(textHolder.GetComponent<Text>(), false, 0.5f);
        Toast.SetActive(false);

        textHolder.GetComponent<Text>().enabled = false;
        textHolder.GetComponent<Text>().color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }

}
