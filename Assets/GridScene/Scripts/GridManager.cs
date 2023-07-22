using System;
using UnityEngine;

namespace Grid_Scene.Scripts
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int width, height;
        [SerializeField] private Tile tile;
        [SerializeField] private Color onColor;
        [SerializeField] private Color offColor;

        private readonly Vector3 offset = new (0.5f, 0.5f, 0);
        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.current == null ? Camera.main : Camera.current;
        }

        private void Start()
        {
            GenerateGrid();
        }

        #region Methods

        void GenerateGrid()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var spawnedTile = Instantiate(tile, new Vector3(i, j, 0) + offset, Quaternion.identity);
                    spawnedTile.name = $"Tile {i},{j}";
                    // move base/off color code to Tile Script later
                    var sr = spawnedTile.GetComponent<SpriteRenderer>();
                    sr.color = (i + j) % 2 == 0 ? onColor : offColor;
                }
            }

            _cam.transform.position = new Vector3((float)width / 2, (float)height / 2, -10);
        }

        #endregion
    }
}
