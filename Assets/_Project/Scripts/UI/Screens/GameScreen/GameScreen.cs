using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : UIScreen
{
    [SerializeField] private BonusDisplay _bonusDisplay;

    public BonusDisplay BonusDisplay => _bonusDisplay;
}
