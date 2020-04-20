using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleView : MonoBehaviour
{
    private GameController gameController;
    private float rippleZ;
    private float currRippleRadius = 0;

    [SerializeField] private float rippleDelta = 0;
    [SerializeField] private float rippleDelay = 0;
    [SerializeField] private float deathRadius = 0f;

    public float radius = 5.0F;
    public float power = 10.0F;
    public Vector3 target = new Vector3();

    public void Init(GameController gameController)
    {
        this.gameController = gameController;
    }

    public IEnumerator Ripple(Vector3 ripplePos)
    {
        target = ripplePos;
        while (currRippleRadius < radius)
        {
            transform.localScale = new Vector3(currRippleRadius * 15, currRippleRadius * 15, 1);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(ripplePos, currRippleRadius);
            foreach (Collider2D hit in colliders)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    if (currRippleRadius < deathRadius)
                    {
                        gameController.Die();
                    }
                    else
                    {
                        Vector2 dir = (rb.transform.position - ripplePos).normalized;
                        rb.AddForceAtPosition(power * dir, rb.position, ForceMode2D.Force);
                    }

                }

            }

            currRippleRadius += rippleDelta;
            yield return new WaitForSeconds(rippleDelay);
        }

        currRippleRadius = 0;
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(target, currRippleRadius);
    }
}

