using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private CraftingManager craftingManager;
    private bool isDragging;
    private Vector3 mousePosition;
    private void Awake()
    {
        mousePosition = new Vector3(0, 0, 0);
        craftingManager = (CraftingManager)FindObjectOfType(typeof(CraftingManager));
    }
    private void OnMouseDown()
    {
        isDragging = true;
        //transform.GetComponent<CanvasGroup>().alpha = .5f;
    }
    private void OnMouseUp()
    {
        SetMousePosition();
        transform.GetComponent<CanvasGroup>().alpha = 1;
        isDragging = false;
        for (int i = 0; i < craftingManager.placeholders.Length; i++)
        {
            if (mousePosition.x >= craftingManager.placeholders[i].position.x - 50 && mousePosition.x <= craftingManager.placeholders[i].position.x + 50 &&
                mousePosition.y >= craftingManager.placeholders[i].position.y - 50 && mousePosition.y <= craftingManager.placeholders[i].position.y + 50)
            {
                if (craftingManager.cauldrons[i].MaterialGameObject != null)
                {
                    craftingManager.cauldrons[i].MaterialGameObject.transform.localPosition = Vector3.zero;
                    craftingManager.materialInCauldronsCount--;
                }
                transform.position = craftingManager.placeholders[i].position;
                craftingManager.cauldrons[i].MaterialGameObject = gameObject;
                craftingManager.cauldrons[i].Type = gameObject.name;
                craftingManager.materialInCauldronsCount++;
                break;
            }
            else if (craftingManager.cauldrons[i].Type == gameObject.name)
            {
                craftingManager.cauldrons[i].MaterialGameObject = null;
                craftingManager.cauldrons[i].Type = string.Empty;
                craftingManager.materialInCauldronsCount--;
            }
            else
            {
                transform.localPosition = Vector3.zero;
            }
        }
        if (craftingManager.materialInCauldronsCount == 2)
        {
            craftingManager.Craft();
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            SetMousePosition();
            transform.position = mousePosition;
        }
    }

    private void SetMousePosition()
    {
        mousePosition = Input.mousePosition;
    }
}
