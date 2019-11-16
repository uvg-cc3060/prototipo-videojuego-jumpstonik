using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    [Header("SpawnZones")]
    public GameObject SpawnZoneSkeletons;
    public GameObject SpawnZoneGolem;
    public GameObject SpawnZoneFlyer;
    private GameObject zone;
    Vector3 height = new Vector3 (0,15.0f,0);

    [Header("Decorations")]
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock5;
    public GameObject rock6;
    public GameObject rock7;
    public GameObject rock8;
    public GameObject aloe;
    public GameObject cactus1;
    public GameObject cactus2;
    public GameObject cactus3;
    public GameObject deco;

    [Header("niebla")]
    public GameObject niebla;

    [Header("Mesh_&_Info")]
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    public int xSize = 0;
    public int zSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        meshc.sharedMesh = mesh; // Give it your mesh here
        
        height.x = transform.position.x + 45;
        height.z = transform.position.z + 20;
        Instantiate(niebla, height, transform.rotation);
        Instantiate(niebla, height, transform.rotation);
        Instantiate(niebla, height, transform.rotation);
        //height.x = transform.position.x - 2;
        //height.z = transform.position.z - 2;
        
        SpawnDecoration();
        GenerateSpawnZones();

        gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();

        //mesh.Build
        //UpdateMesh();
        //OnDrawGizmos();
    }

    void CreateShape()
    {
        xSize = Random.Range(70, 100);
        zSize = Random.Range(50, 60);
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                //vertices[i] = new Vector3(x + transform.position.x, transform.position.y, z + transform.position.z);
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                //yield return new WaitForSeconds(.03f);
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    void SpawnDecoration()
    {
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                if (x > 7 && x < xSize - 7 && z > 7 && z < zSize - 7)
                {
                    int q = Random.Range(0, 1000);
                    if (q > 500 && q < 520)
                    {
                        int v = Random.Range(1, 200);
                        if (v >=0 && v<=25)
                        {
                            deco = rock1 ;
                        }
                        else if (v >=26 && v <=50)
                        {
                            deco = rock2;
                        }
                        else if (v >=51 && v <=70)
                        {
                            deco = rock3;
                        }
                        else if (v >= 71 && v <=85)
                        {
                            deco = rock4;
                        }
                        else if (v >=86 && v <=100)
                        {
                            deco = rock5;
                        }
                        else if (v >= 101 && v <=115)
                        {
                            deco = rock6;
                        }
                        else if (v >= 116 && v <= 130)
                        {
                            deco = rock7;
                        }
                        else if (v >= 131 && v <=145)
                        {
                            deco = rock8;
                        }
                        else if (v >= 146 && v <= 160)
                        {
                            deco = cactus1;
                        }
                        else if (v >= 161 && v <= 175)
                        {
                            deco = cactus2;
                        }
                        else if (v >= 176 && v <=190)
                        {
                            deco = cactus3;
                        }
                        else if (v >=191 && v <=200)
                        {
                            deco = aloe;
                        }
                        height.x = x + 10;
                        height.z = z;
                        Quaternion rot = new Quaternion(0, Random.Range(-360, 360), 0, 0);
                        Instantiate(deco, height, rot);
                    }
                }
            }
        }
    }

    void GenerateSpawnZones()
    {
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                if (x > 10 && x < xSize - 10 && z > 10 && z < zSize - 10)
                {
                    int q = Random.Range(0, 1000); 
                    if (q > 501 && q < 510)
                    {
                        int v = Random.Range(1, 100);


                        if (v > 0 && v < 15)
                        {
                            zone = SpawnZoneGolem;
                        }
                        else if (v > 14 && v < 65)
                        {
                            zone = SpawnZoneSkeletons;
                        }
                        else if (v > 64 && v < 101)
                        {
                            zone = SpawnZoneFlyer;
                        }
                        height.x = x;
                        height.z = z;
                        height.y = 8;
                        Instantiate(zone, height, transform.rotation);
                    }
                }
            }
        }
    }
}
