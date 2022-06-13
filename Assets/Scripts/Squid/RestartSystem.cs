using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RestartSystem : MonoBehaviour
{
    [SerializeField] private Squid _squid;


    public UnityEvent onRestart;

    public UnityEvent onRevival;
    public void Restart()
    {
        onRestart?.Invoke();
      
    }

    public void Revival()
    {
        onRevival?.Invoke();
    }
}
