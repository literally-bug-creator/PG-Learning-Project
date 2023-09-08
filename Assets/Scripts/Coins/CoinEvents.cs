using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinEvents
{
    public static UnityEvent OnCoinGrabRequested = new UnityEvent();

    public static void SendOnCoinGrabRequested()
    {
        OnCoinGrabRequested.Invoke();
    }
}
