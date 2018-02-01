using System.Linq;
using UnityEngine;

public class parthenonBuilder : MonoBehaviour
{
    public GameObject CubePrefab;
    public GameObject CylinderPrefab;
    public float FloorWidth = 5.0f;
    public float FloorDepth = 10.0f;
    public float FloorHeight = 0.25f;
    public float PillarRadius = 0.2f;
    public float PillarHeight = 2f;
    public int PillarCountWidth = 6;
    public int PillarCountDepth = 10;
    public float RoofHeight = 1f;
    public Material FloorMaterial;
    public Material PillarMaterial;
    public Material RoofMaterail;

    [ContextMenu("build")]
    void Build()
    {
        DestroyAllChildren();

        var floor1 = Instantiate(CubePrefab, GetComponent<Transform>());
        floor1.transform.localPosition = new Vector3(0, 0, 0);
        floor1.transform.localScale = new Vector3(FloorWidth, FloorHeight, FloorDepth);

        var floor2 = Instantiate(CubePrefab, transform);
        floor2.transform.localPosition = new Vector3(0, FloorHeight, 0);
        floor2.transform.localScale = new Vector3(FloorWidth * 0.9f, FloorHeight, FloorDepth * 0.9f);

        var floor3 = Instantiate(CubePrefab, transform);
        floor3.transform.localPosition = new Vector3(0, FloorHeight * 2, 0);
        floor3.transform.localScale = new Vector3(FloorWidth * 0.81f, FloorHeight, FloorDepth * 0.81f);

        // Pillar at Width
        for (int i = 1; i <= PillarCountWidth; i++)
        {
            var ColumnWidth1 = Instantiate(CylinderPrefab, transform);



            ColumnWidth1.transform.localPosition = new Vector3(FloorWidth * 0.81f / 2 - PillarRadius / 2 - (FloorWidth * 0.81f - PillarRadius) / (PillarCountWidth - 1) * (i - 1), FloorHeight * 3, -((FloorDepth * 0.81f / 2) - PillarRadius / 2));

            ColumnWidth1.transform.localScale = new Vector3(PillarRadius, PillarHeight, PillarRadius);

            var ColumnWidth2 = Instantiate(CylinderPrefab, transform);

            ColumnWidth2.transform.localPosition = new Vector3(FloorWidth * 0.81f / 2 - PillarRadius / 2 - (FloorWidth * 0.81f - PillarRadius) / (PillarCountWidth - 1) * (i - 1), FloorHeight * 3, (FloorDepth * 0.81f / 2) - PillarRadius / 2);

            ColumnWidth2.transform.localScale = new Vector3(PillarRadius, PillarHeight, PillarRadius);

        }
        // Pillar at Depth
        for (int i=2; i<= PillarCountDepth; i++)
        {
            var ColumnDepth1 = Instantiate(CylinderPrefab, transform);
            ColumnDepth1.transform.localPosition = new Vector3(FloorWidth * 0.81f / 2 - PillarRadius / 2, FloorHeight * 3, FloorDepth * 0.81f / 2 - PillarRadius / 2 - (FloorDepth * 0.81f - PillarRadius) / (PillarCountDepth - 1) * (i - 1));
            ColumnDepth1.transform.localScale = new Vector3(PillarRadius, PillarHeight, PillarRadius);

            var ColumnDepth2 = Instantiate(CylinderPrefab, transform);
            ColumnDepth2.transform.localPosition = new Vector3(-(FloorWidth * 0.81f / 2 - PillarRadius / 2), FloorHeight * 3, FloorDepth * 0.81f / 2 - PillarRadius / 2 - (FloorDepth * 0.81f - PillarRadius) / (PillarCountDepth - 1) * (i - 1));
            ColumnDepth2.transform.localScale = new Vector3(PillarRadius, PillarHeight, PillarRadius);
        }

        //Roof
        var Roof = Instantiate(CubePrefab, transform);
        Roof.transform.localPosition = new Vector3(0, FloorHeight * 3 + PillarHeight, 0);
        Roof.transform.localScale = new Vector3(FloorWidth * 0.81f, RoofHeight, FloorDepth * 0.81f);


    }

    [ContextMenu("Destroy All Children")]
    void DestroyAllChildren()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }
    }
}

