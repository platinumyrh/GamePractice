using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    Rigidbody2D rb;
    Vector2 movement;
    public Transform respawnPoint; // ����Ŀ��������
    public float moveThreshold = 0.01f; // �ж��Ƿ��ڶ�����ֵ

    Animation anim; // �����Ҫ�������ƣ���������������
    Animator animator; // �����Ҫ�������ƣ���������������

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;       // 2D��Ϸͨ������Ҫ����
        rb.drag = 10f;              // ���� drag ���ٻ�����

        animator= GetComponent<Animator>(); // ��ȡ Animator ����������Ҫ��������






    }

    // Update is called once per frame
    void Update()
    {
        movement.x=Input.GetAxis("Horizontal");
        movement.y=Input.GetAxis("Vertical");

        movement.Normalize(); // Normalize the vector to ensure consistent speed in all directions
        MoveAni(); // ���ö�������
        DirAni(); // ���÷��򶯻�����
    }


    private void FixedUpdate()
    {
        rb.velocity = movement * speed; // Apply the movement vector to the Rigidbody2D's velocity
       
    }



    void MoveAni()
    {
        if (movement != Vector2.zero)
        {
            // ����ж������ƣ��������������ö�������
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
        rb.velocity = Vector2.zero; // ��ֹ������ڻ���
    }
}
