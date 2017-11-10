using UnityEngine;
using UnityEngine.Events;

namespace BidOn
{
    public class TouchView : MonoBehaviour
    {
        public UnityAction<bool> IsTakeEvent;
        public UnityAction MouseDragEvent;

        private void OnMouseDown()
        {
            if (IsTakeEvent != null)
                IsTakeEvent.Invoke(true);
        }

        private void OnMouseUp()
        {
            if (IsTakeEvent != null)
                IsTakeEvent.Invoke(false);
        }

        private void OnMouseDrag()
        {
            MouseDragEvent.Invoke();
        }
    }
}