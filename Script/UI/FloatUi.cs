using System;
using DG.Tweening;
using UnityEngine;

public class FloatUI : MonoBehaviour
{
    public Camera mainCamera; // 主摄像机

    public RectTransform canvasRectTransform; // Canvas的RectTransform
    public GameObject floatingUIInstance;
    private CanvasGroup canvasGroup;
    private Transform _transform;
    void Start()
    {

        canvasGroup =floatingUIInstance.GetComponent<CanvasGroup>();
        _transform = floatingUIInstance.transform;
        floatingUIInstance.SetActive(false); // 初始时隐藏UI
    }

    // 当玩家进入触发区域时调用
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // 确认是玩家
        {
            
            ///Debug.Log("GetSprint");
            floatingUIInstance.SetActive(true); // 显示UI
            canvasGroup.DOFade(1, 1f).From(0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _transform.DOMove(WorldToUICoordinates(transform.position), 1);
        floatingUIInstance.transform.position = WorldToUICoordinates(transform.position);
    }

    // 当玩家离开触发区域时调用
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // 确认是玩家
        {
            floatingUIInstance.SetActive(false); // 隐藏UI
            
        }
    }
    public Vector2 WorldToUICoordinates(Vector3 worldPosition)
    {
        // 将世界坐标转换为屏幕坐标
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

        // 将屏幕坐标转换为Canvas内的UI坐标
        Vector2 uiPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, mainCamera, out uiPosition);

        return screenPosition;
    }
}