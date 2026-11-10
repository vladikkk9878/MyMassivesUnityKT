using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [field:SerializeField] public List<Room> rooms { get; private set; } = new List<Room>();
    public void AddRoom(Room _room)
    {
        rooms.Add(_room);
    }
    public void RemoveRoom(Room _room)
    {
        rooms.Remove(_room);
    }

    public void ReverseSort()
    {
        rooms.Reverse();
    }
}
[Serializable]
public class Room
{
    public int roomID;
    public string roomName;
    public bool animal;

    public Room(int _roomID, string _roomName, bool _animal)
    {
        roomID = _roomID;
        roomName = _roomName;
        animal = _animal;
    }
}
