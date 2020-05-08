﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace NKnife.Sweetting
{

    public class GeneralNiceProfiles<T> : INiceProfiles<T> where T : class, new()
    {
        public T Value => Reader();

        protected virtual T Reader()
        {
            foreach (var profile in Sweet.Profiles)
            {
                using (StreamReader reader = File.OpenText(profile))
                {
                    Deserializer yaml = new Deserializer();
                    var setting = yaml.Deserialize<T>(reader);
                    if (null != setting)
                        return setting;
                }
            }
            return default(T);
        }
    }
}