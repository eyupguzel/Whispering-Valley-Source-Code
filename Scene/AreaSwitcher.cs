using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaSwitcher : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    private Vector3 spawnPoint;
    private static bool AreaSwitching;

    private void Start()
    {
        spawnPoint = transform.Find("SpawnPoint").position;

        if (AreaSwitching)
        {
            PlayerController.Instance.transform.position = spawnPoint;
            AreaSwitching = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SceneManager.Instance.LoadScene(sceneIndex));
            AreaSwitching = true;
        }
    }
}
