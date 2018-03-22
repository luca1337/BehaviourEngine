using BehaviourEngine;

public class Timer
{
    private float timeLimit;
    public bool IsActive { get; private set; }
    public float currentTime;

    public float MaxTime => timeLimit;
    public Timer(float timeLimit)
    {
        this.timeLimit = timeLimit;
    }

    public void Update(bool restart)
    {
        currentTime += Time.DeltaTime;
        if (currentTime > timeLimit)
            Stop(restart);
    }

    public void Start()
    {
        IsActive = true;
        currentTime = 0f;
    }

    public bool IsOver()
    {
        return currentTime > timeLimit;
    }

    public void Stop(bool restart)
    {
        IsActive = false;

        if (restart)
            currentTime = 0f;
    }
}