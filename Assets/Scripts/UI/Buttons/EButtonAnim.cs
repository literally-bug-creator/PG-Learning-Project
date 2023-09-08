using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class EButtonAnim : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;

    [SerializeField] private Vector2 _endPosition;

    [SerializeField] private RectTransform _buttonTransform;

    private void OnEnable()
    {
        _buttonTransform = GetComponent<RectTransform>();

        _startPosition = _buttonTransform.position;
        _endPosition = new Vector3(_buttonTransform.position.x, _buttonTransform.position.y - 4.75f, _buttonTransform.position.z);

        StartCoroutine(AnimateButtonPress());
    }

    private IEnumerator AnimateButtonPress()
    {
        _buttonTransform.position -= new Vector3(0, 0.2f, 0);

        if (_buttonTransform.position.y > _endPosition.y)
        {
            yield return new WaitForSeconds(0.025f);
            StartCoroutine(AnimateButtonPress());
        }

        else
        {
            _buttonTransform.position.Set(_buttonTransform.position.x, _endPosition.y, 0);
            StartCoroutine(AnimateButtonUnpress());
        }
    }

    private IEnumerator AnimateButtonUnpress()
    {
        _buttonTransform.position += new Vector3(0, 0.2f, 0);

        if (_buttonTransform.position.y < _startPosition.y)
        {
            yield return new WaitForSeconds(0.025f);
            StartCoroutine(AnimateButtonUnpress());
        }

        else
        {
            _buttonTransform.position.Set(_buttonTransform.position.x, _startPosition.y, 0);
            StartCoroutine(AnimateButtonPress());
        }
    }
}
