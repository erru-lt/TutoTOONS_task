using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class Point : MonoBehaviour
    {
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                ChangeSprite();
            }
        }
        private bool _isActive = true;

        [SerializeField] private Sprite _activeSprite;
        [SerializeField] private Sprite _inactiveSprite;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _number;

        public void SetNumber(int number) => 
            _number.SetText(number.ToString());

        public void HideNumber() => 
            StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while(_number.alpha > 0)
            {
                _number.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
        }

        private void ChangeSprite() => 
            _image.sprite = _isActive ? _activeSprite : _inactiveSprite;
    }
}
