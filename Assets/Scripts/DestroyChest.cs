using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChest : MonoBehaviour
{
    public GameObject BinhHp;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hit")
        {
            anim.SetTrigger("Smash");
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        int a = Random.Range(1, 3);
        if (a == 2)
        {
            Instantiate(BinhHp, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
