using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkinnedMeshBonesData : MonoBehaviour
{
    public string rootBone = "";
    public string[] bones;

    /*
    public Transform root;


    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (root != null)
            {
                SkinnedMeshRenderer smr = transform.GetComponent<SkinnedMeshRenderer>();
                Dictionary<string, Transform> dict = new Dictionary<string, Transform>();
                Debug.Log("start script");



                Transform[] existingTrans = root.GetComponentsInChildren<Transform>(false);

                for (int q = 0; q < existingTrans.Length; q++)
                {
                    dict.Add(existingTrans[q].name, existingTrans[q]);

                    if (existingTrans[q].name.Equals(rootBone))
                        smr.rootBone = existingTrans[q];
                }


                Transform[] bonessss = new Transform[bones.Length];

                for (int q = 0; q < bones.Length; q++)
                {
                    if (dict.ContainsKey(bones[q]))
                    {
                        bonessss[q] = dict[bones[q]];
                        //Debug.Log(bones[q], dict[bones[q]]);
                    }
                    else
                        Debug.LogError("!dict.ContainsKey(bones[q]) = " + bones[q]);
                }

                smr.bones = bonessss;

                if (smr.rootBone == null)
                    Debug.LogError("no rootBone!", this);
            }
            else
                Debug.LogError("no root!", this);
        }
    }*/
}
