using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinhHp : MonoBehaviour
{
    AudioManager audio;
    private void Start()
    {
        audio = GameObject.FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController.HpCurrent += Enemy.damage;
            audio.PlaySFX(audio.hoihp);
            if(PlayerController.HpCurrent > PlayerController.HpMax)
            {
                PlayerController.HpCurrent = PlayerController.HpMax;
            }
            Destroy(this.gameObject);
        }
    }
}
