using UnityEngine;
using System;

namespace BidOn
{
    public class WindowResizeCtrl : MonoBehaviour
    {
        public static event Action<Vector2> WindowResizeEvent;
        private int _height;
        private int _width;

        private void Awake()
        {
            SetScreenParams();
        }

        private void Start()
        {
            WindowResizeEvent(new Vector2(Screen.width, Screen.height));
            SetScreenParams();
        }

        private void Update()
        {
            if (_width == Screen.width && _height == Screen.height || WindowResizeEvent == null)
                return;

            WindowResizeEvent(new Vector2(Screen.width, Screen.height));
            SetScreenParams();
        }

        private void SetScreenParams()
        {
            _height = Screen.height;
            _width = Screen.width;
        }
    }
}