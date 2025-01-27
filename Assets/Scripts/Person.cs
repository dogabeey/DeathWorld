﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.IO;
using Eppy;

public class Person
{
    public static List<Person> people = new List<Person>();

    static float MULTIPLIER_STR, MULTIPLIER_AGI, MULTIPLIER_INT, MULTIPLIER_CHA;

    public string firstName;
    public string lastName;
    public int age;
    public Personality personality;
    public Tile location;

    public int Strength = 3;
    public int Agility = 3;
    public int Intelligence = 3;
    public int Charisma = 3;

    public enum Stats
    {
        melee,
        shooting,
        foraging,
        construction,
        riding,
        driving,
        stamina,
        running,
        treatment,
        science,
        crafting,
        leadership,
        prisonManagement,
        lawmaking,
        persuasion,
        intimidation,
        facilityManagement,
        herding
}

    float melee = 0;
    float shooting = 0;
    float foraging = 0;
    float construction = 0;
    float riding = 0;
    float driving = 0;
    float stamina = 0;
    float running = 0;
    float treatment = 0;
    float science = 0;
    float crafting = 0;
    float leadership = 0;
    float prisonManagement = 0;
    float lawmaking = 0;
    float persuasion = 0;
    float intimidation = 0;
    float facilityManagement = 0;
    float herding = 0;

    public class Personality
    {
        public static List<Personality> personalities = new List<Personality>();

        public string name;
        public List<Tuple<Stats, float>> statWeights;

        public Personality(string name, List<Tuple<Stats, float>> statWeights)
        {
            this.name = name;
            this.statWeights = statWeights;
            personalities.Add(this);
        }

        public float GetWeight(Stats stat)
        {
            if (statWeights.Exists(sw => sw.Item1 == stat))
                return statWeights.Find(sw => sw.Item1 == stat).Item2;
            else return 1;
        }
        public void AddWeight(Stats stat, float value)
        {
            statWeights.Add(new Tuple<Stats, float>(stat, value));
        }
    }

    public Person(Personality personality)
    {
        firstName = RandomName("Assets\\Random Names\\names.txt");
        lastName = RandomName("Assets\\Random Names\\names.txt");
        age = Random.Range(18, 70);
        this.personality = personality;
        people.Add(this);
    }

    public Person(string firstName, string lastName, Personality personality, int age = 0, Tile location = null )
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.location = location;
        this.personality = personality;

        people.Add(this);
    }

    string RandomName(string filePath)
    {
        string[] nameList = File.ReadAllLines(filePath);
        string retVal = nameList[UnityEngine.Random.Range(0, nameList.Length)];
        return retVal;
    }

    public float Melee
    {
        get
        {
            return melee + Strength;
        }

        set
        {
            melee = value;
        }
    }

    public float Shooting
    {
        get
        {
            return shooting + (Strength + Agility) / 2;
        }

        set
        {
            shooting = value;
        }
    }

    public float Foraging
    {
        get
        {
            return foraging + (Intelligence + Agility) / 2;
        }

        set
        {
            foraging = value;
        }
    }

    public float Construction
    {
        get
        {
            return construction + (Strength + Intelligence) / 2;
        }

        set
        {
            construction = value;
        }
    }

    public float Riding
    {
        get
        {
            return riding + Agility;
        }

        set
        {
            riding = value;
        }
    }

    public float Driving
    {
        get
        {
            return driving + Agility;
        }

        set
        {
            driving = value;
        }
    }

    public float Stamina
    {
        get
        {
            return stamina + Strength;
        }

        set
        {
            stamina = value;
        }
    }

    public float Running
    {
        get
        {
            return running + Agility;
        }

        set
        {
            running = value;
        }
    }

    public float Treatment
    {
        get
        {
            return treatment + (Intelligence + Agility) / 2; ;
        }

        set
        {
            treatment = value;
        }
    }

    public float Science
    {
        get
        {
            return science + Intelligence;
        }

        set
        {
            science = value;
        }
    }

    public float Crafting
    {
        get
        {
            return crafting + (Strength + Intelligence) / 2;
        }

        set
        {
            crafting = value;
        }
    }

    public float Leadership
    {
        get
        {
            return leadership + Charisma;
        }

        set
        {
            leadership = value;
        }
    }

    public float PrisonManagement
    {
        get
        {
            return prisonManagement + (Strength + Charisma) / 2;
        }

        set
        {
            prisonManagement = value;
        }
    }

    public float Lawmaking
    {
        get
        {
            return lawmaking + (Intelligence + Charisma) / 2;
        }

        set
        {
            lawmaking = value;
        }
    }

    public float Persuasion
    {
        get
        {
            return persuasion + Charisma;
        }

        set
        {
            persuasion = value;
        }
    }

    public float Intimidation
    {
        get
        {
            return intimidation + (Strength + Charisma) / 2;
        }

        set
        {
            intimidation = value;
        }
    }

    public float FacilityManagement
    {
        get
        {
            return facilityManagement + (Intelligence + Charisma) / 2; ;
        }

        set
        {
            facilityManagement = value;
        }
    }

    public float Herding
    {
        get
        {
            return herding + (Charisma + Agility) / 2;
        }

        set
        {
            herding = value;
        }
    }

    float? GetAbility(string abilityName)
    {
        FieldInfo field = GetType().GetField(abilityName, BindingFlags.IgnoreCase);
        if (field != null) return (float)field.GetValue(this);
        else return null;
    }
}
