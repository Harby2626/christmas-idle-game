using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _ins;

    public static GameAssets instance
    {
        get
        {
            if (_ins == null) _ins = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _ins;
        }
    }

    public Sprite _speed_upg_sprite;
    public Sprite _cap_upg_sprite;
    public Sprite _coin_upg_sprite;
}
