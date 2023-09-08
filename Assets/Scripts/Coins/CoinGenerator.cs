using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform), typeof(SpriteRenderer))]
public class CoinGenerator : MonoBehaviour
{
    [SerializeField] [Range(1, 250)] private short _largeCoinAmount;
    [SerializeField] [Range(1, 250)] private short _smallCoinAmount;

    [SerializeField] private GameObject _largeCoinPrefab;
    [SerializeField] private GameObject _smallCoinPrefab;

    private Vector2 _generatorPosition = new Vector2();

    private int _halfX;
    private int _halfY;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        Transform generatorTransform = GetComponent<Transform>();

        _generatorPosition = new Vector2(generatorTransform.position.x,
            generatorTransform.position.y);

        _halfX = Mathf.FloorToInt(generatorTransform.localScale.x / 2);
        _halfY = Mathf.FloorToInt(generatorTransform.localScale.y / 2);
    }

    private void Start()
    {
        for (int largeCoinAmount = 0; largeCoinAmount < _largeCoinAmount; largeCoinAmount++)
        {
            Vector2 position = GetFreePosition();

            if (position.x == 0 && position.y == 0)
            {
                return;
            }

            Instantiate(_largeCoinPrefab, position, Quaternion.identity);
        }

        for (int smallCoinAmount = 0; smallCoinAmount < _smallCoinAmount; smallCoinAmount++)
        {
            Vector2 position = GetFreePosition();

            if (position.x == 0 && position.y == 0)
            {
                return;
            }

            Instantiate(_smallCoinPrefab, position, Quaternion.identity);
        }
    }

    private bool CheckPositionAvailability(Vector2 position)
    {
        Collider2D check = Physics2D.OverlapCircle(position, 1);

        if (check == null)
        {
            return true;
        }

        return false;
    }

    private List<Vector2> GetAllFreePositions()
    {
        List<Vector2> freePositions = new List<Vector2>();

        for (float xCoord = _generatorPosition.x - _halfX; xCoord <= _generatorPosition.x + _halfX; xCoord++)
        {
            for (float yCoord = _generatorPosition.y - _halfY; yCoord <= _generatorPosition.y + _halfY; yCoord++)
            {
                if (CheckPositionAvailability(new Vector2(xCoord, yCoord)))
                {
                    freePositions.Add(new Vector2(xCoord, yCoord));
                }
            }
        }

        return freePositions;
    }

    private Vector2 GetFreePosition()
    {
        List<Vector2> positions = GetAllFreePositions();

        if (positions == null || positions.Count == 0)
        {
            return Vector2.zero;
        }

        return positions[Random.Range(0, positions.Count)];
    }
}
