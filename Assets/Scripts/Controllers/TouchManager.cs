using UnityEngine;
using UnityEngine.Events;

namespace BidOn
{
    public class TouchManager : Singleton<TouchManager>
    {
        private int _trashLayer;
        private int _garbageTankLayer;
        private ConfigurableJoint _currentTrashJoint;
        [HideInInspector] public TrashModel CurrentTrash;
        [HideInInspector] public UnityAction<TrashModel> TakeTrashEvent;
        [HideInInspector] public UnityAction<TrashModel> DropTrashEvent;

        protected override void Awake()
        {
            base.Awake();
            _trashLayer = LayerMask.GetMask(Const.Trash);
            _garbageTankLayer = LayerMask.GetMask(Const.GarbageCan);
        }

        /// <summary>
        /// Accepts reports of the fact of taking garbage in hand.
        /// Attaches a physical joint to the garbage object to control the movement of garbage.
        /// </summary>
        /// <param name="trash"></param>
        public void TakeTrash(TrashModel trash)
        {
            Vector3 castPos;
            if (Helper.RayCast.ScreenMouseToRay(_trashLayer, out castPos))
            {
                CurrentTrash = trash;
                TakeTrashCall(CurrentTrash);
                _currentTrashJoint = Helper.Physics.InitTakeJoint(
                    CurrentTrash.gameObject.AddComponent<ConfigurableJoint>());
                _currentTrashJoint.anchor = CurrentTrash.Transform.InverseTransformPoint(castPos);
            }
        }

        /// <summary>
        /// Control of movement garbage in space following the input touch position.
        /// </summary>
        public void TrashDrag()
        {
            if (_currentTrashJoint)
            {
                _currentTrashJoint.connectedAnchor = Camera.main.ScreenToWorldPoint(
                    ClampMousePosition(Input.mousePosition)) + Camera.main.transform.forward * 0.5f;
            }
        }

        private Vector3 ClampMousePosition(Vector3 mousePosition)
        {
            mousePosition.x = Mathf.Clamp(mousePosition.x, 0.0f, Screen.width);
            mousePosition.y = Mathf.Clamp(mousePosition.y, 0.0f, Screen.height);
            return mousePosition;
        }

        /// <summary>
        /// Accepts reports of the fact of drop garbage out of hand.
        /// </summary>
        /// <param name="trash"></param>
        public void DropTrash(TrashModel trash)
        {
            if (trash == CurrentTrash)
            {
                Destroy(_currentTrashJoint);
                CurrentTrash = null;

                //check if the tuoch position is on garbage can
                RaycastHit hitInfo;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, _garbageTankLayer))
                {
                    var garbageCanModel = hitInfo.transform.GetComponentInParent<GarbageTankModel>();
                    //is there a GarbageTankModel component in the object? If is, is the garbage equals the trash can.
                    if (garbageCanModel && garbageCanModel.GarbageTankColor == trash.GarbageTankColor)
                    {
                        //throw garbage in the tank
                        trash.Rigidbody.velocity = Helper.Physics.PassToPosition(trash.Rigidbody,
                            garbageCanModel.CenterCast.position);
                    }
                    else
                        DropTrashCall(trash);
                }
                else
                    DropTrashCall(trash);
            }
            else
                Debug.LogError(Const.LogicError);
        }

        private void TakeTrashCall(TrashModel trashModel)
        {
            if (TakeTrashEvent != null)
                TakeTrashEvent.Invoke(trashModel);
        }

        private void DropTrashCall(TrashModel trashModel)
        {
            if (DropTrashEvent != null)
                DropTrashEvent.Invoke(trashModel);
        }
    }
}