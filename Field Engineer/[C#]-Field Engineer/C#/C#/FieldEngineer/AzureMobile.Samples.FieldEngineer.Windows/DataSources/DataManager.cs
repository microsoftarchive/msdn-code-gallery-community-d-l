// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using AzureMobile.Samples.FieldEngineer.DataModels;

namespace AzureMobile.Samples.FieldEngineer.DataSources
{
    public static class DataManager
    {
        private static bool isInitialized = false;
        private static string notInitializedExceptionMessage = "DataManager needs to initialized before accessing its members.";

        private static EquipmentDataSource equipmentDataSource;
        private static JobDataSource jobDataSource;
        private static EquipmentSpecificationDataSource equipmentSpecificationDataSource;

        public static EquipmentDataSource EquipmentDataSource
        {
            get
            {
                if (isInitialized)
                {
                    return equipmentDataSource;
                }
                else
                {
                    throw new InvalidOperationException(notInitializedExceptionMessage);
                }
            }
            set
            {
                equipmentDataSource = value;
            }
        }

        public static JobDataSource JobDataSource
        {
            get
            {
                if (isInitialized)
                {
                    return jobDataSource;
                }
                else
                {
                    throw new InvalidOperationException(notInitializedExceptionMessage);
                }
            }
            set
            {
                jobDataSource = value;
            }
        }

        public static EquipmentSpecificationDataSource EquipmentSpecificationDataSource
        {
            get
            {
                if (isInitialized)
                {
                    return equipmentSpecificationDataSource;
                }
                else
                {
                    throw new InvalidOperationException(notInitializedExceptionMessage);
                }
            }
            set
            {
                equipmentSpecificationDataSource = value;
            }
        }

        public static void Initialize(string urlPrefix)
        {
            //Initialize static members
            EquipmentDataSource = new EquipmentDataSource(urlPrefix);
            JobDataSource = new JobDataSource();
            EquipmentSpecificationDataSource = new EquipmentSpecificationDataSource();
            isInitialized = true;
        }
    }
}
