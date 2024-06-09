using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class CharacterModelsCore : MonoBehaviour
{

    public GameObject[] shirts;
    public CharacterModelsParts_Info[] shirts_info;
    public GameObject[] pants;
    public GameObject[] boots;
    public GameObject[] helmets;
    public CharacterModelsParts_Info[] helmets_info;
    public GameObject[] backpacks;
    public GameObject[] vests;



    public GameObject[] heads;
    public CharacterModelsParts_Info[] heads_info;
    public GameObject[] hands;
    public GameObject[] foots;


    bool current_is_black_character;
    public int current_shirt;
    public int current_pant;
    public int current_boots;
    public int current_helmet;
    public int current_backpack;
    public int current_vest;
    public int current_head;


    bool star_is_black_character = true;
    int star_shirt = -2;
    int star_pant = -2;
    int star_boots = -2;
    int star_helmet = -2;
    int star_backpack = -2;
    int star_vest = -2;
    int star_head = -2;


    GameObject current_go_shirt;
    GameObject current_go_pant;
    GameObject current_go_boots;
    GameObject current_go_helmet;
    GameObject current_go_backpack;
    GameObject current_go_vest;
    GameObject current_go_head;
    GameObject current_go_hands;
    GameObject current_go_foots;



    public Transform root;



    Dictionary<string, Transform> dictBones = new Dictionary<string, Transform>();



    [Serializable]
    public class CharacterModelsParts_Info
    {
        public bool shirts_is_short;
        public bool helmets_is_replace_head;
        public bool heads_is_black;
    }


    void Start()
    {
        SetCharacterParts(UnityEngine.Random.Range(0, shirts.Length), UnityEngine.Random.Range(0, pants.Length), UnityEngine.Random.Range(-1, boots.Length), 
            UnityEngine.Random.Range(-1, helmets.Length), UnityEngine.Random.Range(-1, backpacks.Length), UnityEngine.Random.Range(-1, vests.Length), 
            UnityEngine.Random.Range(0, heads.Length));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetCharacterParts(UnityEngine.Random.Range(0, shirts.Length), UnityEngine.Random.Range(0, pants.Length), UnityEngine.Random.Range(-1, boots.Length),
                UnityEngine.Random.Range(-1, helmets.Length), UnityEngine.Random.Range(-1, backpacks.Length), UnityEngine.Random.Range(-1, vests.Length),
                UnityEngine.Random.Range(0, heads.Length));
        }
    }


    void InitParams()
    {
        current_shirt = Mathf.Clamp(current_shirt, 0, shirts.Length);
        current_pant = Mathf.Clamp(current_pant, 0, pants.Length);
        current_boots = Mathf.Clamp(current_boots, -1, boots.Length);
        current_helmet = Mathf.Clamp(current_helmet, -1, helmets.Length);
        current_backpack = Mathf.Clamp(current_backpack, -1, backpacks.Length);
        current_vest = Mathf.Clamp(current_vest, -1, vests.Length);
        current_head = Mathf.Clamp(current_head, 0, heads.Length);

        if(dictBones.Count == 0)
        {
            Transform[] existingTrans2 = root.GetComponentsInChildren<Transform>(false);

            for (int q = 0; q < existingTrans2.Length; q++)
            {
                dictBones.Add(existingTrans2[q].name, existingTrans2[q]);
            }
        }
        
        current_is_black_character = heads_info[current_head].heads_is_black;

        int tempInt = 0;

        if (current_shirt != star_shirt || current_is_black_character != star_is_black_character)
        {
            if (current_go_shirt != null)
                Destroy(current_go_shirt);
            if (current_go_hands != null)
                Destroy(current_go_hands);

            if(!current_is_black_character)
            {
                if (!shirts_info[current_shirt].shirts_is_short)
                    tempInt = 2;
                else
                    tempInt = 0;
            }
            else
            {
                if (!shirts_info[current_shirt].shirts_is_short)
                    tempInt = 3;
                else
                    tempInt = 1;
            }


            current_go_shirt = Instantiate(shirts[current_shirt], transform);
            FixSkinnedMesh(current_go_shirt);
            current_go_hands = Instantiate(hands[tempInt], transform);
            FixSkinnedMesh(current_go_hands);

            star_shirt = current_shirt;
        }

        if (current_pant != star_pant)
        {
            if (current_go_pant != null)
                Destroy(current_go_pant);

            current_go_pant = Instantiate(pants[current_pant], transform);
            FixSkinnedMesh(current_go_pant);

            star_pant = current_pant;
        }

        if (current_boots != star_boots || current_is_black_character != star_is_black_character)
        {
            if (current_go_boots != null)
                Destroy(current_go_boots);
            if (current_go_foots != null)
                Destroy(current_go_foots);

            if (current_boots != -1)
            {
                current_go_boots = Instantiate(boots[current_boots], transform);
                FixSkinnedMesh(current_go_boots);
            }
            else
            {
                current_go_foots = Instantiate(foots[current_is_black_character ? 1 : 0], transform);
                FixSkinnedMesh(current_go_foots);
            }

            star_boots = current_boots;
        }

        if (current_helmet != star_helmet || current_head != star_head)
        {
            if (current_go_helmet != null)
                Destroy(current_go_helmet);
            if (current_go_head != null)
                Destroy(current_go_head);

            if (current_helmet != -1)
            {
                current_go_helmet = Instantiate(helmets[current_helmet], transform);
                FixSkinnedMesh(current_go_helmet);

                if (!helmets_info[current_helmet].helmets_is_replace_head)
                {
                    current_go_head = Instantiate(heads[current_head], transform);
                    FixSkinnedMesh(current_go_head);
                }
            }
            else
            {
                current_go_head = Instantiate(heads[current_head], transform);
                FixSkinnedMesh(current_go_head);
            }

            star_helmet = current_helmet;
        }

        if (current_backpack != star_backpack)
        {
            if (current_go_backpack != null)
                Destroy(current_go_backpack);

            if (current_backpack != -1)
            {
                current_go_backpack = Instantiate(backpacks[current_backpack], transform);
                FixSkinnedMesh(current_go_backpack);
            }
            star_backpack = current_backpack;
        }

        if (current_vest != star_vest)
        {
            if (current_go_vest != null)
                Destroy(current_go_vest);

            if (current_vest != -1)
            {
                current_go_vest = Instantiate(vests[current_vest], transform);
                FixSkinnedMesh(current_go_vest);
            }

            star_vest = current_vest;
        }



        star_is_black_character = current_is_black_character;
    }


    public void SetCharacterParts(int _current_shirt, int _current_pant, int _current_boots, int _current_helmet, int _current_backpack, int _current_vest, int _current_head)
    {
        current_shirt = _current_shirt;
        current_pant = _current_pant;
        current_boots = _current_boots;
        current_helmet = _current_helmet;
        current_backpack = _current_backpack;
        current_vest = _current_vest;
        current_head = _current_head;

        InitParams();
    }


    void FixSkinnedMesh(GameObject go)
    {
        Transform[] existingTrans = go.GetComponentsInChildren<Transform>(false);


        for (int q = 0; q < existingTrans.Length; q++)
        {
            SkinnedMeshBonesData smbd = existingTrans[q].GetComponent<SkinnedMeshBonesData>();
            if (smbd != null)
            {
                SkinnedMeshRenderer smr = existingTrans[q].GetComponent<SkinnedMeshRenderer>();

                if (dictBones.ContainsKey(smbd.rootBone))
                {
                    smr.rootBone = dictBones[smbd.rootBone];
                }
                else
                    Debug.LogError("no rootBone!");



                Transform[] bonessss = new Transform[smbd.bones.Length];

                for (int w = 0; w < smbd.bones.Length; w++)
                {
                    if (dictBones.ContainsKey(smbd.bones[w]))
                    {
                        bonessss[w] = dictBones[smbd.bones[w]];
                        //Debug.Log(bones[w], dict[bones[w]]);
                    }
                    else
                        Debug.LogError("!dict.ContainsKey(bones[w]) = " + smbd.bones[w]);
                }

                smr.bones = bonessss;
            }
        }
    }
}
