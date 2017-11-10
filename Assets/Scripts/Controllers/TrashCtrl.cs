using System;
using UnityEngine;

namespace BidOn
{
    public class TrashCtrl : MonoBehaviour
    {
        private TrashModel _model;

        private void Awake()
        {
            var view = GetComponent<TouchView>();
            view.IsTakeEvent += IsTake;
            view.MouseDragEvent += MouseDrag;

            _model = GetComponent<TrashModel>();
        }

        private void MouseDrag()
        {
            Controller.TouchManager.TrashDrag();
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