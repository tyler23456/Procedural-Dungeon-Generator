using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GDA.Generators
{
    public class CorridorGenerator
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        HashSet<Vector2Int> roomCenters = new HashSet<Vector2Int>();

        public HashSet<Vector2Int> Generate(List<BoundsInt> rooms)
        {
            corridors.Clear();

            foreach (BoundsInt room in rooms)
            {
                int x = (int)room.center.x;
                int y = (int)room.center.z;

                roomCenters.Add(new Vector2Int(x, y));
            }

            Vector2Int current = roomCenters.ToList()[Random.Range(0, roomCenters.Count)];
            roomCenters.Remove(current);

            while (roomCenters.Count > 0)
            {
                Vector2Int closest = roomCenters.OrderBy(i => Vector2Int.Distance(current, i)).ToList()[0];
                roomCenters.Remove(closest);
                HashSet<Vector2Int> newCorridor = CreateCorridor(current, closest);
                current = closest;
                corridors.UnionWith(newCorridor);
            }
            return corridors;
        }

        public HashSet<Vector2Int> CreateCorridor(Vector2Int current, Vector2Int destination)
        {
            HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();

            Vector2Int position = current;

            corridor.Add(position);

            while (position.y != destination.y)
            {
                if (destination.y > position.y)
                {
                    position += Vector2Int.up;
                }
                else if (destination.y < position.y)
                {
                    position += Vector2Int.down;
                }

                corridor.Add(position);
            }
            while (position.x != destination.x)
            {
                if (destination.x > position.x)
                {
                    position += Vector2Int.right;
                }
                else if (destination.x < position.x)
                {
                    position += Vector2Int.left;
                }

                corridor.Add(position);
            }
            return corridor;
        }
    }
}