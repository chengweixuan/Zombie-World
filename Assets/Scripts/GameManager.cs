using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        // called by zombieAI to take damage
        Debug.Log("taking " + damage + " damage");
    }

}
