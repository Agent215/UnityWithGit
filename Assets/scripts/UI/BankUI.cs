using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BankUI : MonoBehaviour

{

    public GameObject LoanText;
    public GameObject SavingsText;

    public GameObject bankMenu;  // chose what bank action modal

    public GameObject bankModal; // parent object
    private GameObject depositMenu;
    private GameObject withdrawMenu;
    private GameObject loanMenu;
    public Slider depositSlider;
    public Slider withdrawSlider;
    private GameObject TakeLoanButton;
    private GameObject PayLoanButton;


    public Slider loanSlider;




    private bool bankModalIsActive;
    private bool depositMenuIsActive;
    private bool withdrawMenuIsActive;

    private bool loanMenuIsActive;


    private GameObject GameControllerObject;
    public GameObject CashText;

    // Start is called before the first frame update
    void Start()
    {
        bankModalIsActive = false;
        // get all gameobjects
        var gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // set correct POS for this item to use
        // we are using buy pos
        foreach (GameObject gmo in gameObjects)
        {
            if (gmo.name == "BankModal")
            {
                this.bankModal = gmo;
            }

            if (gmo.name == "BankMenu")
            {
                this.bankMenu = gmo;
            }
            if (gmo.name == "DepositMenu")
            {
                this.depositMenu = gmo;
            }
            if (gmo.name == "WithdrawMenu")
            {
                this.withdrawMenu = gmo;
            }

            if (gmo.name == "LoanMenu")
            {
                this.loanMenu = gmo;
            }

            if (gmo.name == "DepositSlider")
            {
                this.depositSlider = gmo.GetComponent<Slider>();
            }

            if (gmo.name == "WithdrawSlider")
            {
                this.withdrawSlider = gmo.GetComponent<Slider>();
            }

            if (gmo.name == "LoanSlider")
            {
                this.loanSlider = gmo.GetComponent<Slider>();
            }

            if (gmo.name == "TakeLoanButton")
            {
                this.TakeLoanButton = gmo;
            }
            if (gmo.name == "PayLoanButton")
            {
                this.PayLoanButton = gmo;
            }

        }

        GameControllerObject = GameObject.Find("GameController");
        withdrawSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        depositSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        loanSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        LoanText.GetComponent<UnityEngine.UI.Text>().text ="Debt:  <color=#E52121>$" + GameControllerObject.GetComponent<Bank>().getLoan().ToString() +"</color>";
        SavingsText.GetComponent<UnityEngine.UI.Text>().text = "Savings: $" + GameControllerObject.GetComponent<Bank>().getSavings().ToString();

    }


    public void ValueChangeCheck()
    {

        if (depositMenuIsActive)
        {
            Debug.Log(depositSlider.value);
            GameObject.Find("Amount").GetComponent<Text>().text = depositSlider.value.ToString();
        }

        if (withdrawMenuIsActive)
        {

            Debug.Log(withdrawSlider.value);
            GameObject.Find("Amount").GetComponent<Text>().text = withdrawSlider.value.ToString();
        }

        if (loanMenuIsActive)
        {

            Debug.Log(loanSlider.value);
            GameObject.Find("Amount").GetComponent<Text>().text = loanSlider.value.ToString();
        }

    }



    public void close()
    {
        if (bankModalIsActive)
        {
            bankModalIsActive = false;
            bankModal.SetActive(false);
        }

        if (depositMenuIsActive)
        {
            depositMenu.SetActive(false);
            depositMenuIsActive = false;
        }

        if (withdrawMenuIsActive)
        {

            withdrawMenu.SetActive(false);
            withdrawMenuIsActive = false;
        }

        if (loanMenuIsActive)
        {

            loanMenu.SetActive(false);
            loanMenuIsActive = false;
        }

        // this must be active for next time we access it
        bankMenu.SetActive(true);

    }

    public void closeBankMenu()
    {

        bankMenu.SetActive(false);
    }


    public void open()
    {

        bankModalIsActive = true;
        bankModal.SetActive(true);
    }


    public void openDepositModal()
    {

        //get current cash amount
        float possilbeAmountToDesposit = GameObject.Find("wallet").GetComponent<Wallet>().getCash();
        // set slider and deposit amount text to be possibleAmountToDeposit
        closeBankMenu();
        depositMenu.SetActive(true);
        depositMenuIsActive = true;
        depositSlider.maxValue = possilbeAmountToDesposit;
        depositSlider.value = possilbeAmountToDesposit;
        GameObject.Find("Amount").GetComponent<Text>().text = "$" + possilbeAmountToDesposit;
    }


    public void openWithdrawModal()
    {

        //get current savings amount
        float possilbeAmountToWithdraw = (float)GameControllerObject.GetComponent<Bank>().getSavings();
        // set slider and withdaw amount text to be possibleAmountToDeposit
        closeBankMenu();
        withdrawMenu.SetActive(true);
        withdrawMenuIsActive = true;
        withdrawSlider.maxValue = possilbeAmountToWithdraw;
        withdrawSlider.value = possilbeAmountToWithdraw;
        GameObject.Find("Amount").GetComponent<Text>().text = "$" + possilbeAmountToWithdraw;
    }

    public void onDeposit()
    {
        Debug.Log("depositing  " + depositSlider.value);
        GameControllerObject.GetComponent<Bank>().deposit(depositSlider.value);
        SavingsText.GetComponent<UnityEngine.UI.Text>().text = "Savings: $" + GameControllerObject.GetComponent<Bank>().getSavings().ToString();
    }

    public void onWithdraw()
    {
        Debug.Log("withdrawing  " + withdrawSlider.value);
        GameControllerObject.GetComponent<Bank>().withdraw(withdrawSlider.value);
        SavingsText.GetComponent<UnityEngine.UI.Text>().text = "Savings: $" + GameControllerObject.GetComponent<Bank>().getSavings().ToString();

    }
    public void takeLoan()
    {

        float loanValue = loanSlider.value;
        Debug.Log("taking out loan  " + loanValue);
        GameControllerObject.GetComponent<Bank>().takeOutLoan(loanValue);
        LoanText.GetComponent<UnityEngine.UI.Text>().text = "Debt:  <color=#E52121>$" + GameControllerObject.GetComponent<Bank>().getLoan().ToString() +"</color>";



    }
    public void payDownLoan()
    {

        float loanValue = loanSlider.value;
        Debug.Log("paying down loan  " + loanValue);
        GameControllerObject.GetComponent<Bank>().payOffLoan(loanValue);
        LoanText.GetComponent<UnityEngine.UI.Text>().text = "Debt:  <color=#E52121>$" + GameControllerObject.GetComponent<Bank>().getLoan().ToString() +"</color>";

    }


    public void openLoanModal()
    {

        loanMenu.SetActive(true);
        loanMenuIsActive = true;

        float loanValue = (float)GameControllerObject.GetComponent<Bank>().getLoan();
        int cash = (int)GameObject.Find("wallet").GetComponent<Wallet>().getCash();
        // check if we have loan already
        if (loanValue > 0) // if we do..
        {
            PayLoanButton.SetActive(true);
            TakeLoanButton.SetActive(false);
            Debug.Log("opening pay down loan modal with loan value " + loanValue);
            loanSlider.maxValue = loanValue;
            // if we can pay off the loan
            if (cash > loanValue)
            {
                loanSlider.maxValue = loanValue;
                loanSlider.value = loanValue;
                GameObject.Find("LoanAmountTitle").GetComponent<Text>().text = "Pay Off Loan";
                GameObject.Find("Amount").GetComponent<Text>().text = "$" + loanSlider.value;
            }
            else
            {
                // we can only pay some of the loan
                loanSlider.maxValue = loanValue;
                loanSlider.value = cash;
                GameObject.Find("LoanAmountTitle").GetComponent<Text>().text = "Pay Off Loan";
                GameObject.Find("Amount").GetComponent<Text>().text = "$" + cash;
            }
        }
        else
        {
            //if we dont have a loan set takeLoanUI
            //  set payDownLoanUI set amount to 1000 out of 10000
            PayLoanButton.SetActive(false);
            TakeLoanButton.SetActive(true);
            loanSlider.maxValue = 10000;
            loanSlider.value = 1000;
            GameObject.Find("LoanAmountTitle").GetComponent<Text>().text = "Take Out Loan";
            GameObject.Find("Amount").GetComponent<Text>().text = "$" + loanSlider.value;
        }

    }


    public void nextBankDay()
    {

        GameControllerObject.GetComponent<Bank>().nextDay(GameControllerObject.GetComponent<calendar>().getDays(), GameControllerObject.GetComponent<calendar>().getTotalDays());
        LoanText.GetComponent<UnityEngine.UI.Text>().text = "Debt:  <color=#E52121>$" + GameControllerObject.GetComponent<Bank>().getLoan().ToString() +"</color>";
        SavingsText.GetComponent<UnityEngine.UI.Text>().text = "Savings: $" + GameControllerObject.GetComponent<Bank>().getSavings().ToString();
    }


}
