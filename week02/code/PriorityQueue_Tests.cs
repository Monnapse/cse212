using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 tasks with priorities 1, 3, and 2, then dequeue once.
    // Expected Result: "Task2" should be dequeued first because it has the highest priority.
    // Defect(s) Found: Dequeue returned the lowest priority item instead priority comparison was reversed.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue(); // Create a new priority queue instance

        // Add three items with different priorities
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 3);
        priorityQueue.Enqueue("Task3", 2);

        var dequeuedItem = priorityQueue.Dequeue(); // Dequeue the highest priority item

        Assert.AreEqual("Task2", dequeuedItem, "The dequeued item should be 'Task2' with the highest priority."); // Log

        //Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Enqueue three tasks. Dequeue twice to test order preservation among equal priorities.
    // Expected Result: TaskA dequeued first, then TaskC, since they share equal priority but TaskA was enqueued first.
    // Defect(s) Found: The queue did not preserve FIFO order for equal priorities.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue(); // Create a new priority queue instance

        // Add three items with two having the same highest priority
        priorityQueue.Enqueue("TaskA", 5);
        priorityQueue.Enqueue("TaskB", 1);
        priorityQueue.Enqueue("TaskC", 5);

        var dequeuedItem1 = priorityQueue.Dequeue(); // Dequeue the first item

        Assert.AreEqual("TaskA", dequeuedItem1, "The dequeued item should be 'TaskA' with the highest priority & the lowest order.");

        var dequeuedItem2 = priorityQueue.Dequeue(); // Dequeue the second item

        Assert.AreEqual("TaskC", dequeuedItem2, "The dequeued item should be 'TaskC' with the next highest priority."); // Log

        priorityQueue.Dequeue(); // Dequeue the last item to empty the queue
        // Next dequeue should throw an exception since the queue is empty
        
        //Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}