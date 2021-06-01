using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{

    private int DEPOSIT = 0;
    private int WITHDRAW = 1;
    private int REPAY_LOAN = 2;
    private int GET_LOAN = 3;


    public GameObject wallet;
    public float savings = 0;
    public float interest;
    public float loan = 0;
    private bool round = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    /**
     * Returns the total amount of savings in the bank.
     *
     * @return
     */
    public double getSavings()
    {
        return savings;
    }

    /**
     * Returns the total amount of the load in the bank.
     *
     * @return
     */
    public double getLoan()
    {
        return loan;
    }

    /**
     * Returns the interest used for the load.
     *
     * @return
     */
    public double getInterest()
    {
        return interest;
    }


    /**
     * Calculates the interest on the loan.
     *
     * @param currentDay
     * @param totalDays
     */
    public void nextDay(float currentDay, float totalDays)
    {
        if (loan != 0)
        {
            double interest = calculateInterest(this.interest, totalDays, loan, currentDay);
            loan += (float)interest;
        }
    }

    /**
     * Pays off the loan. Returns the remainder if over.
     *
     * @param value
     * @return
     */
    public float payOffLoan(float value)
    {
        loan -= value;
        wallet.GetComponent<Wallet>().subtractCash(value);

        float remainder = 0;

        if (loan < 0)
        {
            remainder = loan * -1;
            loan = 0;
        }

        return remainder;

    }

    /**
     * takes money out of savings.
     *
     * @param value
     * @return
     */
    public float withdrawFromSavings(float value)
    {
        if (value > savings)
        {
            value = savings;
            savings = 0;
        }
        else
        {
            savings -= value;
        }

        return value;
    }

    /**
     * Increases the loan amount and your cash.
     *
     * @param value
     */
    public void takeOutLoan(float value)
    {
        loan += value;
        wallet.GetComponent<Wallet>().addCash(value);
    }

    protected float calculateInterest(float interest, float totalTime, float balance, float timeElapsed)
    {
        float value = ((interest / totalTime) * balance) * timeElapsed;

        return round ? Mathf.Round(value) : value;
    }

    public void setInterest(float value)
    {
        interest = value;
    }

    public void setSavings(float value)
    {
        savings = value;
    }

    public void setLoan(float value)
    {
        loan = value;
    }

    /**
     * Adds money to your savings account from your cash
     *
     * @param value
     */
    public void deposit(float value)
    {
        //TODO need logic to make sure you can't deposit more then you have in cash
        wallet.GetComponent<Wallet>().subtractCash(value);
        Debug.Log("subtracting" + value);
        savings += value;
    }

    public void withdraw(float value)
    {
        wallet.GetComponent<Wallet>().addCash(withdrawFromSavings(value));
    }

    public void replayLoan(float value)
    {
        //TODO need logic to make sure you can't replay more then you have or owe
        wallet.GetComponent<Wallet>().subtractCash(value);
        payOffLoan(value);
    }



    public void setRound(bool value)
    {
        this.round = value;
    }

}
