using UnityEngine;
using UnityEngine.Events;

namespace BidOn
{
    public class TouchView : MonoBehaviour
    {
        public UnityAction<bool> IsTakeEvent;

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
    }
}