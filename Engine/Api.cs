﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Context;
using Engine.Fixed;
using Engine.Path;
using Engine.Rules;
using LanguageExt;

namespace Engine
{
    interface IEngine
    {
        Dictionary<ConfigurationPath, ConfigurationValue> Calculate(
            ConfigurationPath path,
            Set<Identity> identities);
    }

    class Engine : IEngine
    {
        private readonly ContextRetrieverByIdentity _contextRetriever;
        private readonly FixedConfigurationRetriever _fixedConfiguration;
        private readonly RulesRetriever _rules;
        private readonly PathTraversal _pathTraversal;

        public Engine(ContextRetrieverByIdentity contextRetriever,
            PathTraversal pathTraversal,
            FixedConfigurationRetriever fixedConfiguration,
            RulesRetriever rules)
        {
            _contextRetriever = contextRetriever;
            _fixedConfiguration = fixedConfiguration;
            _rules = rules;
            _pathTraversal = pathTraversal;
        }

        public Dictionary<ConfigurationPath, ConfigurationValue> Calculate(ConfigurationPath path, Set<Identity> identities)
        {
            return _.CalculateImpl(path, _pathTraversal, identities, _contextRetriever, _fixedConfiguration, _rules);
        }
    }
}