using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    [SerializeField] int stompDamage = 1;
    [SerializeField] float BounceForce = 12;
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.gameObject != player.gameObject 
            && other.gameObject.GetComponent<PlayerHealth>().InvicibilityCounter == 0 
            && !player.IsGrounded && GameManager.instance.CanFight)
        {
            other.GetComponent<PlayerHealth>().DamagePlayer(stompDamage);

            player.Rb.velocity = new Vector3(player.Rb.velocity.x, BounceForce);
        }
    }
}
