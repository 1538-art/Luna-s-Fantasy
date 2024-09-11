using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float moveSpeed;

    //private string str;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1,0);
    private float moveScale;
    private Vector2 move;

    // Start is called before the first frame update
    private void Start()
    {
        //str = "/";
        //Application.targetFrameRate = 30;
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();
        //animator.SetFloat("MoveValue",0.5f);
        //animator.SetInteger("TestInt",1);
        //animator.SetBool("MoveState", true);
        //animator.SetTrigger("Test");
        //int lunaHP= GetCurrentLunaHP();
        //Debug.Log(lunaHP);
        //ChangeHeath();
        //lunaHP = 10;
    }

    // Update is called once per frame
    void Update() 
    {
        //玩家输入监听
        float horizontal = Input.GetAxisRaw("Horizontal");        //获取玩家水平轴向输入值
        float vertical = Input.GetAxisRaw("Vertical");        //获取玩家垂直轴向输入值
        move = new Vector2(horizontal,vertical);
        //animator.SetFloat("MoveValue",0);
        //当前玩家输入的某个轴向不为0
        if (!Mathf.Approximately(move.x,0)|| !Mathf.Approximately(move.y, 0))
        {
            lookDirection.Set(move.x,move.y);
            //lookDirection = move;
            lookDirection.Normalize();
            //animator.SetFloat("MoveValue", 1);
        }
        //动画的控制
        animator.SetFloat("Look X",lookDirection.x);
        animator.SetFloat("Look Y",lookDirection.y);
        moveScale = move.magnitude;
        if (move.magnitude>0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveScale = 1;
                moveSpeed = 2;
            }
            else
            {
                moveScale = 2;
                moveSpeed = 3.5f;
            }
        }
        animator.SetFloat("MoveValue", moveScale);
    
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        //position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
        //position.y = position.y + moveSpeed * vertical * Time.deltaTime;
        position = position + moveSpeed * move * Time.fixedDeltaTime;
        //transform.position = position;
        rigidbody2d.MovePosition(position);
    }


    public void Climb(bool start)
    {
        animator.SetBool("Climb",start);
    }

    public void Jump(bool start)
    {
        animator.SetBool("Jump",start);
        rigidbody2d.simulated = !start;
    }

    ////函数重载
    //private void ChangeHeath()
    //{
    //    lunaCurrentHP += 5;
    //}

    //private int ChangeHeath(float amount,int a,int b)
    //{
    //    return lunaCurrentHP;
    //}

    //private int GetCurrentLunaHP()
    //{
    //    return lunaCurrentHP;
    //}
}
