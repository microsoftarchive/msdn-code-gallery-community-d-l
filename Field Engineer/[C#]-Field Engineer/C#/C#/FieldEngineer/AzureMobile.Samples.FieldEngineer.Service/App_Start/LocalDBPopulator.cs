// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Linq;
using AzureMobile.Samples.FieldEngineer.Service.Models;

namespace AzureMobile.Samples.FieldEngineer.Service
{
    public static class LocalDBPopulator
    {
        public static void PopulateForLocalUser(MobileServiceContext context)
        {
            PopulateCustomerTable(context);
            context.SaveChanges();

            PopulateEquipmentTable(context);
            context.SaveChanges();

            PopulateEquipmentSpecificationTable(context);
            context.SaveChanges();

            PopulateJobTable(context);
            context.SaveChanges();

            PopulateJobHistoryTable(context);
            context.SaveChanges();

            PopulateJobEquipmentMergeTable(context);
            context.SaveChanges();
        }

        private static void PopulateJobEquipmentMergeTable(MobileServiceContext context)
        {
            AddJobEquipmentMergeEntry(context, "1009786143", "5");
            AddJobEquipmentMergeEntry(context, "1025689089", "1");
            AddJobEquipmentMergeEntry(context, "1025689089", "3");
            AddJobEquipmentMergeEntry(context, "1025689089", "5");
            AddJobEquipmentMergeEntry(context, "1049586330", "2");
            AddJobEquipmentMergeEntry(context, "1049586330", "4");
            AddJobEquipmentMergeEntry(context, "1049586330", "5");
            AddJobEquipmentMergeEntry(context, "1102953551", "1");
            AddJobEquipmentMergeEntry(context, "1102953551", "3");
            AddJobEquipmentMergeEntry(context, "1102953551", "5");
            AddJobEquipmentMergeEntry(context, "1823218959", "2");
        }

        private static void AddJobEquipmentMergeEntry(MobileServiceContext context, string jobId, string equipmentId)
        {
            var job = context.Set<Job>().Single(j => j.Id == jobId);
            var equipment = context.Set<Equipment>().Single(e => e.Id == equipmentId);
            job.Equipments.Add(equipment);
        }

        private static void PopulateJobHistoryTable(MobileServiceContext context)
        {
            context.Set<JobHistory>().Add(new JobHistory { Id = "247", JobId = "1025689089", ActionBy = "Roland Earls", Comments = "Job postponed to 20/08/2013 09:07 AM", TimeStamp = new DateTimeOffset(2014, 3, 6, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "248", JobId = "1025689089", ActionBy = "Roland Earls", Comments = "Sent an ETA of around 08:55 AM", TimeStamp = new DateTimeOffset(2014, 3, 6, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "249", JobId = "1025689089", ActionBy = "Roland Earls", Comments = "Accepted job on 20/08/2013 08:15 AM", TimeStamp = new DateTimeOffset(2014, 3, 8, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "250", JobId = "1025689089", ActionBy = "Roger Timm", Comments = "Scheduled job to 20/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 8, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "251", JobId = "1025689089", ActionBy = "Cecelia Joseph", Comments = "Created new order to install and setup", TimeStamp = new DateTimeOffset(2014, 3, 4, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "252", JobId = "1025689089", ActionBy = "Roger Timm", Comments = "Job schedule updated to 26/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 4, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "259", JobId = "1102953551", ActionBy = "Al Pardo", Comments = "Updated job status to On Site", TimeStamp = new DateTimeOffset(2014, 3, 2, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "260", JobId = "1102953551", ActionBy = "Al Pardo", Comments = "Sent an ETA of around 08:58 AM", TimeStamp = new DateTimeOffset(2014, 3, 2, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "261", JobId = "1102953551", ActionBy = "Al Pardo", Comments = "Accepted job on 26/08/2013 08:21 AM", TimeStamp = new DateTimeOffset(2014, 3, 4, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "262", JobId = "1102953551", ActionBy = "Roger Timm", Comments = "Job schedule updated to 26/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 4, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "263", JobId = "1102953551", ActionBy = "Roland Earls", Comments = "Job postponed to 20/08/2013 09:07 AM", TimeStamp = new DateTimeOffset(2014, 3, 6, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "264", JobId = "1102953551", ActionBy = "Roland Earls", Comments = "Sent an ETA of around 08:55 AM", TimeStamp = new DateTimeOffset(2014, 3, 6, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "265", JobId = "1102953551", ActionBy = "Roland Earls", Comments = "Accepted job on 20/08/2013 08:15 AM", TimeStamp = new DateTimeOffset(2014, 3, 8, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "266", JobId = "1102953551", ActionBy = "Roger Timm", Comments = "Scheduled job to 20/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 8, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "267", JobId = "1102953551", ActionBy = "Cecelia Joseph", Comments = "Created new order to install and setup.", TimeStamp = new DateTimeOffset(2014, 3, 10, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "277", JobId = "1823218959", ActionBy = "Roger Timm", Comments = "Job schedule updated to 26/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 28, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "278", JobId = "1823218959", ActionBy = "Cecelia Joseph", Comments = "Created new order to install and setup.", TimeStamp = new DateTimeOffset(2014, 3, 28, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "73", JobId = "1009786143", ActionBy = "Roger Timm", Comments = "Job schedule updated to 26/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 30, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "74", JobId = "1009786143", ActionBy = "Cecelia Joseph", Comments = "Created new order to install and setup.", TimeStamp = new DateTimeOffset(2014, 3, 30, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "81", JobId = "1049586330", ActionBy = "Al Pardo", Comments = "Updated job status to On Site", TimeStamp = new DateTimeOffset(2014, 3, 10, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "82", JobId = "1049586330", ActionBy = "Al Pardo", Comments = "Sent an ETA of around 08:58 AM", TimeStamp = new DateTimeOffset(2014, 3, 12, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "83", JobId = "1049586330", ActionBy = "Al Pardo", Comments = "Accepted job on 26/08/2013 08:21 AM", TimeStamp = new DateTimeOffset(2014, 3, 12, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "84", JobId = "1049586330", ActionBy = "Roger Timm", Comments = "Job schedule updated to 26/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 14, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "85", JobId = "1049586330", ActionBy = "Roland Earls", Comments = "Job postponed to 20/08/2013 09:07 AM", TimeStamp = new DateTimeOffset(2014, 3, 14, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "86", JobId = "1049586330", ActionBy = "Roland Earls", Comments = "Sent an ETA of around 08:55 AM", TimeStamp = new DateTimeOffset(2014, 3, 16, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "87", JobId = "1049586330", ActionBy = "Roland Earls", Comments = "Accepted job on 20/08/2013 08:15 AM", TimeStamp = new DateTimeOffset(2014, 3, 16, 12, 0, 10, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "88", JobId = "1049586330", ActionBy = "Roger Timm", Comments = "Scheduled job to 20/08/2013 09:00 AM", TimeStamp = new DateTimeOffset(2014, 3, 18, 8, 7, 12, TimeSpan.Zero) });
            context.Set<JobHistory>().Add(new JobHistory { Id = "89", JobId = "1049586330", ActionBy = "Cecelia Joseph", Comments = "Created new order to install and setup.", TimeStamp = new DateTimeOffset(2014, 3, 18, 12, 0, 10, TimeSpan.Zero) });
        }

        private static void PopulateJobTable(MobileServiceContext context)
        {
            context.Set<Job>().Add(new Job { Id = "1009786143", JobNumber = "17", EtaTime = "08:30 AM - 09:30 AM", CustomerId = "6", Status = "On Site", Title = "New customer installation and setup", AgentId = "localUser", StartTime = new DateTimeOffset(2014, 3, 4, 10, 0, 0, TimeSpan.Zero), EndTime = null, CreatedAt = DateTimeOffset.UtcNow });
            context.Set<Job>().Add(new Job { Id = "1025689089", JobNumber = "59", EtaTime = "08:30 AM - 09:30 AM", CustomerId = "7", Status = "Not Started", Title = "Replacement of faulty TV receiver equipment", AgentId = "localUser", StartTime = new DateTimeOffset(2014, 3, 6, 8, 0, 0, TimeSpan.Zero), EndTime = null, CreatedAt = DateTimeOffset.UtcNow });
            context.Set<Job>().Add(new Job { Id = "1049586330", JobNumber = "19", EtaTime = "09:00 AM - 10:00 AM", CustomerId = "2", Status = "Completed", Title = "Replacement of faulty TV receiver equipment", AgentId = "localUser", StartTime = new DateTimeOffset(2014, 3, 4, 10, 0, 0, TimeSpan.Zero), EndTime = new DateTimeOffset(2014, 3, 8, 12, 0, 0, TimeSpan.Zero), CreatedAt = DateTimeOffset.UtcNow });
            context.Set<Job>().Add(new Job { Id = "1102953551", JobNumber = "61", EtaTime = "08:30 AM - 09:30 AM", CustomerId = "1", Status = "Completed", Title = "New customer installation and setup", AgentId = "localUser", StartTime = new DateTimeOffset(2014, 3, 2, 12, 0, 0, TimeSpan.Zero), EndTime = new DateTimeOffset(2014, 3, 4, 16, 0, 0, TimeSpan.Zero), CreatedAt = DateTimeOffset.UtcNow });
            context.Set<Job>().Add(new Job { Id = "1823218959", JobNumber = "63", EtaTime = "09:00 AM - 10:00 AM", CustomerId = "5", Status = "Not Started", Title = "New customer installation and setup", AgentId = "localUser", StartTime = new DateTimeOffset(2014, 3, 6, 8, 0, 0, TimeSpan.Zero), EndTime = null, CreatedAt = DateTimeOffset.UtcNow });
        }

        private static void PopulateEquipmentSpecificationTable(MobileServiceContext context)
        {
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "1", Name = "Cable Length", Value = "1.83 Meters", EquipmentId = "1", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "2", Name = "Cable Diameter", Value = "5.5mm", EquipmentId = "1", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "3", Name = "Transfer speed", Value = "10.2 Gigabits ", EquipmentId = "1", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "32", Name = "Certification", Value = "CE authentication by CCS.", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "4", Name = "Full HDCP", Value = "Yes", EquipmentId = "1", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "5", Name = "XBOX 360", Value = "Yes", EquipmentId = "1", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "6", Name = "Connector Type", Value = "HDMI male to HDMI male", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "7", Name = "Connector Finish", Value = "Gold", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "8", Name = "Length", Value = "6ft ", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "9", Name = "Conductor Plating", Value = "Tin", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "10", Name = "Shielding type", Value = "EMI", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "11", Name = "HDMI Certified", Value = "Yes", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "12", Name = "HDCP Compliant", Value = "Yes", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "13", Name = "CEC Compliant", Value = "Yes", EquipmentId = "2", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "14", Name = "Cable Length", Value = "H 30ft / 10m ", EquipmentId = "3", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "15", Name = "Type", Value = "RCA MALE ", EquipmentId = "3", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "16", Name = "Connector A ", Value = "RCA-Male ", EquipmentId = "3", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "17", Name = "Connector(s) B", Value = "RCA-Male", EquipmentId = "3", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "18", Name = "Offset Angle", Value = "24.62°", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "19", Name = "Aperture Diameter ", Value = "90cm/99cm", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "20", Name = "Ku-Band Gain @ 12.5GHz", Value = "40.32dB ", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "21", Name = "F/D Ratio", Value = "0.6", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "22", Name = "Focus Length", Value = "24 Inch", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "23", Name = "Material", Value = "Steel", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "24", Name = "Finish", Value = "Polyester Powder Coating", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "25", Name = "Mounting Type", Value = "Pole and Wall", EquipmentId = "4", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "26", Name = "Heatsinking ", Value = "Yes,Shell outside", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "27", Name = "Encrypt ", Value = "No", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "28", Name = "Video Modulator", Value = "No", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "29", Name = "Tuner Type", Value = "CAM Tuner Design", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "30", Name = "Demodulator Type", Value = "Embed to main chip set", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<EquipmentSpecification>().Add(new EquipmentSpecification { Id = "31", Name = "Power supply", Value = "DC 5V2A", EquipmentId = "5", CreatedAt = DateTimeOffset.UtcNow });
        }

        private static void PopulateEquipmentTable(MobileServiceContext context)
        {
            context.Set<Equipment>().Add(new Equipment { Id = "1", Name = "DUAL HDMI 1.4 CABLE", EquipmentNumber = "HDMI123456", Description = "3D Over HDMI defines input/output protocols for major 3D video formats, paving the way for true 3D gaming and 3D home theater applications", ThumbImage = "Data/EquipmentImages/HDMI_1_Thumb.jpg", FullImage = "Data/EquipmentImages/HDMI_1.jpg", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<Equipment>().Add(new Equipment { Id = "2", Name = "HDMI CABLE 6FT For BLURAY", EquipmentNumber = "HDMI123457", Description = "High Speed HDMI Cable, 1080p (Full HD) Supports 3D - Audio Return Channel - 4Kx2K - 1440p - 1080p - Blu-Ray - PS3.", ThumbImage = "Data/EquipmentImages/HDMI_2_Thumb.jpg", FullImage = "Data/EquipmentImages/HDMI_2.jpg", CreatedAt = DateTimeOffset.UtcNow });
            context.Set<Equipment>().Add(new Equipment
            {
                Id = "3",
                Name = "RCA Cable",
                EquipmentNumber = "RCA123456",
                Description = @"RCA Cable 30ft/10m Composite Video Audio Projector.
      
Single RCA M-M cable.
Length : 30ft/10m.
RCA M-M type video cable.",
                ThumbImage = "Data/EquipmentImages/RCA_1_Thumb.jpg",
                FullImage = "Data/EquipmentImages/RCA_1.jpg",
                CreatedAt = DateTimeOffset.UtcNow
            });
            context.Set<Equipment>().Add(new Equipment
            {
                Id = "4",
                Name = "Satellite Dish Antenna ",
                EquipmentNumber = "DISH123456",
                Description = @"90cm / 36"" Offset Satellite Dish Antenna

Offset Angle: 24.62°
Aperture Diameter: 90cm/99cm",
                ThumbImage = "Data/EquipmentImages/Dish_1_Thumb.jpg",
                FullImage = "Data/EquipmentImages/Dish_1.jpg",
                CreatedAt = DateTimeOffset.UtcNow
            });
            context.Set<Equipment>().Add(new Equipment { Id = "5", Name = "Set Top Box", EquipmentNumber = "STB123456", Description = "Digital Terrestrial Receiver-MPEG4,H.264, HDMI,USB,PVR,RCA.AV CONNECTOR.", ThumbImage = "Data/EquipmentImages/SetTop_1_Thumb.jpg", FullImage = "Data/EquipmentImages/SetTop_1.jpg", CreatedAt = DateTimeOffset.UtcNow });
        }

        private static void PopulateCustomerTable(MobileServiceContext context)
        {
            context.Set<Customer>().Add(new Customer { Id = "1", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mrs Erma Singleton", HouseNumberOrName = "2111", Latitude = 39.611719m, Longitude = -77.034073m, Postcode = "MD 33821", PrimaryContactNumber = "01234 123456", Street = "Mill Street", Town = "Arcadia" });
            context.Set<Customer>().Add(new Customer { Id = "2", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mr Christian Cowley", HouseNumberOrName = "2", Latitude = 39.548535m, Longitude = -76.837006m, Postcode = "MD 33822", PrimaryContactNumber = "01234 123456", Street = "Fabrikam Way", Town = "Bracknell" });
            context.Set<Customer>().Add(new Customer { Id = "3", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Ms Wendy Pyle", HouseNumberOrName = "49", Latitude = 39.582942m, Longitude = -76.795807m, Postcode = "MD 33823", PrimaryContactNumber = "01234 123456", Street = "Contoso Street", Town = "Bracknell" });
            context.Set<Customer>().Add(new Customer { Id = "4", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mrs Abby McNeil", HouseNumberOrName = "19", Latitude = 39.679717m, Longitude = -77.183762m, Postcode = "MD 33823", PrimaryContactNumber = "01234 123456", Street = "Works Drive", Town = "Bracknell" });
            context.Set<Customer>().Add(new Customer { Id = "5", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mr Matt Somerville", HouseNumberOrName = "6", Latitude = 39.600403m, Longitude = -77.156982m, Postcode = "MD 33825", PrimaryContactNumber = "01234 123456", Street = "Fabrikam Crescent", Town = "Bracknell" });
            context.Set<Customer>().Add(new Customer { Id = "6", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mr Romeo Cazares", HouseNumberOrName = "10", Latitude = 39.558065m, Longitude = -77.218781m, Postcode = "MD 33833", PrimaryContactNumber = "01234 123456", Street = "Contoso BLVD", Town = "Bracknell" });
            context.Set<Customer>().Add(new Customer { Id = "7", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mrs Hallie Mooney", HouseNumberOrName = "21", Latitude = 39.665976m, Longitude = -76.817093m, Postcode = "MD 33831", PrimaryContactNumber = "01234 123456", Street = "Adventure Place", Town = "Bracknell" });
            context.Set<Customer>().Add(new Customer { Id = "8", AdditionalContactNumber = "09876 987654", County = "Maryland", FullName = "Mrs Antoinette Santiago", HouseNumberOrName = "1", Latitude = 39.653289m, Longitude = -76.571960m, Postcode = "MD 33832", PrimaryContactNumber = "01234 123456", Street = "Fabrikam Common", Town = "Bracknell" });
        }
    }
}