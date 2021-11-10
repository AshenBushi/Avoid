using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIScreen : MonoBehaviour
{
    protected CanvasGroup CanvasGroup;

    protected virtual void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Show()
    {
        CanvasGroup.alpha = 1f;
        CanvasGroup.blocksRaycasts = true;
    }
    
    public virtual void Hide()
    {
        CanvasGroup.alpha = 0f;
        CanvasGroup.blocksRaycasts = false;
    }
    
    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }
}
