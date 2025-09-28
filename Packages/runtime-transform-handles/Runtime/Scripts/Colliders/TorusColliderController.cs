using TransformHandles.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TransformHandles
{
    public class TorusColliderController : MonoBehaviour
    {
        [SerializeField] private int segmentCount = 32;
        [SerializeField] private int sideCount = 15;
        [SerializeField] private float radius;
        [SerializeField] private float thickness;

        [SerializeField] private Transform colliderTransform;

        private MeshCollider _meshCollider;
        private MeshFilter _meshFilter;

        private void Awake()
        {
            _meshCollider = colliderTransform.GetComponent<MeshCollider>();
            _meshFilter = colliderTransform.GetComponent<MeshFilter>();
        }

        private void Start()
        {
            UpdateCollider();
        }

        private void Update()
        {
            if (Keyboard.current[Key.K].wasPressedThisFrame)
            {
                UpdateCollider();
            }
        }

        private void UpdateCollider()
        {
            var newMesh = MeshUtils.CreateTorus(radius, thickness, segmentCount, sideCount);
            newMesh.name = "torus";

            _meshFilter.sharedMesh = newMesh;
            _meshCollider.sharedMesh = newMesh;

            /*
			AssetDatabase.CreateAsset(newMesh, "Assets/torus.asset");
			*/
        }
    }
}