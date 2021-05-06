using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Crafting Material")]
public class Material : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public string[] craftables;
}
