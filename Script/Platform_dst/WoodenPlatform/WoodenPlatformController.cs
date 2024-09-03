using System;
using UnityEngine;

public class WoodenPlatformController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private Rigidbody2D playerRigidbody;

    private bool isPlayerOn = false;

    private readonly float timeToWait = 1f;
    private float timeElapsed = 0f;

    private void OnCollisionStay2D (Collision2D collision)
    {
        if ( collision.collider.CompareTag("Player") )
        {
            // Debug.Log("Player is on the wooden platform");
            isPlayerOn = true;
            timeElapsed = 0;
        }
    }

    // Update is called once per frame
    private void Update ( )
    {
        // if (isPlayerOn || Input.GetKey(KeyCode.DownArrow))
        // Debug.Log($"Down the platform {isPlayerOn} {Input.GetKey(KeyCode.DownArrow)}");
        if ( isPlayerOn && Input.GetKey(KeyCode.DownArrow) )
        {
            //Debug.Log("Detection Disabled");
            GetComponent<BoxCollider2D>().excludeLayers = (1 << 8) | (1 << 3);
            playerController.SetvelocityY(Math.Min(Mathf.Abs(playerController.moveSpeedY), -2f));
        }

        timeElapsed += Time.deltaTime;
    }

    // ������� MonoBehaviour����ÿ���̶�֡���ʵ�֡�������ô˺���
    private void FixedUpdate ( )
    {
        // Debug.Log($"Player Velocity: {playerRigidbody.velocity.y}");
        if ( !isPlayerOn && playerRigidbody.velocity.y > 2f && timeElapsed >= timeToWait )
        {
            //Debug.Log("Detection Enabled");
            GetComponent<BoxCollider2D>().excludeLayers = 0;
            timeElapsed = 0;
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        isPlayerOn = false;
        timeElapsed = 0f;
        //Debug.Log("Player leaves the wooden platform");
    }

    private void Start ( )
    {
        GetComponent<BoxCollider2D>().excludeLayers = 0;

        playerRigidbody = playerController.GetComponent<Rigidbody2D>();

        //timeElapsed = 0;
    }
}
