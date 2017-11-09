using UnityEngine;

namespace BidOn
{
    public class GarbageTankModel : MonoBehaviour
    {
        //The point at which the garbage will be thrown
        public Transform CenterCast;
        //Type of garbage tank
        public GarbageTankColor GarbageTankColor;
        public Animator Animator { get; private set; }
        //Count of garbage in the tank
        public int TrashCount { get; private set; }
        //Is all the debris inside the tank
        public bool IsTrashFull { get { return TrashCount >= MaxTrashCount; } }
        //Total count of garbage of the corresponding type
        [HideInInspector] public int MaxTrashCount;
        [HideInInspector] public Transform Transform;

        private void Awake()
        {
            Animator = GetComponentInChildren<Animator>();
            Transform = GetComponent<Transform>();
        }

        /// <summary>
        /// Adds one garbage unit to the tank
        /// </summary>
        public void AddTrash()
        {
            TrashCount++;
        }
    }
}