using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdatePlayer : MonoBehaviour
{
    public static int Coin;
    public Text TextCoin;

    public static int LvDamage;
    public static int LvHp;
    public static int LvCritical;
    public static int LvMoveSpeed;
    public static int LvAttackSpeed;

    public static int CoinUpgradeDamage;
    public static int CoinUpgradeHp;
    public static int CoinUpgradeCritical;
    public static int CoinUpgradeMoveSpeed;
    public static int CoinUpgradeAttackSpeed;

    public Text ChisoDamage;
    public Text ChisoHp;
    public Text ChisoCritical;
    public Text ChisoMoveSpeed;
    public Text ChisoAttackSpeed;

    public Text textUpgradeDamage;
    public Text textUpgradeHp;
    public Text textUpgradeCritical;
    public Text textUpgradeMoveSpeed;
    public Text textUpgradeAttackSpeed;

    public Text textLvDamage;
    public Text textLvHp;
    public Text textLvCritical;
    public Text textLvMoveSpeed;
    public Text textLvAttackSpeed;

    public GameObject Ncapthanhcong;
    public GameObject Ncapthatbai;
    public GameObject bannerNcap;
    public GameObject BannerPause;

    public static bool loadUpdatePlayer;
    AudioManager audio;
    // Start is called before the first frame update
    void Start()
    {
        if(!loadUpdatePlayer)
        {
            Coin = 0;
            LvDamage = 0;
            LvHp = 0;
            LvAttackSpeed = 0;
            LvMoveSpeed = 0;
            LvCritical = 0;
            CoinUpgradeDamage = 200;
            CoinUpgradeHp = 200;
            CoinUpgradeCritical = 200;
            CoinUpgradeMoveSpeed = 200;
            CoinUpgradeAttackSpeed = 200;
        }
        audio = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChisoDamage.text = "Damage " + PlayerController.damage + " -> " + (PlayerController.damage + 5);
        ChisoHp.text = "Hp " + PlayerController.HpMax + " -> " + (PlayerController.HpMax + 20);
        
        //
        textUpgradeDamage.text = "Upgrade " + CoinUpgradeDamage + " coins";
        textUpgradeHp.text = "Upgrade " + CoinUpgradeHp + " coins";
        
        //
        textLvDamage.text = "Damage\n Lv" + LvDamage;
        textLvHp.text = "Hp\n Lv" + LvHp;

        if(LvMoveSpeed < 20)
        {
            ChisoMoveSpeed.text = "Move Speed " + (float)PlayerController.speed / 10 + " -> " + (float)(PlayerController.speed + 1) / 10;
            textUpgradeMoveSpeed.text = "Upgrade " + CoinUpgradeMoveSpeed + " coins";
            textLvMoveSpeed.text = "Move Speed\n Lv" + LvMoveSpeed;
        }
        else
        {
            ChisoMoveSpeed.text = "Move Speed " + (float)PlayerController.speed / 10;
            textUpgradeMoveSpeed.text = "Max";
            textLvMoveSpeed.text = "Move Speed\n Lv Max";
        }
        //
        if(LvAttackSpeed < 9)
        {
            textUpgradeAttackSpeed.text = "Upgrade " + CoinUpgradeAttackSpeed + " coins";
            ChisoAttackSpeed.text = "Attack Speed " + (float)PlayerController.AttackSpeed / 10 + " -> " + (float)(PlayerController.AttackSpeed - 1) / 10;
            textLvAttackSpeed.text = "Attack Speed\n Lv" + LvAttackSpeed;
        }
        else
        {
            textUpgradeAttackSpeed.text = "Max";
            ChisoAttackSpeed.text = "Attack Speed " + (float)PlayerController.AttackSpeed / 10;
            textLvAttackSpeed.text = "Attack Speed\n Lv Max";
        }
        //
        if(LvCritical < 700)
        {
            ChisoCritical.text = "Critical " + (float)PlayerController.Critical / 10 + " -> " + (float)(PlayerController.Critical + 1) / 10;
            textUpgradeCritical.text = "Upgrade " + CoinUpgradeCritical + " coins";
            textLvCritical.text = "Critical\n Lv" + LvCritical;
        }
        else
        {
            ChisoCritical.text = "Critical " + (float)PlayerController.Critical / 10;
            textUpgradeCritical.text = "Max";
            textLvCritical.text = "Critical\n Lv Max";
        }

        TextCoin.text = "" + Coin;
        showBannerPause();
    }

    public void NcapDamage()
    {
        Time.timeScale = 1;
        if (Coin >= CoinUpgradeDamage)
        {
            Coin -= CoinUpgradeDamage;
            LvDamage += 1;
            PlayerController.damage += 5;
            CoinUpgradeDamage = CoinUpgradeDamage + (CoinUpgradeDamage * 12) / 100;
            audio.PlaySFX(audio.Ncapthanhcong);
            if(!Ncapthanhcong.activeInHierarchy)
            {
                Ncapthanhcong.SetActive(true);
                StartCoroutine(Desbannerthongbao(Ncapthanhcong));
            }
        }
        else
        {
            audio.PlaySFX(audio.Ncapthatbai);
            if (!Ncapthatbai.activeInHierarchy)
            {
                Ncapthatbai.SetActive(true);
                StartCoroutine(Desbannerthongbao(Ncapthatbai));
            }
        }
    }
    public void NcapHp()
    {
        Time.timeScale = 1;
        if (Coin >= CoinUpgradeHp)
        {
            Coin -= CoinUpgradeHp;
            LvHp += 1;
            PlayerController.HpMax += 20;
            CoinUpgradeHp = CoinUpgradeHp + (CoinUpgradeHp * 12) / 100;
            audio.PlaySFX(audio.Ncapthanhcong);
            if (!Ncapthanhcong.activeInHierarchy)
            {
                Ncapthanhcong.SetActive(true);
                StartCoroutine(Desbannerthongbao(Ncapthanhcong));
            }
        }
        else
        {
            audio.PlaySFX(audio.Ncapthatbai);
            if (!Ncapthatbai.activeInHierarchy)
            {
                Ncapthatbai.SetActive(true);
                StartCoroutine(Desbannerthongbao(Ncapthatbai));
            }
        }
    }
    public void NcapCritical()
    {
        Time.timeScale = 1;
        if(LvCritical < 700)
        {
            if (Coin >= CoinUpgradeCritical)
            {
                Coin -= CoinUpgradeCritical;
                LvCritical += 1;
                PlayerController.Critical += 1;
                CoinUpgradeCritical = CoinUpgradeCritical + (CoinUpgradeCritical * 12) / 100;
                audio.PlaySFX(audio.Ncapthanhcong);
                if (!Ncapthanhcong.activeInHierarchy)
                {
                    Ncapthanhcong.SetActive(true);
                    StartCoroutine(Desbannerthongbao(Ncapthanhcong));
                }
            }
            else
            {
                audio.PlaySFX(audio.Ncapthatbai);
                if (!Ncapthatbai.activeInHierarchy)
                {
                    Ncapthatbai.SetActive(true);
                    StartCoroutine(Desbannerthongbao(Ncapthatbai));
                }
            }
        }
    }
    public void NcapMoveSpeed()
    {
        Time.timeScale = 1;
        if(LvMoveSpeed < 20)
        {
            if (Coin >= CoinUpgradeMoveSpeed)
            {
                Coin -= CoinUpgradeMoveSpeed;
                LvMoveSpeed += 1;
                PlayerController.speed += 1;
                CoinUpgradeMoveSpeed = CoinUpgradeMoveSpeed + (CoinUpgradeMoveSpeed * 12) / 100;
                audio.PlaySFX(audio.Ncapthanhcong);
                if (!Ncapthanhcong.activeInHierarchy)
                {
                    Ncapthanhcong.SetActive(true);
                    StartCoroutine(Desbannerthongbao(Ncapthanhcong));
                }
            }
            else
            {
                audio.PlaySFX(audio.Ncapthatbai);
                if (!Ncapthatbai.activeInHierarchy)
                {
                    Ncapthatbai.SetActive(true);
                    StartCoroutine(Desbannerthongbao(Ncapthatbai));
                }
            }
        }
    }
    public void NcapAttackSpeed()
    {
        Time.timeScale = 1;
        if(LvAttackSpeed < 9)
        {
            if (Coin >= CoinUpgradeAttackSpeed)
            {
                Coin -= CoinUpgradeAttackSpeed;
                LvAttackSpeed += 1;
                PlayerController.AttackSpeed -= 1;
                CoinUpgradeAttackSpeed = CoinUpgradeAttackSpeed + (CoinUpgradeAttackSpeed * 12) / 100;
                audio.PlaySFX(audio.Ncapthanhcong);
                if (!Ncapthanhcong.activeInHierarchy)
                {
                    Ncapthanhcong.SetActive(true);
                    StartCoroutine(Desbannerthongbao(Ncapthanhcong));
                }
            }
            else
            {
                audio.PlaySFX(audio.Ncapthatbai);
                if (!Ncapthatbai.activeInHierarchy)
                {
                    Ncapthatbai.SetActive(true);
                    StartCoroutine(Desbannerthongbao(Ncapthatbai));
                }
            }
        }
    }
    public void BtnX()
    {
        Time.timeScale = 1;
        BannerPause.SetActive(false);
        SceneManager.LoadScene(0);
    }
    IEnumerator Desbannerthongbao(GameObject banner)
    {
        yield return new WaitForSeconds(1f);
        banner.SetActive(false);
        if(bannerNcap.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
    }
    public void ShowBannerNcap()
    {
        if (!bannerNcap.activeInHierarchy)
        {
            bannerNcap.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ExitBannerNcap()
    {
        Time.timeScale = 1f;
        bannerNcap.SetActive(false);
    }
    private void showBannerPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!BannerPause.activeInHierarchy)
            {
                Time.timeScale = 0;
                BannerPause.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                BannerPause.SetActive(false);
            }
        }    
    }
    public void Resume()
    {
        if(BannerPause.activeInHierarchy)
        {
            Time.timeScale = 1;
            BannerPause.SetActive(false);
        }
    }
}
