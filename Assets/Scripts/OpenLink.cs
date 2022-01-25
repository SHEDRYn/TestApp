using UnityEngine;

public class OpenLink : MonoBehaviour
{
    [SerializeField] private string url;

    public void OpenUrl()
    {
        Application.OpenURL(url);
    }
    
}
