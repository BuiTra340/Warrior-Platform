using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    //public float attack1;
    //public float attack2;
    //public bool canAttack1;
    //public bool canAttack2;
    public bool isGrounded;
    public static int speed;
    public static int HpCurrent;
    public static int HpMax = 100;
    public static int damage = 5;
    public static int Critical;
    public static int AttackSpeed = 10;
    private float CoundownTimerAttackSpeed;
    private float MoveSpeed;

    public Image HpBar;
    public float timeSpikeMakeDamage = 0f;
    private int combo =1;
    private bool isAttackCombo;
    private bool canMove;

    AudioManager audio;
    public static bool loadd;
    Enemy enemy;
    public GameObject BannerPlayerDie;
    Player player;
    private bool doubleJump;

    public Text HpText;
    public GameObject TextDamage;
    public Text textDame;
    // Start is called before the first frame update
    void Start()
    {
        if(!loadd)
        {
            StartCoroutine(TimeToWait());
        }
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GameObject.FindObjectOfType<AudioManager>();
        enemy = GameObject.FindObjectOfType<Enemy>();
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = "" + HpCurrent +"/" +HpMax;
        HpBar.fillAmount = (float)HpCurrent / HpMax;
        if(HpCurrent > 0)
        {
            AttackCombo();
            PlayerWalk();
            PlayerJump();
        }
        checkPositonY();
    }
    IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(0.2f);
        damage = 5;
        HpMax = 100;
        HpCurrent = HpMax;
        speed = 50;
        Critical = 10;
        AttackSpeed = 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int rate = Random.Range(Critical / 10, 101);
            if (rate == 100)
            {
                //them hieu ung chi mang
                collision.gameObject.GetComponent<Enemy>().textDame.fontSize = 45;
                collision.gameObject.GetComponent<Enemy>().textDame.color = Color.red;     
                collision.gameObject.GetComponent<Enemy>().takeDamage(damage*2);
            }
            else
            {
                collision.gameObject.GetComponent<Enemy>().textDame.fontSize = 40;
                collision.gameObject.GetComponent<Enemy>().textDame.color = Color.white;
                collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            int rate = Random.Range(Critical / 10, 101);
            if (rate == 100)
            {
                //them hieu ung chi mang
                collision.gameObject.GetComponent<Boss>().textDame.fontSize = 45;
                collision.gameObject.GetComponent<Boss>().textDame.color = Color.red;
                collision.gameObject.GetComponent<Boss>().takeDamage(damage * 2);
            }
            else
            {
                collision.gameObject.GetComponent<Boss>().textDame.fontSize = 40;
                collision.gameObject.GetComponent<Boss>().textDame.color = Color.white;
                collision.gameObject.GetComponent<Boss>().takeDamage(damage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            if (timeSpikeMakeDamage <= 0)
            {
                TakeDamage(5);
                timeSpikeMakeDamage = 0.5f;
            }
            else timeSpikeMakeDamage -= Time.deltaTime;
        }
    }
    private void PlayerWalk()
    {
        //if(canAttack1 && canAttack2)
        if(canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal == 1)
            {
                transform.localScale = new Vector3(1, 1, 0);
                anim.SetBool("Walk", true);
            }
            else if (horizontal == -1)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                anim.SetBool("Walk", true);
            }
            else anim.SetBool("Walk", false);
            PlayerRun();
            transform.position += new Vector3(horizontal * MoveSpeed * Time.deltaTime, 0, 0);
        }
    }
    private void PlayerRun()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0 && isGrounded && canMove)
        {
            MoveSpeed = (float)(speed + 20)/10;
            anim.SetBool("Run", true);
        }
        else
        {
            MoveSpeed = (float)(speed )/ 10;
            anim.SetBool("Run", false);
        }
    }
    //private void PlayerAttack()
    //{
    //    if (attack1 >= 0.5f)
    //    {
    //        canAttack1 = true;
    //        if (Input.GetKeyDown(KeyCode.E) && canAttack1 && canAttack2)
    //        {
    //            canAttack1 = false;
    //            attack1 = 0;
    //            anim.SetTrigger("Attack1");
    //            anim.SetBool("Run", false);
    //            anim.SetBool("Walk", false);
    //        }
    //    }
    //    else attack1 += Time.deltaTime;
    //    //
    //    if (attack2 >= 0.5f)
    //    {
    //        canAttack2 = true;
    //        if (Input.GetKeyDown(KeyCode.R) && canAttack1 && canAttack2)
    //        {
    //            canAttack2 = false;
    //            attack2 = 0;
    //            anim.SetTrigger("Attack2");
    //            anim.SetBool("Run", false);
    //            anim.SetBool("Walk", false);
    //        }
    //    }
    //    else attack2 += Time.deltaTime;
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            doubleJump = true;
            rb.velocity = Vector2.zero;
            isGrounded = true;
            anim.SetBool("Jump", false);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            doubleJump = true;
            isGrounded = false;
            anim.SetBool("Jump", true);
        }
    }
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            doubleJump = !doubleJump;
            isGrounded = false;
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
            rb.velocity = new Vector2(0, 13f);
        }
    }
    public void TakeDamage(int damage)
    {
        textDame.text = "-" + damage;
        TextDamage.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0.1f,1.2f,0));
        TextDamage.SetActive(true);
        StartCoroutine(Destext());
        HpCurrent -= damage;
        if (HpCurrent > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            HpCurrent = 0;
            anim.Play("Player_Death");
            StartCoroutine(waitPlayerdie());
        }
    }
    IEnumerator waitPlayerdie()
    {
        yield return new WaitForSeconds(1f);
        if (!BannerPlayerDie.activeInHierarchy)
        {
            BannerPlayerDie.SetActive(true);
        }
        Time.timeScale = 0;
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void checkPositonY()
    {
        if(transform.position.y <= -7.5f)
        {
            StartCoroutine(waitPlayerdie());
        }
    }
    // them ham start va finish combo tai event animation player
    public void startCombo()
    {
        isAttackCombo = false;
        if(combo < 2)
        {
            combo++;
        }
    }
    public void finishCombo()
    {
        CoundownTimerAttackSpeed = AttackSpeed;
        canMove = true;
        isAttackCombo = false;
        combo = 1;
    }
    public void AttackCombo()
    {
        if (Input.GetKey(KeyCode.E) && !isAttackCombo && combo >= 1 && CoundownTimerAttackSpeed <= 0 && isGrounded)
        {
            audio.PlaySFX(audio.attack);
            canMove = false;
            isAttackCombo = true;
            anim.SetTrigger("Combo " + combo);
        }
        else CoundownTimerAttackSpeed -= Time.deltaTime * 10;
    }
    public void Retry()
    {
        Time.timeScale = 1;
        if(LevelManager.level > 1)
        {
            player.LoadWhenNextLevelorRetry();
            SceneManager.LoadScene(LevelManager.nameLevel);
        }else SceneManager.LoadScene(1);
        BannerPlayerDie.SetActive(false);
    }
    public void ExitPlayerDie()
    {
        Time.timeScale = 1;
        BannerPlayerDie.SetActive(false);
        SceneManager.LoadScene(0);
    }
    private IEnumerator Destext()
    {
        yield return new WaitForSeconds(0.5f);
        TextDamage.SetActive(false);
    }
}
