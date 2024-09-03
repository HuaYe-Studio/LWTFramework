using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float wanderRange = 5f; // 敌人徘徊的范围
    public float speed = 2f; // 敌人移动的速度
    public Transform BrithPlaceTransform;
    private float originalX; // 出生时的X坐标
    private float currentTargetX; // 当前目标X坐标

    void Start()
    {
        originalX = BrithPlaceTransform.position.x;
        SetNewTarget();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(currentTargetX, transform.position.y), step);

        if (Mathf.Abs(transform.position.x - currentTargetX) < 0.1f)
        {
            SetNewTarget();
        }
    }

    void SetNewTarget()
    {
        float targetX = originalX + Random.Range(-wanderRange, wanderRange);
        currentTargetX = targetX;
    }
}

