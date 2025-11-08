using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 3);
        priorityQueue.Enqueue("Task3", 2);

        var dequeuedItem = priorityQueue.Dequeue();

        Assert.AreEqual("Task2", dequeuedItem, "The dequeued item should be 'Task2' with the highest priority.");

        //Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("TaskA", 5);
        priorityQueue.Enqueue("TaskB", 1);
        priorityQueue.Enqueue("TaskC", 5);

        var dequeuedItem1 = priorityQueue.Dequeue();

        Assert.AreEqual("TaskA", dequeuedItem1, "The dequeued item should be 'TaskA' with the highest priority & the lowest order.");

        var dequeuedItem2 = priorityQueue.Dequeue();

        Assert.AreEqual("TaskC", dequeuedItem2, "The dequeued item should be 'TaskC' with the next highest priority.");


        priorityQueue.Dequeue();

        // Next dequeue should throw an exception since the queue is empty
        
        //Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}