using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    public event UnityAction OnEat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnEat?.Invoke();
        }
    }
}
