using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Module selectedModule = null;

    public Module GetSelectedModule() {
        return this.selectedModule;
    }

    public void SetSelectedModule(Module module) {
        this.selectedModule = module;
    }

    public void ClearSelectedModule() {
        this.selectedModule = null;
    }
}
