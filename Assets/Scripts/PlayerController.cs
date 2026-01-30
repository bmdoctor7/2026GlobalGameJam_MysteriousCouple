using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public float jumpForce = 5f; // 跳跃力度
    private Rigidbody2D rb; // 玩家刚体
    private bool isGrounded; // 是否在地面上

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 获取水平输入
        float moveInput = Input.GetAxis("Horizontal");
        // 设置玩家水平移动
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 检测跳跃输入
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否与地面碰撞
        if (collision.gameObject.CompareTag("Black"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 检测是否离开地面
        if (collision.gameObject.CompareTag("Black"))
        {
            isGrounded = false;
        }
    }
}
