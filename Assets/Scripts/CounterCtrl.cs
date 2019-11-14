using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CounterCtrl : MonoBehaviour
{
    [SerializeField]
    private long counter = 0;

    [SerializeField]
    private long tenBillionTarget = 10000000000;

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

    public long Counter { get => counter; set => counter = value; }

    public void CountUp(long count)
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

    public void CountDown(long count)
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
        scoreText.text = Counter.ToString();
        
    }
}
