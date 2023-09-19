using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
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
    public static int coinKillBoss;
    public static bool load;
    public Image Hpbar;

    public GameObject BannerHpBoss;
    public GameObject checkBannerNcap;
    // Start is called before the first frame update
    void Start()
    {
        Hphientai = LevelManager.level * 30;
        if (LevelManager.LevelUp == true)
        {
            damage = (int)(Enemy.damage * 2 * 0.7);
            coinKillBoss = LevelManager.level * 150;
            LevelManager.LevelUp = false;
        }
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BannerHpBoss.activeInHierarchy)
            {
                BannerHpBoss.SetActive(false);
            }
            else BannerHpBoss.SetActive(true);
        }
        Hpbar.fillAmount = (float)Hphientai / (LevelManager.level * 30);
        FlipEnemy();
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= ChaseRange && !bitancong && !isAttacking)
        {
            anim.SetBool("Walk", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else anim.SetBool("Walk", false);

        if (!isAttacking && distance <= RangeAttack)
        {
            StartCoroutine(EnemyAttack());
        }
    }
    private IEnumerator EnemyAttack()
    {
            isAttacking = true;
            int ran = Random.Range(1, 3);
            if (ran == 1)
            {
                anim.SetBool("Attack" + ran, true);
            }
            else if (ran == 2)
            {
                anim.SetBool("Attack" + ran, true);
            }

            if (Vector2.Distance(transform.position, player.transform.position) <= RangeAttack && Hphientai > 0)
            {
                player.TakeDamage(damage);
            }
            //thoi gian chuyen anim attack ve idle
            yield return new WaitForSeconds(0.4f);
            anim.SetBool("Attack" + ran, false);
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
        if (Hphientai <= 0)
        {
            StartCoroutine(TimeDestroyEnemy());
        }
        else
        {
            anim.SetTrigger("Hurt");
            //anim.SetBool("Attack1", false);
            //anim.SetBool("Attack2", false);
            bitancong = true;
            Vector2 distance = (transform.position - player.transform.position).normalized;
            rb.AddForce(distance * lucday, ForceMode2D.Impulse);
            StartCoroutine(timeKnockBack());
        }
    }
    private void FlipEnemy()
    {
        if (player.transform.position.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    private IEnumerator TimeDestroyEnemy()
    {
        anim.SetTrigger("Hurt");
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetTrigger("Death");
        bitancong = true;
        yield return new WaitForSeconds(0.7f);
        levelManager.soquaidagiet += 1;
        UpdatePlayer.Coin += coinKillBoss;
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
