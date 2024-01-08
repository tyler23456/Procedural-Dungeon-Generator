using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GDA.Generators
{
    [System.Serializable]
    public class WallInstantiator
    {   
        static GameObject obj;
        static Vector3 position = Vector3.zero;
        static Quaternion rotation = Quaternion.identity;
        static int i = 0;

        static Vector2Int up = new Vector2Int(0, 1);
        static Vector2Int down = new Vector2Int(0, -1);
        static Vector2Int left = new Vector2Int(-1, 0);
        static Vector2Int right = new Vector2Int(1, 0);

        [SerializeField] Vector3Int forwardWallsOffset = new Vector3Int(-1, 0, 1);
        [SerializeField] Vector3Int backWallsOffset = new Vector3Int(0, 0, 0);
        [SerializeField] Vector3Int leftWallsOffset = new Vector3Int(-1, 0, 0);
        [SerializeField] Vector3Int rightWallsOffset = new Vector3Int(0, 0, 1);

        public void Instantiate(HashSet<Vector2Int> pointSet, HashSet<Vector2Int> floorSet, List<GameObject> walls, List<GameObject> wallProps, Transform parent, float tileLength)
        {
            foreach (Vector2Int p in pointSet)
            {
                if (!floorSet.Contains(p + up))
                {
                    position = (new Vector3(p.x, 0f, p.y) + forwardWallsOffset) * tileLength;
                    rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                    Instantiate(position, rotation, walls);
                    obj.transform.parent = parent;
                }
                if (!floorSet.Contains(p + down))
                {
                    position = (new Vector3(p.x, 0f, p.y) + backWallsOffset) * tileLength;
                    rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    Instantiate(position, rotation, walls);
                    obj.transform.parent = parent;
                }
                if (!floorSet.Contains(p + left))
                {
                    position = (new Vector3(p.x, 0f, p.y) + leftWallsOffset) * tileLength;
                    rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                    Instantiate(position, rotation, walls);
                    obj.transform.parent = parent;
                }
                if (!floorSet.Contains(p + right))
                {
                    position = (new Vector3(p.x, 0f, p.y) + rightWallsOffset) * tileLength;
                    rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
                    Instantiate(position, rotation, walls);
                    obj.transform.parent = parent;
                }
            }
        }

        void Instantiate(Vector3 position, Quaternion rotation, List<GameObject> walls)
        {
            i = Random.Range(0, walls.Count);
            obj = GameObject.Instantiate(walls[i], position, rotation);
        }
    }
}