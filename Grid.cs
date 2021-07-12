using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int sizeX = 3;
    public int sizeZ = 3;
    public float cell = 1.0f;

    private void Start()
    {
        CreateMeshGrid();
    }
    private Mesh getMeshObject()
    {
        Mesh mesh = null;
        if (Application.isEditor)
        {
            mesh = this.GetComponent<MeshFilter>().sharedMesh;
        }
        else
        {
            mesh = this.GetComponent<MeshFilter>().mesh;
        }

        if (mesh == null)
        {
            mesh = new Mesh();
            this.GetComponent<MeshFilter>().mesh = mesh;
        }
        
        return mesh;
    }
    public void CreateMeshGrid()
    {
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
        this.transform.localScale = new Vector3(1, 1, 1);

        Mesh mesh = getMeshObject();
        mesh.Clear();
        
        Vector3[] vertices = new Vector3[2 * 3 * (sizeX * sizeZ)]; //2 triangles, 3 vertices each = 6
        int[] triangles = new int[2 * 3 * (sizeX * sizeZ)];
        Vector2[] uv = new Vector2[2 * 3 * (sizeX * sizeZ)];

        int whichQuad = 0;
        for (int xCoord = 0; xCoord < sizeX; xCoord++)
        {
            for (int zCoord = 0; zCoord < sizeZ; zCoord++)
            {
                float x = xCoord * cell;
                float z = zCoord * cell;
                
                vertices[whichQuad + 0] = new Vector3(x, 0, z);
                vertices[whichQuad + 1] = new Vector3(x, 0, z + cell);
                vertices[whichQuad + 2] = new Vector3(x + cell, 0, z);          //triangle 1                
                vertices[whichQuad + 3] = new Vector3(x + cell, 0, z);
                vertices[whichQuad + 4] = new Vector3(x, 0, z + cell);
                vertices[whichQuad + 5] = new Vector3(x + cell, 0, z + cell);   //triangle 2

                triangles[whichQuad] = whichQuad;
                triangles[whichQuad + 1] = whichQuad + 1;
                triangles[whichQuad + 2] = whichQuad + 2;
                triangles[whichQuad + 3] = whichQuad + 3;
                triangles[whichQuad + 4] = whichQuad + 4;
                triangles[whichQuad + 5] = whichQuad + 5;

                uv[whichQuad] = new Vector2(0, 0);
                uv[whichQuad + 1] = new Vector2(0, 1);
                uv[whichQuad + 2] = new Vector2(1, 0); //triangle 1 points
                uv[whichQuad + 3] = new Vector2(1, 0);
                uv[whichQuad + 4] = new Vector2(0, 1);
                uv[whichQuad + 5] = new Vector2(1, 1); //triangle 2 points

                whichQuad += 6;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
    }
}
