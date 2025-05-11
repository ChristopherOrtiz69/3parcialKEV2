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
            Debug.LogWarning("�ndice fuera de rango o el objeto no est� asignado.");
        }
    }
}