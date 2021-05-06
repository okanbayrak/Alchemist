using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Transform[] placeholders;
    public GameObject materialSetPrefab;
    public GameObject materialSetPanelPrefab;
    public PanelManager craftedMaterialsPanel;
    public Transform materialGrid;
    public Transform materialGridPanel;
    public List<Material> materials;

    [HideInInspector]
    public Cauldron[] cauldrons = new Cauldron[2];
    [HideInInspector]
    public int materialInCauldronsCount;

    private HashSet<string> craftedMaterials = new HashSet<string>();
    private readonly string[] startingMaterials = { "Fire", "Water", "Earth", "Air" };

    private void Awake()
    {
        for (int i = 0; i < placeholders.Length; i++)
        {
            cauldrons[i] = new Cauldron(string.Empty);
        }
        for (int i = 0; i < startingMaterials.Length; i++)
        {
            GenerateMaterial(materialSetPrefab, materialGrid, materials.Find(x => x.name == startingMaterials[i]));
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Craft()
    {
        int numberOfMaterials = 0;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string craftable in cauldrons[0].MaterialGameObject.GetComponent<MaterialController>().craftables)
        {
            if (!craftedMaterials.Contains(craftable) && cauldrons[1].MaterialGameObject.GetComponent<MaterialController>().craftables.Contains(craftable))
            {
                Material material = materials.Find(x => x.name == craftable);
                GenerateMaterial(materialSetPrefab, materialGrid, material);
                GenerateMaterial(materialSetPanelPrefab, materialGridPanel, material);

                stringBuilder.Append(material.name);
                stringBuilder.Append(": ");
                stringBuilder.Append(material.description);
                stringBuilder.AppendLine();
                numberOfMaterials++;
            }
        }
        if (numberOfMaterials > 0)
        {
            StopAllCoroutines();
            StartCoroutine(ShowFoundMaterials(numberOfMaterials, stringBuilder.ToString()));
        }
        else
        {
            //TODO: Put an indicator in case of no match for the materials in cauldrons
            Camera.main.GetComponent<CameraController>().Shake();
        }
    }

    IEnumerator ShowFoundMaterials(int numberOfMaterials, string description)
    {
        craftedMaterialsPanel.ShowFoundMaterials(description);
        craftedMaterialsPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f * numberOfMaterials);
        craftedMaterialsPanel.gameObject.SetActive(false);
    }

    private void GenerateMaterial(GameObject prefab, Transform parent, Material material)
    {
        GameObject newObject = Instantiate(prefab, parent);
        newObject.GetComponentInChildren<MaterialController>().material = material;
        craftedMaterials.Add(material.name);
    }
}
