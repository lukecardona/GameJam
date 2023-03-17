using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject attackArea = default;
    private Animator anim; 
    public bool attacking = false; //Is the player attacking
    private float timeToAttack = 0.3f; //Time to attack
    private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //Press f to attack
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime; //Increment Time

            if(timer >= timeToAttack) //If Timer Exceeded
            {
                timer = 0f;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }   

    private void Attack()
    {
        if (!attacking)
        {
            Debug.Log("Attacking");
            anim.SetTrigger("attack");
            attacking = true;
            attackArea.SetActive(attacking);
        }
    }
}
