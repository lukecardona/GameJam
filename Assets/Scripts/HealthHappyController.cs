using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthHappyController : MonoBehaviour
{
    //public int curHealth = 0;
    //public int maxHealth = 100;

    [SerializeField] private Slider sliderHealth, sliderHappy;
    [SerializeField] private int distance = 50;
    [SerializeField] private GameObject companion;
    private PlayerDeath playerdeath;
    private PlayerAttack playerAttack;
    private bool death = false;
    private float timerTakeDamage = 0.25f;
    private bool canTakeDamage = true;
    private Animator anim;
    private IEnumerator coroutine;

    /*void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer( int damage )
    {
        curHealth -= damage;

        sliderHealth.SetHealth( curHealth );
    }*/


    // Start is called before the first frame update
    void Start()
    {
        //sliderHealth = GetComponent<Slider>();
        //sliderHappy = GetComponent<Slider>();
        playerdeath = GetComponent<PlayerDeath>();
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {

        if (sliderHealth.value == 0)
        {
            if (!death)
            {
                Debug.Log("Dead");
                death = true;
                playerdeath.Die();
            }
        }
        if (sliderHappy.value == 0)
        {
            sliderHealth.value--;
        }
        if (Vector3.Distance(companion.transform.position, transform.position) > distance)
        {
            if (sliderHappy.value > 0)
            {
                sliderHappy.value--;
            }
        }
        if (Vector3.Distance(companion.transform.position, transform.position) < distance)
        {
            if (sliderHappy.value < sliderHappy.maxValue)
            {
                sliderHappy.value++;
            }
        }
        if ((sliderHappy.value == sliderHappy.maxValue) && (sliderHealth.value < sliderHealth.maxValue))
        {
            sliderHealth.value++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !playerAttack.attacking)
        {
            if (canTakeDamage)
            {
                sliderHealth.value = sliderHealth.value - sliderHealth.maxValue / 5;

                coroutine = delayDamage();
                StartCoroutine(coroutine);
            }
        }

    }

    IEnumerator delayDamage()
    {
        canTakeDamage = true;
        yield return new WaitForSeconds(1);
        
    }
}
