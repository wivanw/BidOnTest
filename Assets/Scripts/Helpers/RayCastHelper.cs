using UnityEngine;

namespace BidOn
{
    public class RayCastHelper : Singleton<RayCastHelper>
    {
        /// <summary>
        /// Send ray in current layer mask.
        /// </summary>
        /// <param name="layerMask">Layer mask</param>
        /// <param name="point">Container of ray hit result</param>
        /// <returns>Was it hit any object in the current layer</returns>
        public bool ScreenMouseToRay(int layerMask, out Vector3 point)
        {
            RaycastHit hitInfo;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                point = hitInfo.point;
                return true;
            }
            point = Vector3.zero;
            return false;
        }
    }
}