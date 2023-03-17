using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource playerDeathSound;
    [SerializeField] private AudioSource playerDamageSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) //Isaac Change here to health bar == 0 
    {
        /*if (collision.gameObject.CompareTag("Trap")) 
        {
            Die(); imbad call die <-
        } */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage();
        }
    }

    //Dying Method
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        playerDeathSound.Play();
    }

    //Take Damage Method
    private void takeDamage()
    {
        //Debug.Log("Took Damage");
        //Animate Take Damage
        anim.SetTrigger("tookDamage");
        playerDamageSound.Play();
        //Reduce Health bar please Isaac Here
    }

    //Restart Level Method, triggered from death animation
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}