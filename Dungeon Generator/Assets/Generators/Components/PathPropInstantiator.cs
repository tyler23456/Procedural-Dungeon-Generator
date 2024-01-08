using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class PathPropInstantiator
    {
        static GameObject obj;
        static float random;
        static int i;
        static Vector3 position = new Vector3();

        public void Instantiate(HashSet<Vector2Int> pointSet, HashSet<Vector2Int> corridor, List<GameObject> prefabs, List<Vector3> offsets)
        {
            if (prefabs == null || prefabs.Count == 0)
                return;

            HashSet<Vector2Int> pathSet = new HashSet<Vector2Int>(pointSet);
            pathSet.IntersectWith(corridor);

            foreach (Vector2Int p in pathSet)
            {
                random = Random.Range(0, prefabs.Count);
                i = Random.Range(0, prefabs.Count);

                position.x = p.x * 5f;
                position.y = 4f;
                position.z = p.y * 5f;

                obj = GameObject.Instantiate(prefabs[i], position + offsets[i], Quaternion.identity);

                obj.transform.position += obj.transform.forward * offsets[i].z;
                obj.transform.position += obj.transform.right * offsets[i].x;
                obj.transform.position += obj.transform.up * offsets[i].y;

                break; //temporary
            }     
        }
    }
}