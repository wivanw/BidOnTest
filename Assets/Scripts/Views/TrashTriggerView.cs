using UnityEngine;
using UnityEngine.Events;

namespace BidOn
{
    public class TrashTriggerView : MonoBehaviour
    {
        public UnityAction<TrashModel> TrashTriggerEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Const.Trash && TrashTriggerEvent != null)
            {
                var tash = other.GetComponent<TrashModel>();
                if (tash)
                    TrashTriggerEvent.Invoke(tash);
                else
                    Debug.LogError(Const.TrashError);
            }
        }

    }
}