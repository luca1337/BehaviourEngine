using BehaviourEngine;



public class Timer
{
    private float timeLimit;
    public bool IsActive { get; private set; }
    public float currentTime;

    public Timer(float timeLimit)
    {
        this.timeLimit = timeLimit;
    }

    public void Update()
    {
        currentTime += Time.DeltaTime;
        if (currentTime > timeLimit)
            Stop();
    }

    public void Start()
    {
        IsActive    = true;
        currentTime = 0f;
    }

    public bool IsOver()
    {
        return currentTime > timeLimit;
    }

    public void Stop()
    {
        currentTime = 0f;
        IsActive    = false;
    }
}