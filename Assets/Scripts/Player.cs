using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int hpCurrent;
    public int hpMax;
    public int damage;
    public int speed;
    public int attackSpeed;
    public int Critical;
    //
    public int coin;
    public int lvHp;
    public int lvDamage;
    public int lvMoveSpeed;
    public int lvAtackSpeed;
    public int lvCritical;
    public int coinUpgradeHp;
    public int coinUpgradeDamage;
    public int coinUpgradeMoveSpeed;
    public int coinUpgradeAttackSpeed;
    public int coinUpgradeCritical;

    public string nameLevel;
    Enemy enemy;
    public int damagequai;
    public int coinkillquai;
    //
    Boss boss;
    public int damageboss;
    public int coinkillboss;
    public int Level;

    public void SavePlayer()
    {
        hpCurrent = PlayerController.HpCurrent;
        hpMax = PlayerController.HpMax;
        damage = PlayerController.damage;
        speed = PlayerController.speed;
        attackSpeed = PlayerController.AttackSpeed;
        Critical = PlayerController.Critical;
        coin = UpdatePlayer.Coin;
        lvHp = UpdatePlayer.LvHp;
        lvDamage = UpdatePlayer.LvDamage;
        lvMoveSpeed = UpdatePlayer.LvMoveSpeed;
        lvAtackSpeed = UpdatePlayer.LvAttackSpeed;
        lvCritical = UpdatePlayer.LvCritical;
        coinUpgradeHp = UpdatePlayer.CoinUpgradeHp;
        coinUpgradeDamage = UpdatePlayer.CoinUpgradeDamage;
        coinUpgradeMoveSpeed = UpdatePlayer.CoinUpgradeMoveSpeed;
        coinUpgradeAttackSpeed = UpdatePlayer.CoinUpgradeAttackSpeed;
        coinUpgradeCritical = UpdatePlayer.CoinUpgradeCritical;
        nameLevel = LevelManager.nameLevel;
        Level = LevelManager.level;
        //
        damagequai = Enemy.damage;
        coinkillquai = Enemy.coinKillquai;
        //
        if (LevelManager.level > 0 && LevelManager.level % 5 == 0)
        {
            damageboss = Boss.damage;
            coinkillboss = Boss.coinKillBoss;
        }
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if(data.Level > 1)
        {
            PlayerController.loadd = true;
            UpdatePlayer.loadUpdatePlayer = true;
            LevelManager.load = true;
            Enemy.load = true;
            LevelManager.level = data.Level;
            PlayerController.HpCurrent = data.hpCurrent;
            PlayerController.HpMax = data.hpMax;
            PlayerController.damage = data.damage;
            PlayerController.speed = data.speed;
            PlayerController.AttackSpeed = data.attackSpeed;
            PlayerController.Critical = data.Critical;
            UpdatePlayer.Coin = data.coin;
            UpdatePlayer.LvHp = data.lvHp;
            UpdatePlayer.LvDamage = data.lvDamage;
            UpdatePlayer.LvMoveSpeed = data.lvMoveSpeed;
            UpdatePlayer.LvAttackSpeed = data.lvAtackSpeed;
            UpdatePlayer.LvCritical = data.lvCritical;
            UpdatePlayer.CoinUpgradeHp = data.coinUpgradeHp;
            UpdatePlayer.CoinUpgradeDamage = data.coinUpgradeDamage;
            UpdatePlayer.CoinUpgradeMoveSpeed = data.coinUpgradeMoveSpeed;
            UpdatePlayer.CoinUpgradeAttackSpeed = data.coinUpgradeAttackSpeed;
            UpdatePlayer.CoinUpgradeCritical = data.coinUpgradeCritical;
            LevelManager.nameLevel = data.nameLevel;
            //
            Enemy.damage = data.damagequai;
            Enemy.coinKillquai = data.coinkillquai;
            SceneManager.LoadScene(LevelManager.nameLevel);
            //
            if (LevelManager.level > 0 && LevelManager.level % 5 == 0)
            {
                Boss.damage = data.damage;
                Boss.coinKillBoss = data.coinkillboss;
            }
        }
    }

    //
    public void SaveWhenNextLevelorRetry()
    {
        hpCurrent = PlayerController.HpCurrent;
        hpMax = PlayerController.HpMax;
        damage = PlayerController.damage;
        speed = PlayerController.speed;
        attackSpeed = PlayerController.AttackSpeed;
        Critical = PlayerController.Critical;
        coin = UpdatePlayer.Coin;
        lvHp = UpdatePlayer.LvHp;
        lvDamage = UpdatePlayer.LvDamage;
        lvMoveSpeed = UpdatePlayer.LvMoveSpeed;
        lvAtackSpeed = UpdatePlayer.LvAttackSpeed;
        lvCritical = UpdatePlayer.LvCritical;
        coinUpgradeHp = UpdatePlayer.CoinUpgradeHp;
        coinUpgradeDamage = UpdatePlayer.CoinUpgradeDamage;
        coinUpgradeMoveSpeed = UpdatePlayer.CoinUpgradeMoveSpeed;
        coinUpgradeAttackSpeed = UpdatePlayer.CoinUpgradeAttackSpeed;
        coinUpgradeCritical = UpdatePlayer.CoinUpgradeCritical;
        //
        damagequai = Enemy.damage;
        coinkillquai = Enemy.coinKillquai;
        //
        if(LevelManager.level > 0 && LevelManager.level % 5 == 0)
        {
            damageboss = Boss.damage;
            coinkillboss = Boss.coinKillBoss;
        }
        SaveSystem.SavePlayer(this);
    }
    public void LoadWhenNextLevelorRetry()
    {
        PlayerController.loadd = true;
        UpdatePlayer.loadUpdatePlayer = true;
        LevelManager.load = true;
        Enemy.load = true;
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerController.HpCurrent = data.hpCurrent;
        PlayerController.HpMax = data.hpMax;
        PlayerController.damage = data.damage;
        PlayerController.speed = data.speed;
        PlayerController.AttackSpeed = data.attackSpeed;
        PlayerController.Critical = data.Critical;
        UpdatePlayer.Coin = data.coin;
        UpdatePlayer.LvHp = data.lvHp;
        UpdatePlayer.LvDamage = data.lvDamage;
        UpdatePlayer.LvMoveSpeed = data.lvMoveSpeed;
        UpdatePlayer.LvAttackSpeed = data.lvAtackSpeed;
        UpdatePlayer.LvCritical = data.lvCritical;
        UpdatePlayer.CoinUpgradeHp = data.coinUpgradeHp;
        UpdatePlayer.CoinUpgradeDamage = data.coinUpgradeDamage;
        UpdatePlayer.CoinUpgradeMoveSpeed = data.coinUpgradeMoveSpeed;
        UpdatePlayer.CoinUpgradeAttackSpeed = data.coinUpgradeAttackSpeed;
        UpdatePlayer.CoinUpgradeCritical = data.coinUpgradeCritical;
        //
        Enemy.damage = data.damagequai;
        Enemy.coinKillquai = data.coinkillquai;
        //
        if (LevelManager.level > 0 && LevelManager.level % 5 == 0)
        {
            Boss.damage = data.damage;
            Boss.coinKillBoss = data.coinkillboss;
        }
    }
}
