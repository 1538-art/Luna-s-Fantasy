using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Ѫƿ��"+collision+"�Ե���!");
        //collision
        //LunaController lunaController= collision.GetComponent<LunaController>();
        //if (lunaController!=null)
        //{
        //    if (lunaController.Health<lunaController.lunaHP)
        //    {
        //        lunaController.ChangeHeath(1);
        //        Instantiate(effectGo, transform.position, Quaternion.identity);
        //        //Destroy(collision.gameObject);
        //        Destroy(gameObject);
        //    }
        //}

        if (GameManager.Instance.lunaCurrentHP < GameManager.Instance.lunaHP)
        {
            GameManager.Instance.AddOrDecreaseHP(40);
            Instantiate(effectGo, transform.position, Quaternion.identity);
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("Trigger�������");
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Trigger������");
    //}
}
