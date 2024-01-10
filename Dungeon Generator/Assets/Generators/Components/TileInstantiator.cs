using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class TileInstantiator
    {
        static List<Vector2Int> pointList = new List<Vector2Int>();
        static GameObject obj;
        static Vector3Int position;
        static int i = 0;

        public void Instantiate(HashSet<Vector2Int> pointSet, List<GameObject> tiles, Transform parent, int tileLength, Vector3Int offset)
        {
            foreach (Vector2Int p in pointSet)
            {
                i = Random.Range(0, tiles.Count);

                position.x = (p.x + offset.x) * tileLength;
                position.y = offset.y;
                position.z = (p.y + offset.z) * tileLength;

                obj = GameObject.Instantiate(tiles[i], position, Quaternion.identity);
                obj.transform.parent = parent;
            }           
        }
    }
}