using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    public static UnityEvent EButtonRequested = new UnityEvent();

    public static void SendEButtonRequested()
    {
        EButtonRequested.Invoke();
    }
}
