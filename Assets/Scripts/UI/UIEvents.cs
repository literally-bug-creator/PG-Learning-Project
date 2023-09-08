using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    public static UnityEvent<ushort> ButtonChangeStateRequested = new UnityEvent<ushort>();

    public static void SendEButtonRequested(ushort buttonID)
    {
        ButtonChangeStateRequested.Invoke(buttonID);
    }
}
