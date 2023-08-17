using System;
using System.Collections;
using UnityEngine;

namespace Assets.Code
{
    public class PointLine : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        private Vector3 _startPosition;
        private readonly int _startPositionIndex = 0;
        private readonly int _endPositionIndex = 1;

        private void Start() => 
            SetValues();

        public void AnimateLine(Vector3 endPosition, Action onDrawEnd = null) =>
            StartCoroutine(DrawLine(endPosition, onDrawEnd));

        private IEnumerator DrawLine(Vector3 endPosition, Action onDrawEnd = null)
        {
            _lineRenderer.enabled = true;

            Vector3 startPosition = _lineRenderer.GetPosition(_startPositionIndex);

            float distance = Vector3.Distance(startPosition, endPosition);
            float speed = 10.0f;
            float time = distance / speed;
            float elapsedTime = 0f;

            while (elapsedTime < time)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / time;
                _lineRenderer.SetPosition(1, Vector3.Lerp(startPosition, endPosition, t));
                yield return null;
            }

            _lineRenderer.SetPosition(_endPositionIndex, endPosition);
            onDrawEnd?.Invoke();
        }

        private void SetValues()
        {
            _startPosition = transform.position;
            _lineRenderer.enabled = false;
            _lineRenderer.SetPosition(_startPositionIndex, _startPosition);
        }
    }
}
