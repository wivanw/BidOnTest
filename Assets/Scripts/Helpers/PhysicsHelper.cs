using UnityEngine;

namespace BidOn
{
    public class PhysicsHelper : Singleton<PhysicsHelper>
    {
        /// <summary>
        /// Initializes the required fields in the ConfigurableJoint for take-event garbage object.
        /// </summary>
        public ConfigurableJoint InitTakeJoint(ConfigurableJoint joint)
        {
            joint.xMotion = joint.yMotion = joint.zMotion = ConfigurableJointMotion.Limited;
            joint.enableCollision = true;
            joint.autoConfigureConnectedAnchor = false;
            return joint;
        }

        /// <summary>
        /// Makes balistic calculations of the flight of this Rigidbody to the current position.
        /// </summary>
        /// <param name="toPos">Position in space of flight Rigidbody</param>
        /// <returns>Finished velocity to assign to Rigidbody</returns>
        public Vector3 PassToPosition(Rigidbody rig, Vector3 toPos)
        {
            var position = rig.position;
            position.y = 0;
            var velocity = toPos - position;
            var magnitude = velocity.magnitude;
            velocity = velocity / magnitude;
            velocity *= rig.drag * magnitude / Mathf.Sqrt(rig.position.y / 9.81f);
            return velocity;
        }
    }
}