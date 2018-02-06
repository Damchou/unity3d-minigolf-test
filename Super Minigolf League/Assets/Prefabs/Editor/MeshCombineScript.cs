using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombineScript : ScriptableWizard {

    public GameObject meshToCombine;
    
    [MenuItem ("Mesh Combine/Combine Meshes")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Combine Mesh", typeof(MeshCombineScript));
    }

    void OnWizardCreate()
    {
      if (meshToCombine != null)
        {
            MeshFilter[] meshFilters = meshToCombine.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            List<Material> mats = new List<Material>();

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                //meshFilters[i].gameObject.active = false;
                Material mat = meshFilters[i].gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                if (!mats.Contains(mat)) 
                    mats.Add(mat);
                i++;
            }
            /*
            GameObject combinedObject = new GameObject("CombinedMesh");
            Mesh combinedMesh = new Mesh();
            combinedMesh.CombineMeshes(combine, (mats.Count > 1));
            AssetDatabase.CreateAsset(combinedMesh, "Assets/MeshData/Combined.asset");

            MeshFilter filter = combinedObject.AddComponent<MeshFilter>();
            filter.mesh = AssetDatabase.LoadAssetAtPath("Assets/MeshData/Combined.asset") as Mesh;
            MeshRenderer renderer = combinedObject.AddComponent("MeshRenderer");
            renderer.sharedMateriqls = mats.ToArray();
            combinedObject.GetComponent<MeshFilter>().sharedMesh.;


            Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/" + "CombinedObject" + ".prefab");
            PrefabUtility.ReplacePrefab(combinedObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
            */

        }  
    }

}
