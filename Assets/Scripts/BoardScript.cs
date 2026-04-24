using UnityEngine;

public class ChessboardGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // Drag a square/cube prefab here
    public Material lightMaterial;
    public Material darkMaterial;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject tile = Instantiate(tilePrefab);
                tile.transform.position = new Vector3(x, 0, y);
                bool isOffset = (x + y) % 2 == 1;
                tile.GetComponent<Renderer>().material = isOffset ? darkMaterial : lightMaterial;

                tile.name = $"Tile ({x}, {y})";
            }
}
    }
}
