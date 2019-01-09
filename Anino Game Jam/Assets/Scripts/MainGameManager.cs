using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager
{
    [SerializeField] private ScrollingBackground[] scrollingItems;

    private static MainGameManager instance;
    public static MainGameManager Instance
    {
        get { return instance; }
    }

    public void SlowDownScrolling()
    {
        if (scrollingItems != null)
        {
            for (int i = 0; i < scrollingItems.Length; i++)
            {
                if (i == 0)
                {
                    scrollingItems[i].Speed = -0.2f;
                }
                else
                {
                    scrollingItems[i].Speed = -0.5f;
                }
            }
        }
    }

    public void NormalScrolling()
    {
        if (scrollingItems != null)
        {
            for (int i = 0; i < scrollingItems.Length; i++)
            {
                if (i == 0)
                {
                    scrollingItems[i].Speed = 0.5f;
                }
                else
                {
                    scrollingItems[i].Speed = 2.0f;
                }
            }
        }
    }
}
