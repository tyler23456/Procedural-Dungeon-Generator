using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDA.Generators
{
    public class ThemeManager
    {
        List<GameObject> prefabs;
        List<GameObject> objs;

        public ThemeManager()
        {
            prefabs = new List<GameObject>();
            objs = new List<GameObject>();
        }

        public void Add(GameObject[] prefabs)
        {
            this.prefabs.AddRange(prefabs);
        }

        public List<GameObject> Next(int count)
        {
            objs = new List<GameObject>();

            for (int i = 0; i < count; i++)
                objs.Add(prefabs[Random.Range(0, prefabs.Count)]);

            return objs;
        }
    }
}