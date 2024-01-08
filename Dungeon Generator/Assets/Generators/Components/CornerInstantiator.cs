using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class CornerInstantiator
    {
        static GameObject obj;
        static Vector3 position = Vector3.zero;
        static Quaternion rotation = Quaternion.identity;

        public void Instantiate(HashSet<Vector2Int> room, HashSet<Vector2Int> floorSet, GameObject corner, Transform parent, float tileLength)
        {
            foreach (Vector2Int p in room)
            {
                Instantiate(p, floorSet, corner, parent, tileLength);
            }
        }

        void Instantiate(Vector2Int p, HashSet<Vector2Int> floorSet, GameObject corner, Transform parent, float tileLength)
        {
            if (!floorSet.Contains(p + Vector2Int.up) && !floorSet.Contains(p + Vector2Int.left)
                || floorSet.Contains(p + Vector2Int.up) && floorSet.Contains(p + Vector2Int.left) && !floorSet.Contains(p + Vector2Int.up + Vector2Int.left))
            {
                position = new Vector3((p.x - 1), 0f, (p.y + 1)) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;

            }
            if (!floorSet.Contains(p + Vector2Int.up) && !floorSet.Contains(p + Vector2Int.right)
                || floorSet.Contains(p + Vector2Int.up) && floorSet.Contains(p + Vector2Int.right) && !floorSet.Contains(p + Vector2Int.up + Vector2Int.right))
            {
                position = new Vector3((p.x), 0f, (p.y + 1)) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
            }
            if (!floorSet.Contains(p + Vector2Int.down) && !floorSet.Contains(p + Vector2Int.left)
                || floorSet.Contains(p + Vector2Int.down) && floorSet.Contains(p + Vector2Int.left) && !floorSet.Contains(p + Vector2Int.down + Vector2Int.left))
            {
                position = new Vector3((p.x - 1), 0f, (p.y)) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
            }
            if (!floorSet.Contains(p + Vector2Int.down) && !floorSet.Contains(p + Vector2Int.right)
                || floorSet.Contains(p + Vector2Int.down) && floorSet.Contains(p + Vector2Int.right) && !floorSet.Contains(p + Vector2Int.down + Vector2Int.right))
            {
                position = new Vector3((p.x), 0f, (p.y)) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
            }      
        }
    }
}