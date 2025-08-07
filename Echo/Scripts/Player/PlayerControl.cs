using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    Rigidbody2D rb;
    Vector2 movement;
    public Transform respawnPoint; // 拖你的空物体进来
    public float moveThreshold = 0.01f; // 判断是否在动的阈值

    Animation anim; // 如果需要动画控制，可以添加这个变量
    Animator animator; // 如果需要动画控制，可以添加这个变量

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;       // 2D游戏通常不需要重力
        rb.drag = 10f;              // 增加 drag 减少滑动感

        animator= GetComponent<Animator>(); // 获取 Animator 组件，如果需要动画控制






    }

    // Update is called once per frame
    void Update()
    {
        movement.x=Input.GetAxis("Horizontal");
        movement.y=Input.GetAxis("Vertical");

        movement.Normalize(); // Normalize the vector to ensure consistent speed in all directions
        MoveAni(); // 调用动画方法
        DirAni(); // 调用方向动画方法
    }


    private void FixedUpdate()
    {
        rb.velocity = movement * speed; // Apply the movement vector to the Rigidbody2D's velocity
       
    }



    void MoveAni()
    {
        if (movement != Vector2.zero)
        {
            // 如果有动画控制，可以在这里设置动画参数
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    void DirAni()
    {
        if (movement == Vector2.zero) return;

        if (movement.x > 0)
            animator.SetInteger("Direction", 2);
        else if (movement.x < 0)
            animator.SetInteger("Direction", 3);
        else if (movement.y > 0)
            animator.SetInteger("Direction", 1);
        else if (movement.y < 0)
            animator.SetInteger("Direction", 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && IsMoving())
        {
            Debug.Log("Player hit by enemy while moving. Respawning...");
            Respawn();
        }
    }
    bool IsMoving()
    {
        return rb.velocity.magnitude > moveThreshold;
    }
    void Respawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero; // 防止复活后还在滑动
    }
}
