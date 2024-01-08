using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GDA.Generators
{
    public class RoomSizeGenerator
    {
        static BoundsInt bound;
        static Vector3Int size;
        static Vector3Int position;

        public List<BoundsInt> Generate(List<BoundsInt> rooms, int shortestSideMinimum, int shortestSideMaximum, int longestSideMinimum, int longestSideMaximum)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                bound = rooms[i];
                size = bound.size;
                position = bound.min;

                if (bound.size.x > bound.size.z) //x is larger
                {
                    size.x = Mathf.Clamp(size.x, longestSideMinimum, longestSideMaximum);
                    size.z = Mathf.Clamp(size.z, shortestSideMinimum, shortestSideMaximum);
                }
                else //z is larger or equal to
                {
                    size.x = Mathf.Clamp(size.x, shortestSideMinimum, shortestSideMaximum);
                    size.z = Mathf.Clamp(size.z, longestSideMinimum, longestSideMaximum);
                }

                bound.min = position;
                bound.size = size;
                rooms[i] = bound;
            }

            return rooms;
        }
    }
}