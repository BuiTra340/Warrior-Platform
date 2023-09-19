using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Player player;
    PlayerController playerController;
    public GameObject Bannerkethucontontai;
    public int soquaidagiet;
    public static string nameLevel;
    public static int level = 1;
    public static bool load;
    public GameObject BannerLV;
    public Text textLV;
    public static bool LevelUp;
    // Start is called before the first frame update
    void Start()
    {
        if(!load)
        {
            level = 1;
        }
        player = GameObject.FindObjectOfType<Player>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        textLV.text = "Level " + level;
        BannerLV.SetActive(true);
        StartCoroutine(DesbannerLV());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(level > 0 && level % 5 == 0)
            {
                if (soquaidagiet == 1) NextLevel();
                else
                {
                    if (!Bannerkethucontontai.activeInHierarchy)
                    {
                        Bannerkethucontontai.SetActive(true);
                        StartCoroutine(wait());
                    }
                    playerController.transform.position = new Vector2(playerController.transform.position.x - 2, playerController.transform.position.y);
                }
                    
            }else
            {
                if (soquaidagiet == 30)
                {
                    NextLevel();
                }
                else
                {
                    if (!Bannerkethucontontai.activeInHierarchy)
                    {
                        Bannerkethucontontai.SetActive(true);
                        StartCoroutine(wait());
                    }
                    playerController.transform.position = new Vector2(playerController.transform.position.x - 2, playerController.transform.position.y);
                }
            }
            
        }
    }
    private void NextLevel()
    {
        soquaidagiet = 0;
        level += 1;
        LevelUp = true;
        if(level > 0 && level % 5 == 0)
        {
            int a = Random.Range(1, 5);
            nameLevel = "MapBoss" + a;
        }
        else
        {
            int a = Random.Range(1, 6);
            nameLevel = "Map" + a;
        }
        player.SaveWhenNextLevelorRetry();
        player.LoadWhenNextLevelorRetry();
        SceneManager.LoadScene(nameLevel);
        // hoi 20% hp khi qua map
        PlayerController.HpCurrent += (20 * PlayerController.HpMax) / 100;
        if (PlayerController.HpCurrent > PlayerController.HpMax)
        {
            PlayerController.HpCurrent = PlayerController.HpMax;
        }
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Bannerkethucontontai.SetActive(false);
    }
    IEnumerator DesbannerLV()
    {
        yield return new WaitForSeconds(1.4f);
        BannerLV.SetActive(false);
    }
}
