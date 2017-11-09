using UnityEngine;

namespace BidOn
{
    public class TrashCtrl : MonoBehaviour
    {
        private TrashModel _model;

        private void Awake()
        {
            GetComponent<TouchView>().IsTakeEvent += IsTake;
            _model = GetComponent<TrashModel>();
        }

        /// <summary>
        /// Sends an reports of taking/throwing garbage out of hand in TouchManager.
        /// </summary>
        /// <param name="isTake"></param>
        private void IsTake(bool isTake)
        {
            if (isTake)
                Controller.TouchManager.TakeTrash(_model);
            else
                Controller.TouchManager.DropTrash(_model);
        }
    }
}