using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    //private readonly List<GameObject> children = new();
    [SerializeField] private GameObject[] children;
    [SerializeField] private TextMeshProUGUI levelName;

    private readonly Color highlightColor = new (131/255f, 243/255f, 1);
    private readonly Color mutedColor = new (90/255f, 192/255f, 188/255f);

    
    private int currentPage = 0;
    
    private void Start()
    {
        SetPage(0);
    }

    public void SetPage(int page)
    {
        if (page < 0 || page >= children.Length)
        {
            return;
        }

        currentPage = page;
        for (int i = 0; i < children.Length; i++)
        {
            int position = i - page;
            var child = children[i];
            var childTransform = child.transform;
            if (position == 0)
            {
                childTransform.localPosition = new Vector3(0, 0);
                childTransform.localScale = new Vector3(2.1f, 2.1f);
                child.GetComponent<Image>().color = highlightColor;
                levelName.text = child.name;
            }
            else
            {
                childTransform.localPosition = new Vector3(250 * position, 0);
                childTransform.localScale = new Vector3(1.9f, 1.9f);
                child.GetComponent<Image>().color = mutedColor;
            }
        }
    }

    public void NextLevel()
    {
        SetPage(currentPage + 1);
    }

    public void PrevLevel()
    {
        SetPage(currentPage - 1);
    }
}
