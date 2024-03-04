using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class Staff : MonoBehaviour
{
    //State Machine Declare
    public enum State
    {
        Order,
        MakeCoffee,
        Clean,
        Leave;
    }
    State gameState;

    //Positions
    Vector3 makeCoffeePosition = new Vector3(-0.17f, 2.12f, 0);
    Vector3 pickUpPosition = new Vector3(-2.35f, 1.13f, 0);
    Vector3 restPosition = new Vector3(-4.21f, 0.3f, 0);
    Vector3 orderPosition = new Vector3(-1.28f, 1.42f, 0);

    //movement
    Vector3 target;
    public float speed = 3f;

    //Life cycle
    public float lifetime;
    public float deviation;
    float Energy;
    
    GameManager gm;

    //make coffee
    int coffee;
    float timer;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Energy = lifetime + UnityEngine.Random.Range(-deviation, deviation);
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        int wait = gm.getWaitLineCount();
        int order = gm.getOrderLineCount();
        StateUpdate();

        //movement
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        //destroy
        Energy -= Time.deltaTime;
        if (Energy <= 0)
        {
            gameState = State.Leave;
        }
        //change state
        if (wait > 5)
        {
            gameState = State.MakeCoffee;
        }
        else if(wait<5 && order > 3)
        {
            gameState = State.Order;
        }
        else if (order == 0 && wait > 0)
        {
            gameState = State.MakeCoffee;
        }
        else if (wait == 0 && order > 0)
        {
            gameState = State.Order;
        }
        else if (order == 0 && wait == 0)
        {
            gameState = State.Clean;
        }
    }


    //State Machine
    void StateStart(State newState)
    {
        switch (gameState)
        {
            case State.Order:
                target = orderPosition;
                break;
            case State.MakeCoffee:
                target = makeCoffeePosition;
                coffee = 0;
                break;
            case State.Clean:
                
                break;
        }
    }

    void StateUpdate()
    {
        switch (gameState)
        {
            case State.Order:
                
                break;
            case State.MakeCoffee:
                if(coffee <= 0)
                {
                    target = makeCoffeePosition;
                    if(transform.position == target && timer<=0)
                    {
                        timer = 
                    }
                }
                else if(coffee >= 0)
                {
                    target = pickUpPosition;
                    //change customer position;
                }
                break;
            case State.Clean:
                //wandering in eating area, randomly change walk speed (in random interval);
                break;
        }
    }
    void StateEnd(State oldState)
    {
        switch (gameState)
        {
            case State.Order:

                break;
            case State.MakeCoffee:

                break;
            case State.Clean:

                break;
        }
    }

}
