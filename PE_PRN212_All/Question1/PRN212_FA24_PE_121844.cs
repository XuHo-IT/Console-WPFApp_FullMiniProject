using System;
using System.Collections.Generic;

delegate void Notify();


abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public abstract void Display();
}

class Teacher : Item
{
    public string Skill { get; set; }

    public override void Display()
    {
        Console.WriteLine($"Teacher: {Name}, ID: {Id}, Skill: {Skill}");
    }
}


class Student : Item
{
    public DateOnly Dob { get; set; }

    public override void Display()
    {
        Console.WriteLine($"Student: {Name}, ID: {Id}, DOB: {Dob}");
    }
}


interface ICustomList
{
    void Add(Item item);
    void DisplayList();
    event Notify OnFullOfMember;
}


class MemberList : ICustomList
{
    private List<Item> members = new List<Item>();
    public int MaximumNumberOfMember { get; set; }
    public event Notify OnFullOfMember;

    public void Add(Item item)
    {
        if (members.Count >= MaximumNumberOfMember)
        {
            OnFullOfMember?.Invoke(); 
        }
        else
        {
            members.Add(item);
            Console.WriteLine($"{item.Name} has been added to the list.");
        }
    }

    public void DisplayList()
    {
        foreach (var member in members)
        {
            member.Display();
        }
    }
}

internal class PRN212_FA24_PE_121844
{
    private static void Main(string[] args)
    {
        Teacher teacher = new Teacher { Id = 1, Name = "Teacher 1", Skill = ".Net" };
        Student student1 = new Student { Id = 2, Name = "Student A", Dob = new DateOnly(2000, 12, 23) };
        Student student2 = new Student { Id = 3, Name = "Student B", Dob = new DateOnly(2000, 5, 16) };

        MemberList memberList = new MemberList();
        memberList.MaximumNumberOfMember = 3;
        memberList.OnFullOfMember += OnFullOfMemberNotify;
        memberList.Add(student1);
        memberList.Add(student2);
        memberList.Add(teacher);

        Console.WriteLine(Environment.NewLine);
        memberList.DisplayList();

        Console.WriteLine(Environment.NewLine);
        ICustomList customList = new MemberList();
        customList.Add(new Student { Id = 4, Name = "Student C", Dob = new DateOnly(2000, 12, 25) });
        customList.Add(new Student { Id = 5, Name = "Student D", Dob = new DateOnly(2000, 12, 25) });
        customList.DisplayList();
    }

    private static void OnFullOfMemberNotify()
    {
        Console.WriteLine("The member list is full");
    }
}
