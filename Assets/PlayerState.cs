using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private float knockbackFactor;
    [SerializeField]
    private int health = 3;
    private GameObject currentPowerUp;
    private Vector3 knockback;
    private Rigidbody rb;
    private Holding holding;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        holding = GetComponent<Holding>();
    }

    // Update is called once per frame
    void Update()
    {

        if(holding.isHolding) {
            holding.updatePosition(transform.position + transform.forward);
        }

        if (Input.GetKeyDown(KeyCode.E) && holding.isHolding)
        {
            holding.releaseItem(Camera.main.transform.forward);
        }
        else if (Input.GetKeyDown(KeyCode.E) && holding.canPickUp)
        {
            holding.pickUp(transform.position + transform.forward);

        }

        if (health <= 0)
        {
            Debug.Log("you died, rip");
        }


    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Hand")
        {
            knockback = transform.position - col.gameObject.transform.position;
            knockback.y = 0;
            health--;
            if (knockback == Vector3.zero)
            {
                knockback.x = 1;
            }
            knockback = knockback.normalized;
            rb.AddForce(knockback * knockbackFactor);
        }

    }

   /* public void KnockBack(GameObject hand) {
        if (GetComponent<PlayerMovement>().IsGrounded())
        {
            Vector3 handPos = hand.transform.position;
            float dist = Vector3.Distance(handPos, transform.position);
            knockbackFactor = 200f / dist;
            knockback = transform.position - handPos;
            knockback.y = 1;
            if (dist < 7){
                health--;
            }
            if (knockback == Vector3.zero)
            {
                knockback.x = 1;
            }
            knockback = knockback.normalized;
            rb.velocity = (knockback * knockbackFactor);
        }
    }*/

    public int getHeath()
    {
        return health;
    }
}
