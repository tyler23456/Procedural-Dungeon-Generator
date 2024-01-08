using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class BinarySpacePartitioner
    {
        public List<BoundsInt> Generate(BoundsInt spaceToSplit, int minWidth, int minHeight)
        {
            Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
            List<BoundsInt> roomCuboids = new List<BoundsInt>();
            roomsQueue.Enqueue(spaceToSplit);
           
            while (roomsQueue.Count > 0)
            {
                BoundsInt room = roomsQueue.Dequeue();
                if (room.size.x >= minWidth && room.size.z >= minHeight)
                {
                    if (Random.value < 0.5f)
                    {
                        if (room.size.z >= minHeight * 2)
                        {
                            SplitHorizontally(minHeight, roomsQueue, room);
                        }
                        else if (room.size.x >= minWidth * 2)
                        {
                            SplitVertically(minWidth, roomsQueue, room);
                        }
                        else if (room.size.x >= minWidth && room.size.z >= minHeight)
                        {
                            roomCuboids.Add(room);
                        }
                    }
                    else
                    {
                        if (room.size.x >= minWidth * 2)
                        {
                            SplitVertically(minWidth, roomsQueue, room);
                        }
                        else if (room.size.z >= minHeight * 2)
                        {
                            SplitHorizontally(minHeight, roomsQueue, room);
                        }
                        else if (room.size.x >= minWidth && room.size.z >= minHeight)
                        {
                            roomCuboids.Add(room);
                        }
                    }
                }
            }

            return roomCuboids;
        }

        public void SplitVertically(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
        {
            int xSplit = Random.Range(1, room.size.x);
            BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
            BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z), 
                new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
            roomsQueue.Enqueue(room1);
            roomsQueue.Enqueue(room2);
        }

        public void SplitHorizontally(int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
        {
            int zSplit = Random.Range(1, room.size.z);
            BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, room.size.y, zSplit));
            BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y, room.min.z + zSplit),
                new Vector3Int(room.size.x, room.size.y, room.size.z - zSplit));
            roomsQueue.Enqueue(room1);
            roomsQueue.Enqueue(room2);
        }
    }
}