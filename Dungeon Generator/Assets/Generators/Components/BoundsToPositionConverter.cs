using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GDA.Generators
{
    public class BoundsToPositionConverter
    {
        static HashSet<Vector2Int> roomSet = new HashSet<Vector2Int>();
        static BoundsInt bound;
        static List<HashSet<Vector2Int>> results;

        public List<HashSet<Vector2Int>> Generate(List<BoundsInt> rooms, int offset)
        {
            results = new List<HashSet<Vector2Int>>();
            foreach (BoundsInt room in rooms)
            {
                results.Add(new HashSet<Vector2Int>());
                foreach (Vector3Int p in room.allPositionsWithin)
                    results[results.Count - 1].Add(new Vector2Int(p.x, p.z));
            }
            return results;
        }
    }
}
