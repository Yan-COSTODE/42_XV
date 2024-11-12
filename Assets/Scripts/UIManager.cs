using UnityEngine;

public class UIManager : SingletonTemplate<UIManager>
{
    [SerializeField] private CircleUI circleUI;
    
    public CircleUI CircleUI => circleUI;
}
