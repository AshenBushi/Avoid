using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private TypeEffect _type;
    private Animator _animator;

    public TypeEffect Type => _type;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
