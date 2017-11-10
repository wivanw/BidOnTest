using UnityEngine;

namespace BidOn
{
    public class BorderCtrl : MonoBehaviour
    {
        public Transform BorderLeft;
        public Transform BorderRight;
        private float _cameraSize;

        private void Awake()
        {
            WindowResizeCtrl.WindowResizeEvent += WindowResize;
            _cameraSize = Camera.main.orthographicSize;

        }

        private void WindowResize(Vector2 vector2)
        {
            var screenSizeCoef = vector2.x / vector2.y;
            var shiftBorder = screenSizeCoef * _cameraSize + 0.5f;
            Debug.Log(shiftBorder);
            BorderLeft.localPosition = new Vector3(-shiftBorder, BorderLeft.localPosition.y, BorderLeft.localPosition.z);
            BorderRight.localPosition = new Vector3(shiftBorder, BorderLeft.localPosition.y, BorderLeft.localPosition.z);
        }
    }
}