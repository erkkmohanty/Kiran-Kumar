using System.Collections.Generic;
using System.Net.Configuration;

namespace Angular_in_19_Days.Repository
{
    public class EventRepository
    {
        private static List<TalkVm> talkVmList = new List<TalkVm>(new[]
            {
                new TalkVm
                {
                    id = 1001,
                    name = "Advanced Angular JS",
                    speaker = "Kiran Kumar",
                    venue = "Delhi",
                    duration = "45 mins"
                },
                new TalkVm
                {
                    id = 1002,
                    name = "Advanced Angular JS 2",
                    speaker = "Kiran Kumar Mohanty",
                    venue = "Delhi",
                    duration = "46 mins"
                },
                new TalkVm
                {
                    id = 1003,
                    name = "Advanced Angular JS 3",
                    speaker = "DJ",
                    venue = "Delhi",
                    duration = "47 mins"
                },
                new TalkVm
                {
                    id = 1004,
                    name = "Advanced Angular JS 4",
                    speaker = "KKM",
                    venue = "Delhi",
                    duration = "48 mins"
                }
            });

        public List<TalkVm> GetTasks()
        {
            return talkVmList;
        }

        public bool AddTalk(TalkVm talkVm)
        {
            talkVmList.Add(talkVm);
            return true;
        }
        public SpeakerVM[] GetSpeakers()
        {
            var speakers = new[]
            {
                new SpeakerVM
                {
                    Id = "S001",
                    Name = "Brij Bhushan Mishra",
                    Expertise = "Client Script, ASP.NET",
                    TalksDelivered = 28
                },
                new SpeakerVM
                {
                    Id = "S002",
                    Name = "Dhananjay Kumar",
                    Expertise =
                        "Node.js, WCF",
                    TalksDelivered = 54
                },
                new SpeakerVM
                {
                    Id = "S003",
                    Name = "Gaurav",
                    Expertise =
                        "Microsoft Azure",
                    TalksDelivered = 68
                }
            };
            return speakers;
        }
    }

    public class SpeakerVM
    {
        public string Id;
        public string Name { get; set; }
        public int TalksDelivered { get; set; }
        public string Expertise { get; set; }
    }

    public class TalkVm
    {
        public string duration { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string speaker { get; set; }
        public string venue { get; set; }
    }
}