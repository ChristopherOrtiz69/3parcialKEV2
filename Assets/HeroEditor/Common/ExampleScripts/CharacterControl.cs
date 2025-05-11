using UnityEngine;
using Assets.HeroEditor.Common.CharacterScripts;

namespace Assets.HeroEditor.Common.ExampleScripts
{
   
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Character))]
    public class CharacterControl : MonoBehaviour
    {
        public float moveSpeed = 3.5f;
        public KeyCode upKey = KeyCode.W;
        public KeyCode downKey = KeyCode.S;
        public KeyCode leftKey = KeyCode.A;
        public KeyCode rightKey = KeyCode.D;

        private Character _character;
        private Rigidbody _rb;
        private Vector2 _input;

        void Start()
        {
            // Obtener referencias
            _character = GetComponent<Character>();
            _rb = GetComponent<Rigidbody>();

            // Validaciones
            if (_character == null)
                Debug.LogError("El componente 'Character' no se ha encontrado.");
            if (_rb == null)
                Debug.LogError("El componente 'Rigidbody' no se ha encontrado.");

           
            _rb.useGravity = false;

            // Activar animación inicial
            _character.Animator.SetBool("Ready", true);
        }

        void Update()
        {
            // Leer input
            _input = Vector2.zero;

            if (Input.GetKey(upKey)) _input.y += 1;
            if (Input.GetKey(downKey)) _input.y -= 1;
            if (Input.GetKey(leftKey)) _input.x -= 1;
            if (Input.GetKey(rightKey)) _input.x += 1;

            // Animaciones
            if (_character != null)
            {
                _character.Animator.SetBool("Run", _input != Vector2.zero);

                if (_input.x != 0)
                    transform.localScale = new Vector3(Mathf.Sign(_input.x), 1, 1);
            }
        }

        void FixedUpdate()
        {
            if (_rb != null && _input != Vector2.zero)
            {
                // Movimiento en el plano X-Y (2D)
                Vector3 direction = new Vector3(_input.x, _input.y, 0).normalized;
                _rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
            }
        }

    }
}
