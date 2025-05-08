using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Janitor";
        job1._company = "BYU-Idaho";
        job1._startYear = 2021;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Google";
        job2._startYear = 2019;
        job2._endYear = 2021;

        job1.Display();
        job2.Display();

        Resume resume = new Resume();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._name = "John";

        resume.Display();
    }
}
