using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionTMPro;
    public Transform materialGrid;
    public string[] colors;

    private Transform materials;
    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public void ShowFoundMaterials(string description)
    {
        //TODO: Pick a random color from colors and set as panel background color
        descriptionTMPro.text = description;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        if (!gameObject.activeSelf)
        {
            materials = transform.GetChild(0);
            for (int i = 0; i < materials.childCount; i++)
            {
                Destroy(materials.GetChild(i).gameObject);
            }
        }
    }
}
