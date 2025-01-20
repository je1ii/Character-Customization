using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderGraph;

public class Customization : MonoBehaviour
{
    [Header("Characters")]
    public GameObject male;
    public GameObject female;

    [Header("Female Elements")]
    public GameObject arm_f_l;
    public GameObject arm_f_r;
    public GameObject calf_f_l;
    public GameObject calf_f_r;
    public GameObject foot_f_l;
    public GameObject foot_f_r;
    public GameObject forearm_f_l;
    public GameObject forearm_f_r;
    public GameObject hair_f;
    public GameObject hand_f_l;
    public GameObject hand_f_r;
    public GameObject head_f;
    public GameObject legs_f;
    public GameObject torso_f;
    public GameObject eyebrows_f;

    [Header("Male Elements")]
    public GameObject arm_m_l;
    public GameObject arm_m_r;
    public GameObject calf_m_l;
    public GameObject calf_m_r;
    public GameObject facial_hair;
    public GameObject foot_m_l;
    public GameObject foot_m_r;
    public GameObject forearm_m_l;
    public GameObject forearm_m_r;
    public GameObject hair_m;
    public GameObject hand_m_l;
    public GameObject hand_m_r;
    public GameObject head_m;
    public GameObject legs_m;
    public GameObject torso_m;
    public GameObject eyebrows_m;

    [Header("UI Elements")]
    public Image maleButton;
    public Image femaleButton;
    public TextMeshProUGUI maleGenderText;
    public TextMeshProUGUI femaleGenderText;
    public GameObject facialHairUI;

    [Header("List of All Elements")]
    public List<Mesh> hairElements;
    public List<Mesh> torsoElements;
    public List<Mesh> armLeftElements;
    public List<Mesh> armRightElements;
    public List<Mesh> legsElements;
    public List<Mesh> footLeftElements;
    public List<Mesh> footRightElements;
    public List<Mesh> facialHairElements;

    [Header("Variables")]
    [SerializeField] private bool gender; // female = false, male = true
    [SerializeField] private SkinnedMeshRenderer smr = null;

    [SerializeField] private int hairIndex;
    [SerializeField] private int torsoIndex;
    [SerializeField] private int armIndex;
    [SerializeField] private int legsIndex;
    [SerializeField] private int footIndex;
    [SerializeField] private int facialHairIndex;

    void Start()
    {
        gender = true;
        hairIndex = 2;
        torsoIndex = 2;
        armIndex = 2;
        legsIndex = 2;
        footIndex = 2;
    }

    void Update()
    {
        
    }

    public void SetMaleIndex()
    {
        hairIndex = 2;
        torsoIndex = 2;
        armIndex = 2;
        legsIndex = 2;
        footIndex = 2;
        facialHairIndex = 0;
    }
    public void SetFemaleIndex()
    {
        hairIndex = 0;
        torsoIndex = 0;
        armIndex = 0;
        legsIndex = 0;
        footIndex = 0;
    }

    public void SetAllToDefault(bool isFemale)
    {
        if (isFemale)
        {
            smr = hair_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = hairElements[hairIndex];

            smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = armLeftElements[armIndex];

            smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = armRightElements[armIndex];

            smr = torso_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = torsoElements[torsoIndex];

            smr = legs_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = legsElements[legsIndex];

            smr = foot_f_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footLeftElements[footIndex];

            smr = foot_f_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footRightElements[footIndex];
        }
        else
        {
            smr = hair_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = hairElements[hairIndex];

            smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = armLeftElements[armIndex];

            smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = armRightElements[armIndex];

            smr = torso_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = torsoElements[torsoIndex];

            smr = legs_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = legsElements[legsIndex];

            smr = foot_m_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footLeftElements[footIndex];

            smr = foot_m_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footRightElements[footIndex];

            smr = facial_hair.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = facialHairElements[facialHairIndex];

        }
    }

    public void ChangeGender()
    {
        //is female
        if (gender)
        {
            //ui transition
            femaleGenderText.color = new Color(0.3f, 0.3f, 0.3f, 1);
            femaleButton.color = new Color(1, 1, 1, 1);

            maleGenderText.color = new Color(1, 1, 1, 1);
            maleButton.color = new Color(1, 1, 1, 0);

            //reset male position and rotation
            male.transform.position = new Vector3(-26f, 0.36f, -28);
            male.transform.eulerAngles = new Vector3(0, 90, 0);

            SetFemaleIndex();
            SetAllToDefault(true);
            facialHairUI.SetActive(false);
            male.SetActive(false);
            female.SetActive(true);
        }
        //is male
        else
        {
            //ui transition
            maleGenderText.color = new Color(0.3f, 0.3f, 0.3f, 1);
            maleButton.color = new Color(1, 1, 1, 1);

            femaleGenderText.color = new Color(1, 1, 1, 1);
            femaleButton.color = new Color(1, 1, 1, 0);

            //reset female position and rotation
            female.transform.position = new Vector3(-26f, 0.36f, -28);
            female.transform.eulerAngles = new Vector3(0, 90, 0);

            SetMaleIndex();
            SetAllToDefault(false);
            facialHairUI.SetActive(true);
            male.SetActive(true);
            female.SetActive(false);
        }

        gender = !gender;
    }

    public int CycleIndex(int index, List<Mesh> list, bool isRight)
    {
        int newIndex = index;
        //right arrow
        if(isRight)
        {
            newIndex++;

            if (newIndex > list.Count - 1)
            {
                newIndex = 0;
            }
        }
        //left arrow
        else
        {
            newIndex--;

            if (newIndex < 0)
            {
                newIndex = list.Count - 1;
            }
        }

        return newIndex;
    }

    public int CycleIndexGender(int index, bool isRight, bool surpassMax)
    {
        int newIndex = index;
        int minIndex = 0;
        int maxIndex = 0;

        //is male
        if (gender)
        {
            minIndex = 2;
            maxIndex = 3;
        }
        //is female
        else
        {
            minIndex = 0;
            maxIndex = 1;
        }

        if (surpassMax)
        {
            maxIndex += 1;
        }

        //right arrow
        if (isRight)
        {
            newIndex++;

            if (newIndex > maxIndex)
            {
                newIndex = minIndex;
            }
        }
        //left arrow
        else
        {
            newIndex--;

            if (newIndex < minIndex)
            {
                newIndex = maxIndex;
            }
        }

        return newIndex;
    }

    public void ChangeHairRight()
    {
        hairIndex = CycleIndex(hairIndex, hairElements, true);

        //is male
        if (gender)
        {
            smr = hair_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = hairElements[hairIndex];
        }
        //is female
        else
        {
            smr = hair_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = hairElements[hairIndex];
        }
    }

    public void ChangeHairLeft()
    {
        hairIndex = CycleIndex(hairIndex, hairElements, false);

        //is male
        if (gender)
        {
            smr = hair_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = hairElements[hairIndex];
        }
        //is female
        else
        {
            smr = hair_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = hairElements[hairIndex];
        }
    }
    
    public void ChangeShirtRight()
    {
        torsoIndex = CycleIndexGender(torsoIndex, true, true);

        //is male
        if (gender)
        {
            if (torsoIndex == 4)
            {
                armIndex = CycleIndexGender(armIndex, true, false);

                smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];
            }
            else if (torsoIndex == 2)
            {
                armIndex = CycleIndexGender(armIndex, true, false);

                smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];

                smr = torso_m.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex];
            }
            else
            {
                smr = torso_m.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex];
            }
        }
        //is female
        else
        {
            if (torsoIndex == 2)
            {
                armIndex = CycleIndexGender(armIndex, true, false);

                smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];
            }
            else if (torsoIndex == 0)
            {
                armIndex = CycleIndexGender(armIndex, true, false);

                smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];

                smr = torso_f.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex];
            }
            else
            {
                smr = torso_f.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex];
            }
        }
    }
    public void ChangeShirtLeft()
    {
        torsoIndex = CycleIndexGender(torsoIndex, false, true);

        //is male
        if (gender)
        {
            if (torsoIndex == 4)
            {
                armIndex = CycleIndexGender(armIndex, false, false);

                smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];

                smr = torso_m.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex - 1];
            }
            else if (torsoIndex == 2)
            {
                smr = torso_m.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex];
            }
            else
            {
                armIndex = CycleIndexGender(armIndex, false, false);

                smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];
            }
        }
        //is female
        else
        {
            if (torsoIndex == 2)
            {
                armIndex = CycleIndexGender(armIndex, false, false);

                smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];

                smr = torso_f.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex - 1];
            }
            else if (torsoIndex == 0)
            {
                smr = torso_f.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = torsoElements[torsoIndex];
            }
            else
            {
                armIndex = CycleIndexGender(armIndex, false, false);

                smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armLeftElements[armIndex];

                smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
                smr.sharedMesh = armRightElements[armIndex];
            }
        }
    }

    public void ChangePantsRight()
    {
        legsIndex = CycleIndexGender(legsIndex, true, false);

        //is male
        if (gender)
        {
            smr = legs_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = legsElements[legsIndex];
        }
        //is female
        else
        {
            smr = legs_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = legsElements[legsIndex];
        }
    }
    public void ChangePantsLeft()
    {
        legsIndex = CycleIndexGender(legsIndex, true, false);

        //is male
        if (gender)
        {
            smr = legs_m.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = legsElements[legsIndex];
        }
        //is female
        else
        {
            smr = legs_f.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = legsElements[legsIndex];
        }
    }

    public void ChangeShoesRight()
    {
        footIndex = CycleIndexGender(footIndex, true, false);

        //is male
        if (gender)
        {
            smr = foot_m_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footLeftElements[footIndex];

            smr = foot_m_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footRightElements[footIndex];
        }
        //is female
        else
        {
            smr = foot_f_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footLeftElements[footIndex];

            smr = foot_f_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footRightElements[footIndex];
        }
    }

    public void ChangeShoesLeft()
    {
        footIndex = CycleIndexGender(footIndex, false, false);

        //is male
        if (gender)
        {
            smr = foot_m_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footLeftElements[footIndex];

            smr = foot_m_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footRightElements[footIndex];
        }
        //is female
        else
        {
            smr = foot_f_l.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footLeftElements[footIndex];

            smr = foot_f_r.GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh = footRightElements[footIndex];
        }
    }

    public void ChangeFacialRight()
    {
        facialHairIndex = CycleIndex(facialHairIndex, facialHairElements,true);
        
        smr = facial_hair.GetComponent<SkinnedMeshRenderer>();
        smr.sharedMesh = facialHairElements[facialHairIndex];
    }

    public void ChangeFacialLeft()
    {
        facialHairIndex = CycleIndex(facialHairIndex, facialHairElements, false);

        smr = facial_hair.GetComponent<SkinnedMeshRenderer>();
        smr.sharedMesh = facialHairElements[facialHairIndex];
    }
}
