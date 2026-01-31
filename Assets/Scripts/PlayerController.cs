using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public float jumpForce = 5f; // 跳跃力度
    private Rigidbody2D rb; // 玩家刚体
    public bool isGrounded; // 是否在地面上
    public Vector3 startPosition;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
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
        
        // 检测翻转输入
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WorldManager.Instance.limit--;
            EventManager.Broadcast(EventType.Invert);
        }
        
        // 检测是否用完翻转次数
        if (WorldManager.Instance.limit < 0)
        {
            WorldManager.Instance.limit = WorldManager.Instance.levelLimits[WorldManager.Instance.currentLevel];
            transform.position = startPosition;
            EventManager.Broadcast(EventType.Invert);
            EventManager.Broadcast(EventType.NumlimitsTips);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否与地面碰撞
        if (collision.gameObject)
        {
            isGrounded = true;
        }
        
        // 死亡重置
        // 颜色反转初始，S能力初始，C能力初始，取消灰色固定，重置mask次数
        if (collision.gameObject.CompareTag("Edge"))
        {
            transform.position = startPosition;
            WorldManager.Instance.limit = WorldManager.Instance.levelLimits[WorldManager.Instance.currentLevel];
            EventManager.Broadcast(EventType.Invert);
            EventManager.Broadcast(EventType.CancelFixed);
            EventManager.Broadcast(EventType.UpdateSenergyUI);
        }

        // 到达终点，加载下一关
        if (collision.gameObject.CompareTag("Finish"))
        {
            EventManager.Broadcast(EventType.NextLevel);
        }

        // 收集能量
        if (collision.gameObject.CompareTag("Energy"))
        {
            if(collision.gameObject.GetComponent<Energy>().type == 1)
            {
                BuildManager.Instance.senery++;
            }
            else if(collision.gameObject.GetComponent<Energy>().type == 2)
            {
                BuildManager.Instance.cenergy++;
            }
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
