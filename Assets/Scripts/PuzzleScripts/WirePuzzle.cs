using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WirePuzzle : Puzzle
{
    public Transform inputs;
    public Transform outputs;
    public Color[] colors;
    private int outputCount = 0, solvedCount = 0;
    public float WIRE_WIDTH = 0.2f;
    private bool IsDrawing = false;
    private Vector3 DrawingStartPosition;
    private GameObject CurrentLine;

    private void SwapPlaces(Transform A, Transform B)
    {
        Vector3 posA = A.position;
        Vector3 posB = B.position;
        A.position = posB;
        B.position = posA;
    }

    private void SetupInputSlots()
    {
        int i = 0;
        foreach (Transform input in inputs)
        {
            input.GetComponent<Image>().color = colors[i++];
            Transform swap = null;
            while (swap == null || swap == input) swap = inputs.GetChild(Random.Range(0, inputs.childCount - 1));
            SwapPlaces(input, swap);
            Button inputButton = input.gameObject.AddComponent<Button>();
            inputButton.onClick.AddListener(() => StartDrawing(input.gameObject.GetComponent<Image>().color));
        }
    }

    private void SetupOutputSlots()
    {
        int i = 0;
        foreach (Transform output in outputs)
        {
            output.GetComponent<Image>().color = colors[i++];
            Button outputButton = output.gameObject.AddComponent<Button>();
            outputButton.onClick.AddListener(() => StopDrawing(output.gameObject.GetComponent<Image>().color));
            outputCount++;
        }
    }

    private void StartDrawing(Color color)
    {
        if (IsDrawing) Destroy(CurrentLine);

        DrawingStartPosition = Input.mousePosition;
        GameObject wire = new GameObject("Wire");
        Image wireImage = wire.AddComponent<Image>();
        wireImage.color = color;

        CurrentLine = Instantiate(wire, GameObject.Find("Wires").transform);
        CurrentLine.transform.position = DrawingStartPosition;
        
        IsDrawing = true;
    }

    private void UpdateDrawing()
    {
        Stretch(CurrentLine, DrawingStartPosition, Input.mousePosition);
    }

    private void StopDrawing(Color color)
    {
        if (!IsDrawing) return;

        Debug.Log(CurrentLine.GetComponent<Image>().color);
        Debug.Log(color);
        if (IsDrawing && CurrentLine.GetComponent<Image>().color == color)
        {
            solvedCount++;
        } else {
            Destroy(CurrentLine);
        }
        IsDrawing = false;
    }

    private void Stretch(GameObject _sprite,Vector3 _initialPosition, Vector3 _finalPosition) 
    {
        float width = _sprite.GetComponent<RectTransform>().rect.width * 1.01f; // offset width so mouse can click button    
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.right = direction;
        Vector3 scale = new Vector3(1,.2f,1);
        scale.x = Vector3.Distance(_initialPosition, _finalPosition) / width;
        _sprite.transform.localScale = scale;
     }

    new void Start()
    {
        SetupInputSlots();
        SetupOutputSlots();
        Hide();
    }

    void Update()
    {
        if (IsDrawing)
        {
            UpdateDrawing();
        } else if (solvedCount == outputCount)
        {
            Solve();

            // TODO: PuzzleTrigger should be responsible for this
            PlayerMovement.Instance.SetFrozenStatus(false);
            InteractSign.Instance.Hide();
        }
    }
}