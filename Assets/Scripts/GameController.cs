using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Stack stack;
    public RessourceManager ressource;

    public void Start()
    {
        ressource=RessourceManager.Instance;
        stack = Stack.Instance;
        ressource.Initiate();
        stack.Initiate();
    }

    public void Update()
    {
        ressource.RessourceUpdate();
        stack.StackUpdate();
    }
}
