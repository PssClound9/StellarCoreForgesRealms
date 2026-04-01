using UnityEngine;
using System.Collections.Generic;

public class DuplicantAI : MonoBehaviour
{
    public enum TaskType
    {
        CollectResource,
        Build,
        Repair,
        Idle
    }
    
    [System.Serializable]
    public class Task
    {
        public TaskType type;
        public GameObject target;
        public float priority;
    }
    
    public List<Task> tasks = new List<Task>();
    private Task currentTask;
    private float taskUpdateInterval = 1f;
    private float lastTaskUpdateTime;
    
    void Update()
    {
        // 定期更新任务
        if (Time.time - lastTaskUpdateTime > taskUpdateInterval)
        {
            UpdateTask();
            lastTaskUpdateTime = Time.time;
        }
        
        // 执行当前任务
        if (currentTask != null)
        {
            ExecuteTask();
        }
    }
    
    void UpdateTask()
    {
        if (tasks.Count > 0)
        {
            // 按优先级排序任务
            tasks.Sort((a, b) => b.priority.CompareTo(a.priority));
            currentTask = tasks[0];
        }
        else
        {
            currentTask = null;
        }
    }
    
    void ExecuteTask()
    {
        switch (currentTask.type)
        {
            case TaskType.CollectResource:
                CollectResource();
                break;
            case TaskType.Build:
                Build();
                break;
            case TaskType.Repair:
                Repair();
                break;
            case TaskType.Idle:
                Idle();
                break;
        }
    }
    
    void CollectResource()
    {
        // 移动到资源位置
        if (currentTask.target != null)
        {
            float distance = Vector3.Distance(transform.position, currentTask.target.transform.position);
            if (distance > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTask.target.transform.position, 2f * Time.deltaTime);
            }
            else
            {
                // 采集资源
                if (currentTask.target.GetComponent<ResourceInteractable>())
                {
                    currentTask.target.GetComponent<ResourceInteractable>().Interact();
                    tasks.Remove(currentTask);
                    currentTask = null;
                }
            }
        }
    }
    
    void Build()
    {
        // 实现建造逻辑
        Debug.Log("建造中...");
        // 建造完成后移除任务
        tasks.Remove(currentTask);
        currentTask = null;
    }
    
    void Repair()
    {
        // 实现修复逻辑
        Debug.Log("修复中...");
        // 修复完成后移除任务
        tasks.Remove(currentTask);
        currentTask = null;
    }
    
    void Idle()
    {
        // 空闲状态
        Debug.Log("空闲中...");
        // 一段时间后移除空闲任务
        if (Random.value > 0.99f)
        {
            tasks.Remove(currentTask);
            currentTask = null;
        }
    }
    
    // 添加任务
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }
}