using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private GameController gameController = null;
    public Vector3 target = new Vector3();
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameController.GenerateRippleAt(new Vector3(target.x, target.y, 0));
        }
    }

    public void Die()
    {
        
    }
}
