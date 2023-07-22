using UnityEngine;

namespace Grid_Scene.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private GameObject highLight;
        private void OnMouseEnter()
        {
            highLight.SetActive(true);
        }
    
        private void OnMouseExit()
        {
            highLight.SetActive(false);
        }
    }
}
