using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectionBox;
    private Module selectedModule = null;

    public Module GetSelectedModule()
    {
        return this.selectedModule;
    }

    public void SetSelectedModule(Module module)
    {
        if (this.selectionBox != null)
        {
            Vector2 modulePosition = module.transform.position;
            this.selectionBox.SetActive(true);
            this.selectionBox.transform.position = new Vector3(modulePosition.x, modulePosition.y, -1);
        }

        this.selectedModule = module;
    }

    public void ClearSelectedModule()
    {
        if (this.selectionBox != null)
        {
            this.selectionBox.SetActive(false);
        }

        this.selectedModule = null;
    }
}
