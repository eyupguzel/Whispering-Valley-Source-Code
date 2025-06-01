using System;
using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    [SerializeField] private  Transform sleepPosition;
    private GameObject canvas;

    private void Awake()
    {
        canvas = transform.Find("bedPanel").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            canvas.GetComponent<UIControl>().Show(() => 
            { 
                GameManager.Instance.sleepService.HandleSleep(); 
                SetPlayerPosition();
            });
        }
    }
    private void SetPlayerPosition()
    {
        PlayerController.Instance.transform.position = sleepPosition.position;
    }
}
