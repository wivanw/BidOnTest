using UnityEngine;
using UnityEngine.Events;

namespace BidOn
{
    public class GarbageTankCtrl : MonoBehaviour
    {
        private GarbageTankModel _model;
        public UnityAction<GarbageTankModel> AddTrashEvent;

        private void Awake()
        {
            _model = GetComponent<GarbageTankModel>();
            GetComponentInChildren<TrashTriggerView>().TrashTriggerEvent += TrashTrigger;
            Controller.TouchManager.TakeTrashEvent += TakeTrash;
            Controller.TouchManager.DropTrashEvent += DropTrash;
        }

        /// <summary>
        /// It works when the garbage touches the garbage tank inside.
        /// Starts the closing animation garbage tank.
        /// Increases the amount of garbage count.
        /// </summary>
        /// <param name="trash">Garbage model</param>
        private void TrashTrigger(TrashModel trash)
        {
            if (!Controller.TouchManager.CurrentTrash)
            {
                _model.Animator.SetBool(Const.IsOpen, false);
                if (!trash.IsInGarbageCan)
                {
                    _model.AddTrash();
                    AddTrashEvent.Invoke(_model);
                }
                trash.IsInGarbageCan = true;
            }
        }

        /// <summary>
        /// It works when the trash take in hand.
        /// Starts the opening/closing animation garbage tank.
        /// </summary>
        /// <param name="trashModel">Garbage model</param>
        private void TakeTrash(TrashModel trashModel)
        {
            if (trashModel.GarbageTankColor == _model.GarbageTankColor)
            {
                if (!_model.IsTrashFull)
                    _model.Animator.SetBool(Const.IsOpen, true);
            }
            else
                _model.Animator.SetBool(Const.IsOpen, false);
        }

        /// <summary>
        /// It works when the garbage drop out of hand.
        /// Starts the closing animation garbage tank.
        /// </summary>
        /// <param name="trashModel">Garbage model</param>
        private void DropTrash(TrashModel trashModel)
        {
            _model.Animator.SetBool(Const.IsOpen, false);
        }
    }
}