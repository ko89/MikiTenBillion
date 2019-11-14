using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CounterCtrl : MonoBehaviour
{
    [SerializeField]
    private int counter = 0;

    [SerializeField]
    private int tenBillionTarget = 1000000000;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private UnityEvent countUpEvent;

    [SerializeField]
    private UnityEvent countDownEvent;

    [SerializeField]
    private UnityEvent counterResetEvent;

    [SerializeField]
    private UnityEvent tenBillionEvent;

    public int Counter { get => counter; set => counter = value; }

    public void CountUp(int count)
    {
        Counter += count;
        if(Counter >= tenBillionTarget)
        {
            tenBillionEvent.Invoke();
        }
        else
        {
            countUpEvent.Invoke();
        }
        UpdateScoreText();
    }

    public void CountUpOne()
    {
        Counter++;
        if (Counter >= tenBillionTarget)
        {
            tenBillionEvent.Invoke();
        }
        else
        {
            countUpEvent.Invoke();
        }
        UpdateScoreText();
    }

    public void CountDown(int count)
    {
        Counter -= count;
        if(Counter < 0)
        {
            ResetCounter();
        }
        countDownEvent.Invoke();
        UpdateScoreText();
    }

    public void ResetCounter()
    {
        Counter = 0;
        counterResetEvent.Invoke();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (Counter > 0)
        {
            scoreText.text = Counter.ToString() + "9";
        }
        else
        {
            scoreText.text = Counter.ToString();
        }

        
    }
}
