using UnityEngine;

public class EButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject _button;

    private void Awake()
    {
        _button.SetActive(false);

        UIEvents.EButtonRequested.AddListener(OnEButtonRequested);
    }

    private void OnEButtonRequested()
    {
        if (_button.activeSelf)
        {
            _button.SetActive(false);
            return;
        }

        _button.SetActive(true);
    }
}
