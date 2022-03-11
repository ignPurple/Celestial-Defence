using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceshipGrid
{
    private Spaceship parent;
    private int size;
    private Object[,] spaceshipGrid;

    public SpaceshipGrid(Spaceship parent, int size)
    {
        this.parent = parent;
        this.size = size;
        this.InitializeArray();
    }

    public void TickModules() 
    {
        for (int width = 0; width < this.spaceshipGrid.GetLength(0); width++)
        {
            for (int length = 0; length < this.spaceshipGrid.GetLength(1); length++)
            {
                Module module = (Module) this.spaceshipGrid[width, length];
                if (module == null) 
                {
                    continue;
                }
                
                module.Tick();
            }
        }
    }

    public Module GetModule(Vector2 position)
    {
        int posX = (int)(position.x + this.size + 0.5f);
        int posY = (int)(position.y + this.size + 0.5f);

        if (posX > this.spaceshipGrid.GetLength(0) || posY > this.spaceshipGrid.GetLength(1)) {
            return null;
        }

        Module module = (Module)this.spaceshipGrid[posX, posY];
        return module;
    }

    public Module SetModule(Vector2 position, ModuleType moduleType)
    {
        int posX = (int)(position.x + this.size + 0.5f);
        int posY = (int)(position.y + this.size + 0.5f);

        Module module = this.CreateModule(new Vector2(position.x, position.y), moduleType);
        module.SetLoc(posX, posY);

        this.spaceshipGrid[posX, posY] = module;

        return module;
    }

    private void InitializeArray()
    {
        this.spaceshipGrid = new Object[(this.size * 2) + 1, (this.size * 2) + 1];

        for (int width = 0; width < this.spaceshipGrid.GetLength(0); width++)
        {
            for (int length = 0; length < this.spaceshipGrid.GetLength(1); length++)
            {
                Module module = this.CreateModule(new Vector2(width - this.size, length - this.size), ModuleType.EMPTY);
                this.spaceshipGrid[width, length] = module;
            }
        }
    }

    private Module CreateModule(Vector2 position, ModuleType moduleType)
    {
        return this.parent.InstantiateModule(position, moduleType);
    }
}