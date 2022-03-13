using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    public GameManager gameManager;
    public AnimationManager animationManager;
    public Spaceship spaceship;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Module module = spaceship.GetModule(position);
            if (module == null || typeof(EmptyModule).IsInstanceOfType(module))
            {
                return;
            }

            Module selected = gameManager.GetSelectedModule();
            if (selected != null)
            {
                gameManager.ClearSelectedModule();
                animationManager.GetAnimator("upgrades").SetBool("open", false);
                return;
            }

            gameManager.SetSelectedModule(module);
            animationManager.GetAnimator("upgrades").SetBool("open", true);
        }
    }

    void FixedUpdate()
    {
        this.spaceship.GetSpaceshipGrid().TickModules();
    }
}
