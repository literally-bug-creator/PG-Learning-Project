using UnityEditor.PackageManager;
using UnityEngine;

public class LargeCoin : MonoBehaviour
{
    [SerializeField] private CoinType _type;
    [SerializeField] [Range(1f, 50f)] private float _awardAmount;

    private bool _isInsideTrigger;

    private void Awake()
    {
        CoinEvents.OnCoinGrabRequested.AddListener(OnCoinGrabRequested);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isInsideTrigger = false;
        }
    }

    private void OnCoinGrabRequested()
    {
        if (_isInsideTrigger)
        {
            Destroy(this.gameObject);
            //Score Logic should be here...
            Debug.Log($"Player grabed {_type}");
        }
    }
}
