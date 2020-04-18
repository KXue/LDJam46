using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]
    private uint MAX_HEALTH = 100;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = (int)MAX_HEALTH;
    }
    public void TakeDamage(int amount)
    {
        health = Mathf.Max(health - amount, 0);
        if (health == 0)
        {
            //TODO: Implement game over stuff here
        }
        //TODO: Implement damage taken stuff here
    }
    public int GetHealth()
    {
        return health;
    }
}
