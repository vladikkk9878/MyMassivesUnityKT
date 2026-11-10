using TMPro;
using UnityEngine;

public class RoomPanelScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roomNumber;
    [SerializeField] private TextMeshProUGUI roomName;
    [SerializeField] private TextMeshProUGUI roomAnimal;

    public void Activator(int number, string name, bool animal)
    {
        roomNumber.text = number.ToString();
        roomName.text = name;
        roomAnimal.text = animal.ToString();
    }
}
