using System;
using System.Collections.Generic;

namespace Question1
{
    internal class Notify
    {
        delegate void Notifys(); // Declare a Notify delegate

        class MemberList
        {
            private List<string> members = new List<string>();
            public int MaximumMembers { get; set; }
            public event Notifys OnFullOfMembers;

            public void AddMember(string name)
            {
                if (members.Count >= MaximumMembers)
                {
                    OnFullOfMembers?.Invoke(); // Trigger the event if the list is full
                }
                else
                {
                    members.Add(name);
                    Console.WriteLine($"{name} added to the list.");
                }
            }
        }

        class Program
        {
            static void Main()
            {
                MemberList memberList = new MemberList { MaximumMembers = 3 };
                memberList.OnFullOfMembers += FullNotification; // Subscribe to the event
                memberList.AddMember("Alice");
                memberList.AddMember("Bob");
                memberList.AddMember("Charlie");
                memberList.AddMember("Dave"); // This will trigger the event
            }

            static void FullNotification()
            {
                Console.WriteLine("The member list is full.");
            }
        }
    }
}
