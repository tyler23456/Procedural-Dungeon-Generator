using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GDA.Generators
{
    public class WaveFunctionCollapse
    {
        /*public Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();

        Queue<Neighbor> neighbors = new Queue<Neighbor>();

        HashSet<Vector2Int> uncollapsedTiles = new HashSet<Vector2Int>();

        Dictionary<Vector2Int, List<WorldObject>> tileObjects = new Dictionary<Vector2Int, List<WorldObject>>();

        public Dictionary<Vector2Int, List<WorldObject>> Generate(List<Vector2Int> positions, List<Dictionary<int, float>> connectionRules, int gridLength)
        {
            int i = 0;
            foreach (Dictionary<int, float> connections in connectionRules)
            {
                foreach (int e in connections.Keys)
                {
                    Debug.Log(i.ToString() + ":  " + e.ToString());
                }

                i++;
            }

            Debug.Log(connectionRules.Count);

            Debug.Log(connectionRules[0].Keys.Count);

            Debug.Log(connectionRules[1].Keys.Count);



            //initialize data
            foreach (Vector2Int position in positions)
            {
                tiles.Add(new Vector2Int(position.x, position.y), new Tile(Enumerable.Range(0, connectionRules.Count).ToList()));
                uncollapsedTiles.Add(new Vector2Int(position.x, position.y));
            }

            //start algorithm
            Vector2Int key;
            Vector2Int neighbor;
            Vector2Int original;
            Vector3 worldPosition = Vector3.zero;
            int removed;

            int timeOutAccumulator = 0;

            while (uncollapsedTiles.Count > 0)
            {
                int value; //needs to be from a list of values

                key = uncollapsedTiles.OrderBy(i => tiles[i].possibilities.Count).ToList()[0]; //remove first

                //collapse next tile
                value = tiles[key].possibilities[Random.Range(0, tiles[key].possibilities.Count)];
                tiles[key].possibilities.Clear();
                tiles[key].possibilities.Add(value);
                uncollapsedTiles.Remove(key);

                worldPosition.x = key.x * gridLength;
                worldPosition.z = key.y * gridLength;
                tileObjects.Add(key, new List<WorldObject>());                
                tileObjects[key].Add(new WorldObject(worldPosition, tiles[key].possibilities[0], UnityEngine.Random.Range(0, 6), 0));

                //add its neighbors to the neighbors list
                CheckNeighbors(key);

                while (neighbors.Count > 0)
                {
                    //check through each neighbor regarding certain criteria                  
                    //key = neighbors.First().position;
                    neighbor = neighbors.Peek().position;
                    original = neighbors.Peek().original;

                    //need to check neighbors in comparison to the tile that was changed.
                    removed = RemoveImpossibilities(tiles[neighbor].possibilities, tiles[original].possibilities, connectionRules);

                    if (tiles[neighbor].hasNoPossibleValue)
                    {
                        Debug.Log("this state is dead");
                        return tileObjects;
                    }

                    //if changes have been made, add its neighbors to the list
                    if (removed > 0)
                    {
                        CheckNeighbors(neighbor);
                    };

                    //if collapsed, remove from uncollapsed
                    if (tiles[neighbor].isCollapsed)
                    {
                        uncollapsedTiles.Remove(neighbor);

                        worldPosition.x = neighbor.x * gridLength;
                        worldPosition.z = neighbor.y * gridLength;
                        tileObjects.Add(neighbor, new List<WorldObject>());
                        tileObjects[neighbor].Add(new WorldObject(worldPosition, tiles[neighbor].possibilities[0], UnityEngine.Random.Range(0, 6), 0));
                    }

                    neighbors.Dequeue();

                    timeOutAccumulator++;
                    if (timeOutAccumulator > 1000)
                    {
                        Debug.Log("Time out accumulator has been reached");
                        return tileObjects;
                    }
                }
            }

            foreach (KeyValuePair<Vector2Int, Tile> tile in tiles)
            {
                Debug.Log(tile.Key.x.ToString() + " " + tile.Key.y.ToString() + ": " + tile.Value.possibilities[0].ToString());
                Debug.Log(tile.Value.possibilities.Count.ToString());
            }

            return tileObjects;
    
        }

        public void CheckNeighbors(Vector2Int key)
        {
            if (uncollapsedTiles.Contains(key + Vector2Int.left))
                neighbors.Enqueue(new Neighbor(key + Vector2Int.left, key));

            if (uncollapsedTiles.Contains(key + Vector2Int.right))
                neighbors.Enqueue(new Neighbor(key + Vector2Int.right, key));

            if (uncollapsedTiles.Contains(key + Vector2Int.up))
                neighbors.Enqueue(new Neighbor(key + Vector2Int.up, key));

            if (uncollapsedTiles.Contains(key + Vector2Int.down))
                neighbors.Enqueue(new Neighbor(key + Vector2Int.down, key));
        }

        int removed = 0;
        public int RemoveImpossibilities(List<int> neighborPossibilities, List<int> originalPossibilities, List<Dictionary<int, float>> connectionRules)
        {
            removed = 0;

            for (int n = 0; n < neighborPossibilities.Count; n++)
            {
                for (int o = 0; o < originalPossibilities.Count; o++)
                {
                    if (!connectionRules[neighborPossibilities[n]].ContainsKey(originalPossibilities[o]))
                    {
                        neighborPossibilities.RemoveAt(n);
                        removed++;
                        n--;
                    }
                }
            }

            return removed;
        }

        public void Update() { }
        public void FixedUpdate() { }

        public class Tile
        {
            public List<int> possibilities;
            public bool isCollapsed => possibilities.Count == 1;
            public bool hasNoPossibleValue => possibilities.Count == 0;

            public Tile(List<int> allPossibilities)
            {
                this.possibilities = allPossibilities;
            }
        }

        public struct Neighbor
        {
            public Vector2Int position;
            public Vector2Int original;

            public Neighbor(Vector2Int position, Vector2Int original)
            {
                this.position = position;
                this.original = original;
            }
        }*/
    }
}