using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    [System.Serializable]
    public class CornerInstantiator
    {
        static GameObject obj;
        static Vector3 position = Vector3.zero;
        static Quaternion rotation = Quaternion.identity;

        [SerializeField] Vector3Int forwardLeftCornersOffset = new Vector3Int(-1, 0, 1);
        [SerializeField] Vector3Int forwardRightCornersOffset = new Vector3Int(0, 0, 1);
        [SerializeField] Vector3Int backLeftCornersOffset = new Vector3Int(-1, 0, 0);
        [SerializeField] Vector3Int backRightCornersOffset = new Vector3Int(0, 0, 0);

        public void Instantiate(HashSet<Vector2Int> room, HashSet<Vector2Int> floorSet, HashSet<Vector2Int> cornerSet, GameObject corner, Transform parent, float tileLength)
        {
            foreach (Vector2Int p in room)
            {
                Instantiate(p, floorSet, cornerSet, corner, parent, tileLength);
            }
        }

        void Instantiate(Vector2Int p, HashSet<Vector2Int> floorSet, HashSet<Vector2Int> cornerSet, GameObject corner, Transform parent, float tileLength)
        {
            if (!floorSet.Contains(p + Vector2Int.up) && !floorSet.Contains(p + Vector2Int.left)
                || floorSet.Contains(p + Vector2Int.up) && floorSet.Contains(p + Vector2Int.left) && !floorSet.Contains(p + Vector2Int.up + Vector2Int.left))
            {
                position = (new Vector3(p.x, 0f, p.y) + forwardLeftCornersOffset) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
                cornerSet.Add(p);
            }
            if (!floorSet.Contains(p + Vector2Int.up) && !floorSet.Contains(p + Vector2Int.right)
                || floorSet.Contains(p + Vector2Int.up) && floorSet.Contains(p + Vector2Int.right) && !floorSet.Contains(p + Vector2Int.up + Vector2Int.right))
            {
                position = (new Vector3(p.x, 0f, p.y) + forwardRightCornersOffset) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
                cornerSet.Add(p);
            }
            if (!floorSet.Contains(p + Vector2Int.down) && !floorSet.Contains(p + Vector2Int.left)
                || floorSet.Contains(p + Vector2Int.down) && floorSet.Contains(p + Vector2Int.left) && !floorSet.Contains(p + Vector2Int.down + Vector2Int.left))
            {
                position = (new Vector3(p.x, 0f, p.y) + backLeftCornersOffset) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
                cornerSet.Add(p);
            }
            if (!floorSet.Contains(p + Vector2Int.down) && !floorSet.Contains(p + Vector2Int.right)
                || floorSet.Contains(p + Vector2Int.down) && floorSet.Contains(p + Vector2Int.right) && !floorSet.Contains(p + Vector2Int.down + Vector2Int.right))
            {
                position = (new Vector3(p.x, 0f, p.y) + backRightCornersOffset) * tileLength;
                rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                obj = GameObject.Instantiate(corner, position, rotation, null);
                obj.transform.parent = parent;
                cornerSet.Add(p);
            }      
        }
    }
}