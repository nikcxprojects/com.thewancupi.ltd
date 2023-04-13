using System;
using UnityEngine;

public class OutZone : MonoBehaviour
{
    public static Action OnBallLose { get;set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallLose?.Invoke();
        Destroy(collision.gameObject);
    }
}
