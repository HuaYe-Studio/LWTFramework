using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    // Start is called before the first frame update
    public void shoot()
    {
        Vector2 direction =new Vector2(playerTransform.position.x-transform.position.x,playerTransform.position.y-transform.position.y) .normalized;
        Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 实例化子弹对象并设置射击速度和方向
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f,0f,angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
}
