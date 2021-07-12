
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Square : MonoBehaviour
{
    #region --- helpers ---
    private enum enumToggle
    {
        All,
        Triangle1,
        Triangle2,
    }
    #endregion

    private enumToggle code = enumToggle.All;

    private void Update()
    {
        CreateMeshSquare();
    }
    public void ResetObjects()
    {
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;

        //triangle 1
        this.transform.GetChild(0).transform.position = new Vector3(0, 0, 0);
        this.transform.GetChild(1).transform.position = new Vector3(0, 0, 1);
        this.transform.GetChild(2).transform.position = new Vector3(1, 0, 0);
        //triangle 2
        this.transform.GetChild(3).transform.position = new Vector3(1, 0, 0);
        this.transform.GetChild(4).transform.position = new Vector3(0, 0, 1);
        this.transform.GetChild(5).transform.position = new Vector3(1, 0, 1);

        CreateMeshSquare();
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
    public void CreateMeshSquare()
    {
        Mesh mesh = getMeshObject();

        //clear
        mesh.Clear();

        //vertices
        mesh.vertices = new Vector3[]
        {
            this.transform.GetChild(0).transform.position
            , this.transform.GetChild(1).transform.position
            , this.transform.GetChild(2).transform.position
            , this.transform.GetChild(3).transform.position
            , this.transform.GetChild(4).transform.position
            , this.transform.GetChild(5).transform.position
        };

        //triangles
        mesh.triangles = new int[] { 0, 1, 2, 3, 1, 5};

        //lighting
        mesh.RecalculateNormals();

        //uv (for texture)
        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0)
            , new Vector2(0, 1)
            , new Vector2(1, 0) //triangle 1 points
            , new Vector2(1, 0)
            , new Vector2(0, 1)
            , new Vector2(1, 1) //triangle 2 points
        };
    }
    public void TogglePoints()
    {
        switch (code)
        {
            case enumToggle.All:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(4).gameObject.SetActive(true);
                this.transform.GetChild(5).gameObject.SetActive(true);
                code = enumToggle.Triangle1;
                break;
            case enumToggle.Triangle1:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                this.transform.GetChild(5).gameObject.SetActive(false);
                code = enumToggle.Triangle2;
                break;
            case enumToggle.Triangle2:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(4).gameObject.SetActive(true);
                this.transform.GetChild(5).gameObject.SetActive(true);
                code = enumToggle.All;
                break;
        }
    }
}
