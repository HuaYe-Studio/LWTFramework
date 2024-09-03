using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    // Start is called before the first frame update
   // public Transform player; // 玩家的Transform
    public float detectionRange = 10f; // 检测范围
    public LayerMask playerLayer; // 玩家所在的Layer
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        // 向左检测玩家
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, detectionRange, playerLayer);
        // 向右检测玩家
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, detectionRange, playerLayer);

        // 如果左侧或右侧检测到玩家
        if (hitLeft.collider != null || hitRight.collider != null)
        {
            animator.SetTrigger("IsDetected");
        }
    }
}