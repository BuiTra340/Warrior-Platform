using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
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
    //
    public string nameLevel;
    public int damagequai;
    public int coinkillquai;
    //
    public int damageboss;
    public int coinkillboss;

    public int Level;
    public PlayerData(Player player)
    {
        hpCurrent = player.hpCurrent;
        hpMax = player.hpMax;
        damage = player.damage;
        speed = player.speed;
        attackSpeed = player.attackSpeed;
        Critical = player.Critical;
        coin = player.coin;
        lvHp = player.lvHp;
        lvDamage = player.lvDamage;
        lvMoveSpeed = player.lvMoveSpeed;
        lvAtackSpeed = player.lvAtackSpeed;
        lvCritical = player.lvCritical;
        coinUpgradeHp = player.coinUpgradeHp;
        coinUpgradeDamage = player.coinUpgradeDamage;
        coinUpgradeMoveSpeed = player.coinUpgradeMoveSpeed;
        coinUpgradeAttackSpeed = player.coinUpgradeAttackSpeed;
        coinUpgradeCritical = player.coinUpgradeCritical;
        nameLevel = player.nameLevel;
        Level = player.Level;
        //
        damagequai = player.damagequai;
        coinkillquai = player.coinkillquai;
        if(Level > 0 && Level % 5 == 0)
        {
            damageboss = player.damageboss;
            coinkillboss = player.coinkillboss;
        }
        
    }
}
