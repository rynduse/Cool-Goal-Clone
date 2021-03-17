using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public static Bezier Instance;

    private void Awake()
    {
        Instance = this;
    }

    private Transform tr;
    public Transform Transform { get { return (tr == null) ? tr = GetComponent<Transform>() : tr; } }

    private Rigidbody rb;
    public Rigidbody Rigidbody { get { return (rb == null) ? rb = GetComponent<Rigidbody>() : rb; } }


    public LineRenderer lineRenderer;
    public Transform point0, point1, point2;


    public int numPoints = 50;

    public Vector3[] positions = new Vector3[50];

    public bool SetActiveIndicator;

    public GameObject whiteBall, whiteBallStorage;
    public GameObject[] instantiatedObj = new GameObject[30];

    public bool isBallMove;
    bool notMove;
    public bool turn, isEnter;

    //public int j = 2;
    public int currentNum = 0;
    Vector3[] positionStorage;

    private void Start()
    {
        isEnter = false;

        for (int i = 0; i < 30; i++)
        {
            instantiatedObj[i] = Instantiate(whiteBall, whiteBallStorage.transform);
            instantiatedObj[i].SetActive(false);
        }
    }

    private void OnEnable()
    {
        EventManager.OnDrawIndicator.AddListener(() =>SetActiveIndicator = true);
        EventManager.OnBallMovement.AddListener(() => isBallMove = true);

    }
    private void OnDisable()
    {
        EventManager.OnDrawIndicator.RemoveListener(() =>SetActiveIndicator = true);
        EventManager.OnBallMovement.RemoveListener(() => isBallMove = true);

    }



    private void Update()
    {
        if (SetActiveIndicator)
            DrawWhiteIndicator();
        else
            BallMovement();

    }

    #region DrawWhiteIndicator
    private void DrawWhiteIndicator()
    {


        if (SetActiveIndicator)
        {

            for (int i = 1; i < numPoints + 1; i++)
            {
                float t = i / (float)numPoints;
                positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);

            }

            for (int i = 0; i < 30; i++)
            {
                instantiatedObj[i].transform.position = positions[i];
                instantiatedObj[i].SetActive(true);
            }

            for (int i = 29; i > 24; i--)
            {
                instantiatedObj[i].SetActive(false);
            }


        }

    }

    #endregion

    #region BallMovement
    public void BallMovement()
    {

        isEnter = true;

        if (turn)
            return;


        if (!isBallMove)
            return;

        foreach (var item in instantiatedObj)
        {
            item.SetActive(false);
        }

        if (Vector3.Distance(instantiatedObj[currentNum].transform.position, Transform.position) < 1)
        {
            currentNum++;
            if (currentNum >= instantiatedObj.Length)
            {
                notMove = true;
                currentNum = 0;

            }
        }

        if (!notMove)
        {
            Rigidbody.AddForce((instantiatedObj[currentNum].transform.position - Transform.position).normalized * 2000 * Time.deltaTime);
        }


        if (Transform.position == instantiatedObj[instantiatedObj.Length-1].transform.position)
        {
            SetActiveIndicator = false;

        }

    }

    #endregion



    #region DrawQuadraticCurve With LineRenderer
    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);
        }

        lineRenderer.SetPositions(positions);

        positionStorage = positions;
    }
    #endregion


    #region Calculation Of Bezier Curve
    public Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {

        p2 = p2 + Vector3.forward * 10;
        //B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2

        float u = 1 - t;
        float uu = u * u;
        float tt = t * t;

        Vector3 p = uu * p0;

        p += 2 * u * t * p1;
        p += tt * p2;

        //p = (uu * p0) + (2 * u * t * p1) + (tt * p2)

        return p;
    }
    #endregion

}
