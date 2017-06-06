using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GestureManager : MonoBehaviour {
    public GestureRecognizer SelectionRecognizer { get; private set; }
    public GestureRecognizer ManipulationRecognizer { get; private set; }

    public bool IsNavigating { get; private set; }
    public Vector3 ManipulationPosition { get; private set; }

    public GameObject ManipulationObject;
    private bool isSelected;
    public bool isManipulation { get; private set; }

    private Vector3 manipulationPreviousPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = ManipulationObject.GetComponent<Rigidbody>();
    }

    void Awake()
    {
        SelectionRecognizer = new GestureRecognizer();
        SelectionRecognizer.SetRecognizableGestures(GestureSettings.Tap);
        SelectionRecognizer.StartCapturingGestures();
        SelectionRecognizer.TappedEvent += NavigationRecognizer_TappedEvent;

        ManipulationRecognizer = new GestureRecognizer();
        ManipulationRecognizer.SetRecognizableGestures(GestureSettings.ManipulationTranslate);
        ManipulationRecognizer.ManipulationStartedEvent += ManipulationRecognizer_ManipulationStartedEvent;
        ManipulationRecognizer.ManipulationUpdatedEvent += ManipulationRecognizer_ManipulationUpdatedEvent;
        ManipulationRecognizer.ManipulationCompletedEvent += ManipulationRecognizer_ManipulationCompletedEvent;
        ManipulationRecognizer.ManipulationCanceledEvent += ManipulationRecognizer_ManipulationCanceledEvent;
    }

    private void NavigationRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray ray)
    {
        print("Tapped Event");
        SelectionRecognizer.StopCapturingGestures();
        ManipulationRecognizer.StartCapturingGestures();
    }

    private void ManipulationRecognizer_ManipulationStartedEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        print("Manipulation Started");
        PerformManipulationStart(position);
    }

    private void ManipulationRecognizer_ManipulationUpdatedEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        print("Manipulation Updated");
        PerformManipulationUpdate(position);
    }

    private void ManipulationRecognizer_ManipulationCompletedEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        rb.isKinematic = false;
        print("Manipulation Completed");
    }

    private void ManipulationRecognizer_ManipulationCanceledEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        rb.isKinematic = false;
        print("Manipulation Cancelled");
    }

    private void PerformManipulationStart(Vector3 position)
    {
        rb.isKinematic = true;
        manipulationPreviousPosition = position;
    }

    void PerformManipulationUpdate(Vector3 position)
    {
        Vector3 moveVector = new Vector3(0, 1, 0);
        ManipulationObject.transform.position += moveVector;
    }
}
