﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.IIS.Administration.Logging
{
    using Extensions.Configuration;
    using Extensions.Logging;
    using System;

    class AuditingConfiguration
    {
        public bool Enabled { get; set; }
        public string AuditingRoot { get; set; }
        public LogLevel MinLevel { get; set; }
        public string FileName { get; set; }

        public AuditingConfiguration(IConfiguration configuration)
        {
            Enabled = configuration.GetValue("auditing:enabled", true);
            AuditingRoot = Environment.ExpandEnvironmentVariables(configuration.GetValue("auditing:path", string.Empty));
            MinLevel = LogLevel.Information;
            FileName = configuration.GetValue("auditing:file_name", "audit-{Date}.txt");
        }
    }
}