using System;

public class Resume {
    public string _name;
    public List<Job> _allJobs = new List<Job>();

    public void displayResume() {
        Console.WriteLine($"Name: {_name}\nJobs:");
        foreach (Job job in _allJobs) {
            job.displayJob();
        }
    }
}