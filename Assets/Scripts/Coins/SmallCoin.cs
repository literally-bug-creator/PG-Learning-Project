using UnityEngine;

public class SmallCoin : MonoBehaviour
{
    [SerializeField] private CoinType _type;
    [SerializeField] [Range(1f, 50f)] private float _awardAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnCoinGrabRequested();
        }
    }

    private void OnCoinGrabRequested()
    {
        Destroy(this.gameObject);
        //Score Logic should be here...
        Debug.Log($"Player grabed {_type}");
    }
}
