using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Pipe Changer";
        job1._company = "Clides Ranch";
        job1._startYear = 2015;
        job1._endYear = 2019;

        Job job2 = new Job();
        job2._jobTitle = "Ranch Hand";
        job2._company = "Whittaker Two Dot Ranch";
        job2._startYear = 2019;
        job2._endYear = 2016;

        Resume officialResume = new Resume();
        officialResume._name = "Ronan Nash";
        officialResume._allJobs.Add(job1);
        officialResume._allJobs.Add(job2);
        
        officialResume.displayResume();
    }
}