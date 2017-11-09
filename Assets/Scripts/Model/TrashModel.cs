using UnityEngine;

namespace BidOn
{
    public class TrashModel : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        public Transform Transform { get; private set; }
        public GarbageTankColor GarbageTankColor;
        [HideInInspector] public bool IsInGarbageCan;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();
        }
    }
}