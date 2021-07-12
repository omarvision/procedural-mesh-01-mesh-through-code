using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Cube : MonoBehaviour
{
    private void Start()
    {
        CreateMeshCube(Vector3.zero);
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
    public void Clear()
    {
        Mesh mesh = getMeshObject();
        mesh.Clear();
    }
    public void CreateMeshCube(Vector3 pos)
    {
        //Note: 6 sides * 4 vertices per side = 24 vertices
        //      since we are sharing vertices, we only need 8 vertices

        float d = 0.5f;

        Mesh mesh = getMeshObject();
        mesh.Clear();
        
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-d, d, d)
            , new Vector3(-d, -d, d)
            , new Vector3(d, d, d)
            , new Vector3(d, -d, d)  //far quad

            , new Vector3(-d, d, -d)
            , new Vector3(-d, -d, -d)
            , new Vector3(d, d, -d)
            , new Vector3(d, -d, -d) //close quad
        };


        int[] triangles = new int[]
        {
            0,1,2
            ,2,1,3  //far
            ,4,6,5
            ,5,6,7  //close

            ,0,2,4
            ,4,2,6  //top
            ,1,5,3
            ,3,5,7  //bottom

            ,0,4,1
            ,1,4,5  //left
            ,2,3,6
            ,6,3,7  //right
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    public void CreateMeshCube2(Vector3 position)
    {
        float N = -0.5f;
        float P = 0.5f;
        float neg = -0.5f;
        float pos = 0.5f;

        Mesh mesh = getMeshObject();
        mesh.Clear();

        Vector3[] vertices = new Vector3[]          // 4 per side * 6 sides = 24
        {
            //Z axis
            new Vector3(neg, neg, N) + position,    //0
            new Vector3(neg, pos, N) + position,    //1 
            new Vector3(pos, pos, N) + position,    //2
            new Vector3(pos, neg, N) + position,    //3 (near(-) side)
            new Vector3(neg, neg, P) + position,    //4
            new Vector3(neg, pos, P) + position,    //5
            new Vector3(pos, pos, P) + position,    //6
            new Vector3(pos, neg, P) + position,    //7 (far(+) side)

            //X axis
            new Vector3(N, neg, neg) + position,    //8
            new Vector3(N, neg, pos) + position,    //9
            new Vector3(N, pos, pos) + position,    //10
            new Vector3(N, pos, neg) + position,    //11 (left(-) side)
            new Vector3(P, neg, neg) + position,    //12
            new Vector3(P, neg, pos) + position,    //13
            new Vector3(P, pos, pos) + position,    //14
            new Vector3(P, pos, neg) + position,    //15 (right(+) side)

            //Y axis bottom, top
            new Vector3(neg, N, pos) + position,    //16
            new Vector3(neg, N, neg) + position,    //17
            new Vector3(pos, N, neg) + position,    //18
            new Vector3(pos, N, pos) + position,    //19 (bottom(-) side)
            new Vector3(neg, P, pos) + position,    //20
            new Vector3(neg, P, neg) + position,    //21
            new Vector3(pos, P, neg) + position,    //22
            new Vector3(pos, P, pos) + position,    //23 (top(-) side)
        };


        int[] triangles = new int[] // 6 per side * 6 sides = 36
        {
            0,1,2,
            2,3,0,      //far
            7,6,5,
            5,4,7,      //near

            8,9,10,
            10,11,8,    //left
            15,14,13,
            13,12,15,   //right

            16,17,18,
            18,19,16,   //bottom
            21,20,23,
            23,22,21,   //top
        };

        Vector2[] uv = new Vector2[] //count of uv has to match count of vertices
        {
            new Vector2(0.00f, 0.33f),
            new Vector2(0.00f, 0.66f),
            new Vector2(0.25f, 0.66f),
            new Vector2(0.25f, 0.33f),  //near side
            new Vector2(0.50f, 0.33f),
            new Vector2(0.75f, 0.33f),
            new Vector2(0.75f, 0.66f),
            new Vector2(0.50f, 0.66f),  //far side

            new Vector2(0.25f, 0.33f),
            new Vector2(0.25f, 0.66f),
            new Vector2(0.50f, 0.66f),
            new Vector2(0.50f, 0.33f),  //left side
            new Vector2(0.75f, 0.66f),
            new Vector2(0.75f, 0.33f),
            new Vector2(1.00f, 0.33f),
            new Vector2(1.00f, 0.66f),  //right side

            new Vector2(0.25f, 0.66f),
            new Vector2(0.25f, 1.00f),
            new Vector2(0.50f, 1.00f),
            new Vector2(0.50f, 0.66f),  //bottom side
            new Vector2(0.25f, 0.33f),
            new Vector2(0.25f, 0.00f),
            new Vector2(0.50f, 0.00f),
            new Vector2(0.50f, 0.33f),  //top side
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
    }
}
