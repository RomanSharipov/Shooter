using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
