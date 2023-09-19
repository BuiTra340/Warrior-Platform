using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Hphientai;
    public static int damage;
    public float speed;
    public float lucday;
    private Rigidbody2D rb;
    private PlayerController player;

    private Animator anim;
    private bool bitancong;
    private bool isAttacking;
    public float RangeAttack;
    public float ChaseRange;
    public float distance;

    public GameObject TextDamage;
    public Text textDame;
    public Vector3 Offset;
    LevelManager levelManager;
    public static int coinKillquai;
    public static bool load;
    // Start is called before the first frame update
    void Start()
    {
        if (!load)
        {
            Hphientai = 10;
            damage = 5;
            coinKillquai = 50;
        }
        Hphientai = LevelManager.level * 10;
        if (LevelManager.LevelUp == true)
        {
            damage = (int)(damage * 1.5); 
            coinKillquai = (int)(coinKillquai * 1.5);
            LevelManager.LevelUp = false;
        }
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        FlipEnemy();
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= ChaseRange && !bitancong && !isAttacking)
        {
            anim.SetBool("Walk", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else anim.SetBool("Walk", false);

        if(!isAttacking && distance <= RangeAttack)
        {
            StartCoroutine(EnemyAttack());
        }
    }
    private IEnumerator EnemyAttack()
    {
        isAttacking = true;
        anim.SetBool("Attack", true);
        //thoi gian chuyen anim attack ve idle
        yield return new WaitForSeconds(0.6f);
        if(Vector2.Distance(transform.position,player.transform.position)<= RangeAttack && Hphientai > 0)
        {
            player.TakeDamage(damage);
        }
        
        anim.SetBool("Attack", false);
        //thoi gian hoi attack
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    public void takeDamage(int damage)
    {
        textDame.text = "-" + damage;
        TextDamage.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
        TextDamage.SetActive(true);
        StartCoroutine(Destext());
        Hphientai -= damage;
        if(Hphientai <=0)
        {
            StartCoroutine(TimeDestroyEnemy());
        }else
        {
            anim.SetTrigger("Hurt");
            anim.SetBool("Attack", false);
            bitancong = true;
            Vector2 distance = (transform.position - player.transform.position).normalized;
            rb.AddForce(distance*lucday, ForceMode2D.Impulse);
            StartCoroutine(timeKnockBack());
        }
    }
    private void FlipEnemy()
    {
        if (player.transform.position.x > transform.position.x)
        {
            if(transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            } 
        }
        else
        {
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    private IEnumerator TimeDestroyEnemy()
    {
        anim.SetTrigger("Hurt");
        anim.SetBool("Attack", false);
        anim.SetTrigger("Death");
        bitancong = true;
        yield return new WaitForSeconds(0.5f);
        levelManager.soquaidagiet += 1;
        UpdatePlayer.Coin += coinKillquai;
        Destroy(this.gameObject);   
    }
    private IEnumerator timeKnockBack()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector2.zero;
        bitancong = false;
    }
    private IEnumerator Destext()
    {
        yield return new WaitForSeconds(0.5f);
        TextDamage.SetActive(false);
    }
}
