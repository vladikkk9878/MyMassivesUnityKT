using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentScript : MonoBehaviour
{
    [SerializeField] private RoomManager roomManager;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private Button roomButton;
    [SerializeField] private TMP_InputField roomNumber;
    [SerializeField] private TMP_InputField roomName;
    [SerializeField] private Toggle roomAnimal;
    [SerializeField] private Button roomClearButton;
    [SerializeField] private Button roomBorringMethodButton;

    private void Awake()
    {
        roomButton.onClick.AddListener(AddRoom);
        roomClearButton.onClick.AddListener(Clear);
        roomBorringMethodButton.onClick.AddListener(BorringMethod);
        UpdateRooms();
    }

    private void AddRoom()
    {
        Room nRoom = new Room(int.Parse(roomNumber.text), roomName.text, roomAnimal.isOn);
        roomManager.AddRoom(nRoom);
        UpdateRooms();
    }

    private void Clear()
    {
        
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        roomManager.rooms.Clear();
    }

    private void UpdateRooms()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Room room in roomManager.rooms)
        {
            GameObject rooma = Instantiate(roomPrefab, content.transform);
            if (rooma.TryGetComponent(out RoomPanelScript roomScript))
            {
                roomScript.Activator(room.roomID, room.roomName, room.animal);
            }
        }
    }

    private void BorringMethod()
    {
        int CountAnimals = 0;
        foreach (Room room in roomManager.rooms)
        {
            if (room.animal)
            {
                CountAnimals++;
            }
        }
        int CountSmith = 0;
        foreach (Room room in roomManager.rooms)
        {
            if (room.roomName == "Смит")
            {
                CountSmith++;
            }
        }
        int CountNums = 0;
        foreach (Room room in roomManager.rooms)
        {
            if (room.roomID <= 99 && room.roomID >= -99)
            {
                CountNums++;
            }
        }
        roomManager.ReverseSort();
        List<Room> delRoom = new List<Room>();
        for(int i = 0; i < roomManager.rooms.Count; i++)
        {
            if (roomManager.rooms[i].roomID % 3 == 0)
            {
                delRoom.Add(roomManager.rooms[i]);
            }
        }

        foreach (Room room in delRoom)
        {
            roomManager.rooms.Remove(room);
        }

        if (delRoom.Count != 0)
        {
            int lastAnimal = 0;
            Debug.Log(roomManager.rooms.Count);
            int minNum = roomManager.rooms[0].roomID;
            int minNumIndex = 0;
            for (int i = 0; i < roomManager.rooms.Count; i++)
            {
                if (roomManager.rooms[i].animal)
                {
                    lastAnimal = i;
                }
            }

            for (int i = 0; i < roomManager.rooms.Count; i++)
            {
                if (roomManager.rooms[i].roomID < minNum)
                {
                    minNum = roomManager.rooms[i].roomID;
                    minNumIndex = i;
                }
            }
            (roomManager.rooms[lastAnimal], roomManager.rooms[minNumIndex]) = (roomManager.rooms[minNumIndex], roomManager.rooms[lastAnimal]);
        }
            
        Debug.Log($"{CountAnimals}, {CountNums}, {CountSmith}");
        UpdateRooms();
    }
}
