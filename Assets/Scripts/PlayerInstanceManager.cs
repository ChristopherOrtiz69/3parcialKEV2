using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInstanceManager : MonoBehaviour
{
    public string sceneToLoad = "CharacterEditor [MH]";
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(player); // ?? Eliminar el player actual
            SceneManager.LoadScene(sceneToLoad); // Luego cambiar de escena
        }
    }
}