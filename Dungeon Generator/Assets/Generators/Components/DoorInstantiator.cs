using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GDA.Generators
{
    public class DoorInstantiator
    {
        static GameObject obj;
        static Vector2Int p = Vector2Int.zero;
        static Vector2Int nextP = Vector2Int.zero;
        static Vector3Int positionInt;
        static Vector3 position = Vector3.zero;
        static Quaternion rotation = Quaternion.identity;

        public void Instantiate(BoundsInt room, HashSet<Vector2Int> floorSet, HashSet<Vector2Int> roomSet, HashSet<Vector2Int> corridorSet, GameObject[] doors)
        {
            for (int i = 0; i < corridorSet.Count - 1; i++)
            {
                p = corridorSet.ElementAt(i);
                nextP = corridorSet.ElementAt(i + 1);
                positionInt = new Vector3Int(p.x, 0, p.y);

                if (nextP.x > p.x && !floorSet.Contains(nextP + Vector2Int.up) && !floorSet.Contains(nextP + Vector2Int.down)) //positive x direction
                {
                    position = new Vector3((p.x) * 5f, 0f, (p.y) * 5f);
                    rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                    obj = GameObject.Instantiate(doors[1], position, rotation, null);
                }
                else if (nextP.x < p.x && !floorSet.Contains(nextP + Vector2Int.up) && !floorSet.Contains(nextP + Vector2Int.down)) //negative x direction
                {
                    position = new Vector3((p.x - 1) * 5f, 0f, (p.y) * 5f);
                    rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                    obj = GameObject.Instantiate(doors[1], position, rotation, null);
                }
                else if (nextP.y > p.y && !floorSet.Contains(nextP + Vector2Int.left) && !floorSet.Contains(nextP + Vector2Int.right)) //positive y direction
                {
                    position = new Vector3((p.x) * 5f, 0f, (p.y + 1) * 5f);
                    rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    obj = GameObject.Instantiate(doors[1], position, rotation, null);
                }
                else if (nextP.y < p.y && !floorSet.Contains(nextP + Vector2Int.left) && !floorSet.Contains(nextP + Vector2Int.right)) //negative y direction
                {
                    position = new Vector3((p.x) * 5f, 0f, (p.y) * 5f);
                    rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    obj = GameObject.Instantiate(doors[1], position, rotation, null);
                }

            }
        }
    }
}

