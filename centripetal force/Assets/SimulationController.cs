using UnityEngine;
using UnityEngine.UI;

public class SimulationController : MonoBehaviour
{
    public GameObject planetPrefab;
    public InputField massInput;
    public InputField distanceInput;
    public Text forceText;
    public Button startButton;

    private GameObject planet1;
    private GameObject planet2;
    private float mass1;
    private float mass2;
    private float distance;

    private const float G = 6.67430e-11f; // �߷� ���

    void Start()
    {
        startButton.onClick.AddListener(StartSimulation);
    }

    void StartSimulation()
    {
        // �Է� �� ��������
        mass1 = float.Parse(massInput.text);
        mass2 = mass1; // �� �༺�� ������ ���ٰ� ����
        distance = float.Parse(distanceInput.text);

        // �༺ ���� �� ��ġ ����
        planet1 = Instantiate(planetPrefab, new Vector3(-distance / 2, 0, 0), Quaternion.identity);
        planet2 = Instantiate(planetPrefab, new Vector3(distance / 2, 0, 0), Quaternion.identity);

        // Rigidbody ����
        Rigidbody rb1 = planet1.GetComponent<Rigidbody>();
        Rigidbody rb2 = planet2.GetComponent<Rigidbody>();
        rb1.useGravity = false;
        rb2.useGravity = false;

        // �ʱ� �ӵ� ��� �� ����
        Vector3 initialVelocity = new Vector3(0, Mathf.Sqrt(G * mass2 / distance), 0);
        rb1.velocity = initialVelocity;
        rb2.velocity = -initialVelocity;

        // ���ɷ� ��� �� ǥ��
        float centripetalForce = CalculateCentripetalForce(mass1, mass2, distance);
        forceText.text = "Centripetal Force: " + centripetalForce.ToString("F2") + " N";
    }

    float CalculateCentripetalForce(float m1, float m2, float r)
    {
        return (G * m1 * m2) / (r * r);
    }

    void Update()
    {
        if (planet1 != null && planet2 != null)
        {
            Vector3 direction = planet2.transform.position - planet1.transform.position;
            float distance = direction.magnitude;
            Vector3 forceDirection = direction.normalized;

            float forceMagnitude = CalculateCentripetalForce(mass1, mass2, distance);
            Vector3 force = forceDirection * forceMagnitude;

            // �༺�� �� ����
            Rigidbody rb1 = planet1.GetComponent<Rigidbody>();
            Rigidbody rb2 = planet2.GetComponent<Rigidbody>();
            rb1.AddForce(force);
            rb2.AddForce(-force);

            // ���ɷ� �ؽ�Ʈ ������Ʈ
            forceText.text = "Centripetal Force: " + forceMagnitude.ToString("F2") + " N";
        }
    }
}
