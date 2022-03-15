using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private bool gridEnabled;
    public Spaceship spaceship;
    public SpriteRenderer hover;

    private static float OPACITY = 0.35f;
    private static Color CANT_PLACE = new Color(1, 0, 0, OPACITY);
    private static Color CAN_PLACE = new Color(0, 1, 0, OPACITY);

    void FixedUpdate()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Module module = this.spaceship.GetModule(position);
        GameObject hoverObject = hover.gameObject;
        if (module == null) 
        {
            hoverObject.SetActive(false);
            return;
        }

        hoverObject.SetActive(true);
        Transform hoverTransform = hover.transform;
        hoverTransform.position = module.transform.position;
        if (!this.spaceship.IsAdjecent(position)) 
        {
            this.hover.color = CANT_PLACE;
            return;
        }
        
        this.hover.color = CAN_PLACE;
    }
}
