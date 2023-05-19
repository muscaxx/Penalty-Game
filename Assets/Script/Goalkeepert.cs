using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeepert : MonoBehaviour
{
    public int[] pos;
    public int Move;
    public int index;
    Animator goalkeeper;

    // Start is called before the first frame update
    void Start()
    {
        goalkeeper = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (Move ==0)
        {
            Reset();
        }
        if (Move == 1)
        {
            SaveR();
        }
        if (Move ==2)
        {
            SaveL();
        }

    }

    public void GolMove()
    {
        index = Random.Range(0, pos.Length);
        Move = pos[index];
    }
    public void SaveR()
    {
        goalkeeper.SetFloat("Save", 0.5f);
    }
    public void SaveL()
    {
        goalkeeper.SetFloat("Save", 1f);
    }
    public void Reset()
    {
        goalkeeper.SetFloat("Save", 0f);
    }

}
