using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    public GameManager gameManager;
    public AnimationManager animationManager;
    public Spaceship spaceship;

    private bool stopAnimation;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Module module = spaceship.GetModule(position);
            if (module == null) {
                return;
            }
            
            Module selected = gameManager.GetSelectedModule();
            if (selected != null) {
                this.stopAnimation = true;

                selected.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                gameManager.ClearSelectedModule();

                animationManager.GetAnimator("upgrades").SetBool("open", false);
                return;
            }

            module.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.85f, 1f);
            gameManager.SetSelectedModule(module);

            animationManager.GetAnimator("upgrades").SetBool("open", true);
        }
    }

    void FixedUpdate()
    {
        this.spaceship.GetSpaceshipGrid().TickModules();
    }
}
