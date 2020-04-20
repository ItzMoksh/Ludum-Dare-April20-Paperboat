using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject ripplePrefab = null;

    public void GenerateRippleAt(Vector3 pos)
    {
        var ripple = Instantiate(ripplePrefab,pos,Quaternion.identity);
        RippleView rippleView = ripple.GetComponent<RippleView>();
        rippleView.Init(this);
        StartCoroutine(rippleView.Ripple(pos));
    }

    public void Die()
    {
        Debug.Log("DEAD");
    }
}
