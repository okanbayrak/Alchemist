
using UnityEngine;

namespace Assets.Scripts
{
    public class Cauldron
    {
        public string Type { get; set; }
        public GameObject MaterialGameObject { get; set; }
        public Cauldron(string cauldronType)
        {
            Type = cauldronType;
        }
    }
}