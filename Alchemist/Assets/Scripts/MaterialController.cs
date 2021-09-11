using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialController : MonoBehaviour
{
    public Text materialName;

    [HideInInspector]
    public Material material;
    
    // Even if it doesn't show up in inspector, just to make it clear for everybody, added the tag
    [HideInInspector]
    public HashSet<string> craftables = new HashSet<string>();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = material.icon;
        gameObject.name = material.name;
        materialName.text = material.name;
        if (material.craftables.Length > 0)
        {
            craftables = new HashSet<string>();
            foreach (var material in material.craftables)
            {
                craftables.Add(material);
            }
        }
    }
}
