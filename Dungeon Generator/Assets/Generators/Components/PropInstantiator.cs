using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class PropInstantiator
    {
        static GameObject obj;
        static Vector3 position = Vector3.zero;
        static Quaternion rotation = Quaternion.identity;
        static GameObject prop;
        static Collider collider;
        static Collider[] colliders;

        static Vector2Int up = new Vector2Int(0, 2);
        static Vector2Int down = new Vector2Int(0, -2);
        static Vector2Int left = new Vector2Int(-2, 0);
        static Vector2Int right = new Vector2Int(2, 0);
        const float border = 0.9f;
        static Vector3 offset = Vector3.zero;
        static Vector3 pOffset = Vector3.zero;
        static Vector3 rOffset = Vector3.zero;

        public void Instantiate(HashSet<Vector2Int> pointSet, HashSet<Vector2Int> floorSet, List<GameObject> props, Vector3 pOffset)
        {
            PropInstantiator.pOffset = pOffset;            
        }

        public void Instantiate(Vector3 position, Quaternion rotation, List<GameObject> props)
        {
            foreach (GameObject prop in props)
            {
                obj = GameObject.Instantiate(prop, position, rotation);

                obj.transform.position += obj.transform.forward * pOffset.z;
                obj.transform.position += obj.transform.right * pOffset.x;
                obj.transform.position += obj.transform.up * pOffset.y;

                collider = obj.GetComponent<Collider>();
                colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents * 1.1f, Quaternion.identity, 1 << LayerMask.NameToLayer("Prop"));
            }
        }
    }
}