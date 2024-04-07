using DependencyInjection; // https://github.com/adammyhre/Unity-Dependency-Injection-Lite
using UnityEngine;
using UnityServiceLocator; // https://github.com/adammyhre/Unity-Service-Locator

public class GoapFactory : MonoBehaviour, IDependencyProvider {
    void Awake() {
        ServiceLocator.Global.Register(this);
    }
    
    [Provide] public GoapFactory ProvideFactory() => this;

    public IGoapPlanner CreatePlanner() {
        return new GoapPlanner();
    }
}