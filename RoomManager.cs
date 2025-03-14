using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    public GameObject mmRoomPrefab;
    private Dungeon theDungeon;
    private GameObject NRoom;
    private GameObject NRoom2;
    private GameObject ERoom;
    private GameObject SRoom;
    private GameObject WRoom;
    private int moveNCount = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.setupRoom();
    }

    //disable all doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    // Update is called once per frame
    void Update()
    {
        bool didChangeRoom = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (moveNCount < 2)
            {
                //try to goto the north
                didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");

                if (didChangeRoom == true && NRoom == null && moveNCount == 0)
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    NRoom = newMMRoom;
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + 1.2f;
                    newMMRoom.transform.position = newPos;
                    moveNCount++;

                }
                else if (didChangeRoom == true && NRoom2 == null && moveNCount == 1)
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    NRoom2 = newMMRoom;
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + 2.4f;
                    newMMRoom.transform.position = newPos;
                    moveNCount++;

                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //try to goto the west
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            if (didChangeRoom == true && WRoom == null)
            {
                GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                WRoom = newMMRoom;
                Vector3 currPos = newMMRoom.transform.position;
                Vector3 newPos;
                newPos.x = currPos.x - 1.2f;
                newPos.y = currPos.y;
                newPos.z = currPos.z;
                newMMRoom.transform.position = newPos;
                moveNCount = 0;

            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //try to goto the east
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            if (didChangeRoom == true && ERoom == null)
            {
                GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                ERoom = newMMRoom;
                Vector3 currPos = newMMRoom.transform.position;
                Vector3 newPos;
                newPos.x = currPos.x + 1.2f;
                newPos.y = currPos.y;
                newPos.z = currPos.z;
                newMMRoom.transform.position = newPos;
                moveNCount = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //try to goto the south
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            if (didChangeRoom == true && SRoom == null)
            { 
                GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                SRoom = newMMRoom;
                Vector3 currPos = newMMRoom.transform.position;
                Vector3 newPos;
                newPos.x = currPos.x;
                newPos.y = currPos.y;
                newPos.z = currPos.z - 1.2f;
                newMMRoom.transform.position = newPos;
                moveNCount = 0;
            }
        }
        //did we change rooms?
        if (didChangeRoom)
        {
            this.setupRoom();
        }
    }
}