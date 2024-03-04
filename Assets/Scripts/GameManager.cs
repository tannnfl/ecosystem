using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

namespace MyGame
{

    public class GameManager : MonoBehaviour
    {
        public GameObject customerPrefab;
        public GameObject staffPrefab;

        //get colliders
        GameObject entrance;

        //people counter
        int customerCount;
        int staffCount;

        //timer
        public float countdownTime;
        float timer;//seconds

        //positions
        Vector3 frontdesk = new Vector3(-2, 1, -9);

        //lines
        List<GameObject> Order = new List<GameObject>();
        List<GameObject> Wait = new List<GameObject>();
        Vector3 orderStartPosition = new Vector3(-1.53f, 0, 0);
        Vector3 orderEndPosition = new Vector3(4, 2, 0);

        //customer
        Customer customer;

        void Start()
        {
            timer = countdownTime;
            entrance = GameObject.Find("EntranceCollider");
            customer = FindObjectOfType<Customer>();
        }

        void Update()
        {
            /*
             * Staff Behavior Control:
             * Leave(Destroy):
             *      If work for more than 2 hr;
             *      If no work to do for more than 0.25 hr;
             *      /If waiting customers amount > coffee maker staff * 1.5; 
             *      /If sitting customers amount > cleaning staff * 3;
             * Respawn(Create):
             *      If Staff < 0;
             *      /If waiting customers amount > coffee maker staff * 1.5; 
             *      /If sitting customers amount > cleaning staff * 3;
            */

            /*
             * Customer Behavior Control:
             * Enter(Create):
             *      Random; (Higher possibility when afternoon)
             */


            //Spawn Staff
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                print("Spawn");
                timer = countdownTime;
                Vector3 pos = entrance.GetComponent<Transform>().position;
                SpawnCustomer(pos);
            }

            //Order Line manager
            for (int i = 0; i < Order.Count; i++)
            {

            }
        }


        // Spawn Method
        public void SpawnCustomer(Vector3 position)
        {
            Instantiate(customerPrefab, position, Quaternion.identity);
            customerCount++;
        }
        public void SpawnStaff(Vector3 position)
        {
            Instantiate(staffPrefab, position, Quaternion.identity);
            customerCount++;
        }

        // Destroy Method
        public void DestroyCustomer(GameObject obj)
        {
            Destroy(obj);
            customerCount--;
        }
        public void DestroyStaff(GameObject obj)
        {
            Destroy(obj);
            staffCount--;
        }

        // Front Desk Method
        public Vector3 getFrontDeskPosition()
        {
            return frontdesk;
        }

        // Line Method
        public int addToOrderLine(GameObject obj)
        {
            Order.Add(obj);
            return Order.Count - 1;
        }
        public int getOrderLineCount()
        {
            return Order.Count - 1;
        }
        public int addToWaitLine(GameObject obj)
        {
            Wait.Enqueue(obj);
            return Wait.Count - 1;
        }
        public int getWaitLineCount()
        {
            return Wait.Count - 1;
        }
    }
}