using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    [System.Serializable]
    public class TileInstantiator
    {
        static List<Vector2Int> pointList = new List<Vector2Int>();
        static GameObject obj;
        static Vector3Int position;
        static int i = 0;

        [SerializeField] Vector3Int tileOffset;

        public void Instantiate(HashSet<Vector2Int> pointSet, List<GameObject> tiles, Transform parent, int tileLength)
        {
            foreach (Vector2Int p in pointSet)
            {
                i = Random.Range(0, tiles.Count);

                position.x = (p.x + tileOffset.x) * tileLength;
                position.y = tileOffset.y;
                position.z = (p.y + tileOffset.z) * tileLength;

                obj = GameObject.Instantiate(tiles[i], position, Quaternion.identity);
                obj.transform.parent = parent;
            }           
        }
    }
}