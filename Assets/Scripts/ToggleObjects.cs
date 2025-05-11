using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    [Header("Lista de objetos a activar")]
    public GameObject[] objectsToActivate;

    public void ActivateByIndex(int index)
    {
        if (index >= 0 && index < objectsToActivate.Length && objectsToActivate[index] != null)
        {
            objectsToActivate[index].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Índice fuera de rango o el objeto no está asignado.");
        }
    }
}