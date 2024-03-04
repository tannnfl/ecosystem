using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

namespace MyGame
{
    public class Customer : MonoBehaviour
    {
        //State Machine Declare
        public enum State
        {
            Order,
            Wait,
            Sit,
            Leave
        }
        State gameState;
        public State initialState;

        Rigidbody2D rb;
        GameManager gm;

        public float speed = 3f;

        Vector3 target;


        void Start()
        {
            print("sports");
            StateStart(State.Order);
            rb = this.GetComponent<Rigidbody2D>();
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        void Update()
        {
            StateUpdate();
        }


        //State Machine
        void StateStart(State newState)
        {
            switch (gameState)
            {
                case State.Order:

                    break;
                case State.Wait:

                    break;
                case State.Sit:

                    break;
                case State.Leave:

                    break;
            }
        }
        void StateUpdate()
        {
            switch (gameState)
            {
                case State.Order:
                    //go to front desk;
                    float step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                    //line up;


                    //if staff exist, wait for 10 sec then state = wait;
                    //else, wait until staff exist;
                    break;
                case State.Wait:
                    //go to pick up spot;
                    //line up;
                    //if line spot = 0 && coffee exist, state = sit;
                    //else line up;
                    break;
                case State.Sit:
                    //find a empty spot;
                    //sit;
                    //wait for 20 sec - 120 sec, then state = leave;
                    break;
                case State.Leave:
                    //go to entrance;
                    //destroy
                    break;
            }
        }
        void StateEnd(State oldState)
        {
            switch (gameState)
            {
                case State.Order:

                    break;
                case State.Wait:

                    break;
                case State.Sit:

                    break;
                case State.Leave:

                    break;
            }
        }

        //methods
        public void setTarget(Vector3 tg)
        {
            target = tg;
        }
    }
}
