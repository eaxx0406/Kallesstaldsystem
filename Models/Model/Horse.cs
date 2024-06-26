﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CHRId { get; set; }
        public EquineType HorseType { get; set; }
        public Gender HorseGender { get; set; }

        public int PaddockId { get; set; }
        public int OwnerId { get; set; }
        public int BoxId { get; set; }
        public int FeedingScheduelId { get; set; }


        public Paddock Paddock { get; set; }
        public HorseOwner Owner { get; set; }
        public Box Box { get; set; }
        public FeedingScheduel FeedingScheduel { get; set; }

        public List<AddOn> AddOns { get; set; } = new List<AddOn>();
        public List<Deviation> DeviationList { get; set; } = new List<Deviation>();

        //basic constuktor
        public Horse(int id, string name, string cHRId,EquineType type,Gender gender) 
        { 
            Id = id;
            Name = name;
            CHRId = cHRId;
            HorseType = type;
            HorseGender = gender;
        }

        //Bigger constuktor
        public Horse(int id, string name, string cHRId, EquineType type, Gender gender,int paddockId,int ownerId,int boxId,int feedingScheduel)
        {
            Id = id;
            Name = name;
            CHRId = cHRId;
            HorseType = type;
            HorseGender = gender;
            PaddockId = paddockId;
            OwnerId = ownerId;
            BoxId = boxId;
            FeedingScheduelId = feedingScheduel;

        }

        public Horse (string name, string cHRId, EquineType type, Gender gender, int paddockId, int ownerId, int boxId, int feedingScheduel)
        {
        
            Name = name;
            CHRId = cHRId;
            HorseType = type;
            HorseGender = gender;
            PaddockId = paddockId;
            OwnerId = ownerId;
            BoxId = boxId;
            FeedingScheduelId = feedingScheduel;

        }

        //create contructors for the enums
        public Horse(string name, string cHRId, EquineType type, Gender gender)
        {
            Name = name;
            CHRId = cHRId;
            HorseType = type;
            HorseGender = gender;
        }

        public enum EquineType
        {
            Pony,
            Horse,
            Unknown
        }
        public enum Gender
        {
            Mare,
            Gelding,
            Stallion,
            Unknown
        }

        public override string ToString()
        {
            return "Hest: id: " + Id + ", Navn: " + Name + ", CHRid: " + CHRId + ", Type: " + HorseType + ", Køn: " + HorseGender ;
        }
    }
}
