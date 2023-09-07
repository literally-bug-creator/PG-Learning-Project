using UnityEngine;
using UnityEngine.Events;

public class MovementEvents : MonoBehaviour
{
    public static UnityEvent<ushort> ChangeMovementInputMethodRequested = new UnityEvent<ushort>();
    public static UnityEvent<float> ChangeMovementSpeedRequested = new UnityEvent<float>();

    public static void SendChangeMovementInputMethodRequested(ushort methodID)
    {
        ChangeMovementInputMethodRequested.Invoke(methodID);
    }

    public static void SendChangeMovementSpeedRequested(float newSpeed)
    {
        ChangeMovementSpeedRequested.Invoke(newSpeed);
    }
}
