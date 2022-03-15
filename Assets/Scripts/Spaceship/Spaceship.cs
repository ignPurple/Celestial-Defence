using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public int size;
    private SpaceshipGrid spaceshipGrid;

    public List<TypeModule> types;
    private Dictionary<ModuleType, Module> moduleTypes;

    void Awake()
    {
        this.InitializeDictionary();

        this.spaceshipGrid = new SpaceshipGrid(this, this.size);
    }

    public SpaceshipGrid GetSpaceshipGrid()
    {
        return this.spaceshipGrid;
    }

    public bool IsAdjecent(Vector2 position) {
        return this.spaceshipGrid.IsAdjecent(position);
    }

    public Module GetModule(Vector2 position)
    {
        return this.spaceshipGrid.GetModule(position);
    }

    public Module SetModule(Vector2 position, ModuleType moduleType)
    {
        return this.spaceshipGrid.SetModule(position, moduleType);
    }

    public Module GetModule(ModuleType moduleType)
    {
        if (!this.moduleTypes.ContainsKey(moduleType))
        {
            moduleType = ModuleType.EMPTY;
        }

        return this.moduleTypes[moduleType];
    }

    public void DestroyModule(Module module, bool replace)
    {
        Vector2 position = module.transform.position;
        Destroy(module.gameObject);
        
        if (!replace) {
            return;
        }

        this.SetModule(position, ModuleType.EMPTY);
    }

    public Module InstantiateModule(Vector2 position, ModuleType moduleType)
    {
        Transform instantiatedModule = Instantiate(this.GetModule(moduleType).transform, position, Quaternion.identity, this.transform);
        instantiatedModule.name = instantiatedModule.name.Replace("(Clone)", "");

        Module module = instantiatedModule.GetComponent<Module>();
        int posX = (int)(position.x + this.size + 0.5f);
        int posY = (int)(position.y + this.size + 0.5f);
        module.SetLoc(posX, posY);

        return module;
    }

    private void InitializeDictionary()
    {
        this.moduleTypes = new Dictionary<ModuleType, Module>();
        foreach (TypeModule typeModule in this.types)
        {
            this.moduleTypes.Add(typeModule.type, typeModule.module);
        }
    }

    [System.Serializable]
    public class TypeModule
    {
        public ModuleType type;
        public Module module;
    }
}
