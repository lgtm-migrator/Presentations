﻿using AOPMethodsCommon;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AT_BL
{

    [AutoMethods(template = TemplateMethod.CustomTemplateFile, CustomTemplateFileName = "AutoMethods.txt", MethodPrefix = "auto")]

    public partial class PersonRepository
    {
        private readonly ActivitySource activitySource;

        public PersonRepository(ActivitySource activitySource)
        {
            this.activitySource = activitySource;
            
        }
        //TODO: put auto
        async Task<bool> autoLoadDetails(Person p)
        {
            //using var newAct = activitySource.StartActivity("loadDetails");
           
            var nr = new Random().Next(1, p.ID * 1000);
            await Task.Delay(nr);
            return true;
        }
        //todo: put auto
        async Task<Person[]> autoSearchFullName(string SearchName)
        {
            if (string.IsNullOrEmpty(SearchName))
                SearchName = "Ignat";
            var ret = new List<Person>();
            await Task.Delay(1000);
            for (int i = 0; i < SearchName.Length / 4+1; i++)
            {

                ret.Add( new Person()
                {
                    ID = i+1,
                    Name = $"Person with {SearchName}"
                });

            }
            return ret.ToArray();
        }

        public async Task<Person[]> SearchAndLoadData(string name)
        {
            var personsFound = await SearchFullName(name);
            foreach (var item in personsFound)
            {
                if (!await LoadDetails(item))
                    break;

            }

            return personsFound;
        }
    }

}

