using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private ushort _buttonID;

    private void Awake()
    {
        _button.SetActive(false);

        UIEvents.ButtonChangeStateRequested.AddListener(OnButtonChangeStateRequested);
    }

    private void OnButtonChangeStateRequested(ushort buttonID)
    {   
        if (_buttonID != buttonID)
        {
            return;
        }

        if (_button.activeSelf)
        {
            _button.SetActive(false);
            return;
        }

        _button.SetActive(true);
    }
}
