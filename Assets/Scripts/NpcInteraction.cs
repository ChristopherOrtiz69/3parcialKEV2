using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcInteraction : MonoBehaviour
{
    public string sceneToLoad = "CharacterEditor [MH] 1";
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRadius = 2f;
    private GameObject player;

    void Start()
    {
        // Asume que el jugador tiene la etiqueta "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("No se encontró un GameObject con la etiqueta 'Player'. Asegúrate de que tu personaje tenga esta etiqueta.");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= interactionRadius && Input.GetKeyDown(interactionKey))
        {
            Debug.Log("Interacción con NPC: Cargando escena " + sceneToLoad);

            // Destruir el jugador antes de cargar la nueva escena
            Destroy(player);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el radio de interacción en la escena para depuración
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
