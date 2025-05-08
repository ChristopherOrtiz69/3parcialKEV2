using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.HeroEditor.Common.CharacterScripts; // Asegúrate que tenga esta referencia

namespace Assets.HeroEditor.Common.ExampleScripts
{
    public class TestRoom : MonoBehaviour
    {
        public string ReturnSceneName;

        private void Awake()
        {
            Physics.gravity = new Vector3(0, -12.5f, 0);
            Physics.defaultSolverIterations = 8;
            Physics.defaultSolverVelocityIterations = 2;

            SetupCameraFollow();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                if (UnityEditor.EditorBuildSettings.scenes.All(i => !i.path.Contains(ReturnSceneName)))
                {
                    throw new Exception(" " + ReturnSceneName);
                }
#endif
                SceneManager.LoadScene(ReturnSceneName);
            }
        }

        private void SetupCameraFollow()
        {
            var player = FindObjectOfType<Character>();
            var cam = Camera.main;

            if (player != null && cam != null)
            {
                var follow = cam.GetComponent<FollowTarget>();
                if (follow == null) follow = cam.gameObject.AddComponent<FollowTarget>();
                follow.target = player.transform;
            }
            else
            {
                Debug.LogWarning("Player or Camera not found for camera follow setup.");
            }
        }
    }
}
