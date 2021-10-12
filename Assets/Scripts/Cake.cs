using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    public event UnityAction Ate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Ate?.Invoke();
        }
    }
}
