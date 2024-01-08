using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class DetailInstantiator
    {
        static Vector2Int up = new Vector2Int(0, 1);
        static Vector2Int down = new Vector2Int(0, -1);
        static Vector2Int left = new Vector2Int(-1, 0);
        static Vector2Int right = new Vector2Int(1, 0);

        static GameObject obj;
        static Vector3 position;
        static Quaternion rotation;
        static Vector3 offset;
        const float border = 0.9f;

        static int i = 0;

        public void Instantiate(HashSet<Vector2Int> pointSet, HashSet<Vector2Int> floorSet, List<GameObject> prefabs, List<Vector3> offsets)
        {
            if (prefabs == null || prefabs.Count == 0)
                return;

            foreach (Vector2Int p in pointSet)
            {
                if (!pointSet.Contains(p + up) && !pointSet.Contains(p + left))
                {
                    position = new Vector3((p.x - 1), 0f, (p.y + 1)) * 5f;
                    offset = (Vector3.back + Vector3.right) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, right);
                }
                else if (!pointSet.Contains(p + up) && !pointSet.Contains(p + right))
                {
                    position = new Vector3((p.x), 0f, (p.y + 1)) * 5f; //-1_1
                    offset = (Vector3.back + Vector3.left) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, down);
                }
                else if (!pointSet.Contains(p + down) && !pointSet.Contains(p + left))
                {
                    position = new Vector3((p.x - 1), 0f, (p.y)) * 5f;
                    offset = (Vector3.forward + Vector3.right) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, up);
                }
                else if (!pointSet.Contains(p + down) && !pointSet.Contains(p + right))
                {
                    position = new Vector3((p.x), 0f, (p.y)) * 5f;
                    offset = (Vector3.forward + Vector3.left) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, left);
                }
                else if (!pointSet.Contains(p + up))
                {
                    position = new Vector3((p.x - 1), 0f, (p.y + 1)) * 5f;
                    offset = (Vector3.back) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, right);
                }
                else if (!pointSet.Contains(p + down))
                {
                    position = new Vector3((p.x), 0f, (p.y)) * 5f;
                    offset = (Vector3.forward) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, left);
                }
                else if (!pointSet.Contains(p + left))
                {
                    position = new Vector3((p.x - 1), 0f, (p.y)) * 5f;
                    offset = (Vector3.right) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, up);
                }
                else if (!pointSet.Contains(p + right))
                {
                    position = new Vector3((p.x), 0f, (p.y + 1)) * 5f;
                    offset = (Vector3.left) * border;
                    rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
                    Instantiate(p, position + offset, rotation, prefabs, offsets, down);
                }
            }
        }

        void Instantiate(Vector2Int p, Vector3 position, Quaternion rotation, List<GameObject> prefabs, List<Vector3> offsets, Vector2Int carryover)
        {
            i = Random.Range(0, prefabs.Count);

            obj = GameObject.Instantiate(prefabs[i], position, rotation);

            obj.transform.position += obj.transform.forward * offsets[i].z;
            obj.transform.position += obj.transform.right * offsets[i].x;
            obj.transform.position += obj.transform.up * offsets[i].y;
        }
    }
}