using System;
using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private GameObject ballPrefab;
    private Transform ballParent;

    public static Action OnBallSpawned { get; set; }

    private void Awake()
    {
        ballPrefab = Resources.Load<GameObject>("ball");
        ballParent = transform.parent;
    }

    private void Start()
    {
        StartCoroutine(nameof(Spawning));
    }

    private IEnumerator Spawning()
    {
        while(true)
        {
            OnBallSpawned?.Invoke();
            Instantiate(ballPrefab, ballParent);
            yield return new WaitForSeconds(10);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(nameof(Spawning));
    }
}
