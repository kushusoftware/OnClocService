
using OnClocService.Core.Entities.ProjectRegistry;

namespace OnClocService.Infrastructure.DataStorage.ProjectRegistry;

internal static class ProjectRegistryDataInitializer
{
    internal static async Task Initialize(OnClocDataStorageContext _StorageContext)
    {
        // Default Job Types
        var jobCardTypes = new JobCardType[]
        {
            new() { JobCardTypeID=1, Name="Internal", Description="Internal Works", ColourCode="#DDEBF7" },
            new() { JobCardTypeID=2, Name="External", Description="External Works", ColourCode="#CCFFCC" }
        };
        await _StorageContext.JobCardTypes.AddRangeAsync(jobCardTypes);
        _StorageContext.SaveChanges();
        // Default Job Categories
        var jobCardCategories = new JobCardCategory[]
        {
            new() { JobCardCategoryID=1, Name="Re-Works", Description="Work being redone" },
            new() { JobCardCategoryID=2, Name="Training & Installation", Description="Training & Installation" },
            new() { JobCardCategoryID=3, Name="AMC Services", Description="Services - AMCs" },
            new() { JobCardCategoryID=4, Name="Staff Trainings", Description="Staff Trainings" },
            new() { JobCardCategoryID=5, Name="Meetings", Description="Meetings" },
            new() { JobCardCategoryID=6, Name="ENGSOL Works", Description="ENGSOL Vehicles & Equipment Works" },
            new() { JobCardCategoryID=7, Name="Assembly Works", Description="Assembly Works" },
            new() { JobCardCategoryID=8, Name="Loading & Offloading", Description="Loading Offloading Works" },
            new() { JobCardCategoryID=9, Name="Pre-Delivery (PDI)", Description="Pre-Delivery Inspection (PDI)" },
            new() { JobCardCategoryID=10, Name="Service Camps", Description="Service Camps" },
            new() { JobCardCategoryID=11, Name="Documentation", Description="Documentation" },
            new() { JobCardCategoryID=12, Name="Cannibalisation", Description="Cannibalisation" },
            new() { JobCardCategoryID=13, Name="Housekeeping", Description="Cleaning, Yard re-arrangement, etc." },
            new() { JobCardCategoryID=14, Name="Warranty Works", Description="Warranty Works" },
            new() { JobCardCategoryID=15, Name="Non-AMC Service", Description="Service (Non-AMCs)" },
            new() { JobCardCategoryID=16, Name="Repairs & Maintenance", Description="Repairs & Maintenance" },
            new() { JobCardCategoryID=17, Name="Specialised Works", Description="Specialised Works" },
            new() { JobCardCategoryID=18, Name="Equipment Inspection", Description="Inspection of Equipment" },
            new() { JobCardCategoryID=19, Name="Contract Works", Description="Contract works" },
            new() { JobCardCategoryID=20, Name="Operators Training", Description="Training of Operators (Commercial)" },
        };
        await _StorageContext.JobCardCategories.AddRangeAsync(jobCardCategories);
        _StorageContext.SaveChanges();
        // Map Type to Category
        var jobCardTypeCategories = new JobCardTypeCategory[]
        {
            new() { JobCardTypeId=1, JobCardCategoryId=1 },
            new() { JobCardTypeId=1, JobCardCategoryId=2 },
            new() { JobCardTypeId=1, JobCardCategoryId=3 },
            new() { JobCardTypeId=1, JobCardCategoryId=4 },
            new() { JobCardTypeId=1, JobCardCategoryId=5 },
            new() { JobCardTypeId=1, JobCardCategoryId=6 },
            new() { JobCardTypeId=1, JobCardCategoryId=7 },
            new() { JobCardTypeId=1, JobCardCategoryId=8 },
            new() { JobCardTypeId=1, JobCardCategoryId=9 },
            new() { JobCardTypeId=1, JobCardCategoryId=10 },
            new() { JobCardTypeId=1, JobCardCategoryId=11 },
            new() { JobCardTypeId=1, JobCardCategoryId=12 },
            new() { JobCardTypeId=1, JobCardCategoryId=13 },
            new() { JobCardTypeId=2, JobCardCategoryId=14 },
            new() { JobCardTypeId=2, JobCardCategoryId=15 },
            new() { JobCardTypeId=2, JobCardCategoryId=16 },
            new() { JobCardTypeId=2, JobCardCategoryId=17 },
            new() { JobCardTypeId=2, JobCardCategoryId=18 },
            new() { JobCardTypeId=2, JobCardCategoryId=19 },
            new() { JobCardTypeId=2, JobCardCategoryId=20 },
        };
        await _StorageContext.JobCardTypeCategories.AddRangeAsync(jobCardTypeCategories);
        _StorageContext.SaveChanges();
        // Default Job Classes
        var jobCardClasses = new JobCardClass[]
        {
            new() { JobCardClassID=1, Name="Tractors", Description="Tractor Models" },
            new() { JobCardClassID=2, Name="Systems", Description="System Areas" },
            new() { JobCardClassID=3, Name="Major Service", Description="Major Service" },
            new() { JobCardClassID=4, Name="Minor Service", Description="Minor Service" },
            new() { JobCardClassID=5, Name="Implements", Description="Implements" },
            new() { JobCardClassID=6, Name="Specialised Equipment", Description="Specialised Equipment" },
            new() { JobCardClassID=7, Name="Repair", Description="Repair" },
            new() { JobCardClassID=8, Name="Inspection", Description="Inspection" },
            new() { JobCardClassID=9, Name="Maintenance", Description="Maintenance" },
            new() { JobCardClassID=10, Name="Internal Training", Description="Internal Training" },
            new() { JobCardClassID=11, Name="External Training ", Description="External Training " },
            new() { JobCardClassID=12, Name="Tool Box Talk", Description="Tool Box Talk" },
            new() { JobCardClassID=13, Name="General Meeting", Description="General Meeting" },
            new() { JobCardClassID=999, Name="Other", Description="Other Services" },
        };
        await _StorageContext.JobCardClasses.AddRangeAsync(jobCardClasses);
        _StorageContext.SaveChanges();
        // Map Category to Class
        var jobCardCategoryClasses = new JobCardCategoryClass[]
        {
            new() { JobCardCategoryId=1, JobCardClassId=1 },
            new() { JobCardCategoryId=1, JobCardClassId=5 },
            new() { JobCardCategoryId=1, JobCardClassId=6 },
            new() { JobCardCategoryId=3, JobCardClassId=3 },
            new() { JobCardCategoryId=3, JobCardClassId=4 },
            new() { JobCardCategoryId=4, JobCardClassId=10 },
            new() { JobCardCategoryId=4, JobCardClassId=11 },
            new() { JobCardCategoryId=5, JobCardClassId=12 },
            new() { JobCardCategoryId=5, JobCardClassId=13 },
            new() { JobCardCategoryId=6, JobCardClassId=7 },
            new() { JobCardCategoryId=6, JobCardClassId=8 },
            new() { JobCardCategoryId=6, JobCardClassId=9 },
            new() { JobCardCategoryId=14, JobCardClassId=1 },
            new() { JobCardCategoryId=14, JobCardClassId=2 },
            new() { JobCardCategoryId=15, JobCardClassId=2 },
            new() { JobCardCategoryId=15, JobCardClassId=3 },
            new() { JobCardCategoryId=15, JobCardClassId=4 },
            new() { JobCardCategoryId=16, JobCardClassId=1 },
            new() { JobCardCategoryId=16, JobCardClassId=5 },
            new() { JobCardCategoryId=16, JobCardClassId=999 },
            new() { JobCardCategoryId=17, JobCardClassId=6 },
            new() { JobCardCategoryId=18, JobCardClassId=1 },
            new() { JobCardCategoryId=18, JobCardClassId=5 },
        };
        await _StorageContext.JobCardCategoryClasses.AddRangeAsync(jobCardCategoryClasses);
        _StorageContext.SaveChanges();
        // Defult Job Groups
        var jobCardGroups = new JobCardGroup[]
        {
            new() { JobCardGroupID=1 , Name="Automobile", Description="Automobile" },
            new() { JobCardGroupID=2 , Name="Axle", Description="Axle" },
            new() { JobCardGroupID=3 , Name="Brakes", Description="Brakes" },
            new() { JobCardGroupID=4 , Name="CASE", Description="CASE" },
            new() { JobCardGroupID=5 , Name="Clutch", Description="Clutch" },
            new() { JobCardGroupID=6 , Name="Differential System ", Description="Differential System " },
            new() { JobCardGroupID=7 , Name="Engine", Description="Engine" },
            new() { JobCardGroupID=8 , Name="Harrow", Description="Harrow" },
            new() { JobCardGroupID=9 , Name="Hoist", Description="Hoist" },
            new() { JobCardGroupID=10 , Name="Hydraulic System", Description="Hydraulic System" },
            new() { JobCardGroupID=11 , Name="MF", Description="MF" },
            new() { JobCardGroupID=12 , Name="Milking Machines", Description="Milking Machines" },
            new() { JobCardGroupID=13 , Name="Motorcycle", Description="Motorcycle" },
            new() { JobCardGroupID=15 , Name="Planter", Description="Planter" },
            new() { JobCardGroupID=16 , Name="Plough", Description="Plough" },
            new() { JobCardGroupID=17 , Name="PTO Take-Off Drive", Description="PTO Take-Off Drive" },
            new() { JobCardGroupID=18 , Name="Ridger", Description="Ridger" },
            new() { JobCardGroupID=19 , Name="Slasher", Description="Slasher" },
            new() { JobCardGroupID=20 , Name="Spray Booths", Description="Spray Booths" },
            new() { JobCardGroupID=21 , Name="TAFE", Description="TAFE" },
            new() { JobCardGroupID=22 , Name="Time Cultivators", Description="Time Cultivators" },
            new() { JobCardGroupID=23 , Name="Tractor", Description="Tractor" },
            new() { JobCardGroupID=24 , Name="Transmission System ", Description="Transmission System " },
            new() { JobCardGroupID=25 , Name="Tyre Changers", Description="Tyre Changers" },
            new() { JobCardGroupID=26 , Name="Wheel Balancers", Description="Wheel Balancers" },
            new() { JobCardGroupID=999 , Name="Other", Description="Other" },
        };
        await _StorageContext.JobCardGroups.AddRangeAsync(jobCardGroups);
        _StorageContext.SaveChanges();
        // Map Class to Group
        var jobCardClassGroups = new JobCardClassGroup[]
        {
            new() { JobCardClassId=1, JobCardGroupId=21 },
            new() { JobCardClassId=1, JobCardGroupId=4 },
            new() { JobCardClassId=1, JobCardGroupId=11 },
            new() { JobCardClassId=1, JobCardGroupId=999 },
            new() { JobCardClassId=2, JobCardGroupId=24 },
            new() { JobCardClassId=2, JobCardGroupId=10 },
            new() { JobCardClassId=2, JobCardGroupId=5 },
            new() { JobCardClassId=2, JobCardGroupId=17 },
            new() { JobCardClassId=2, JobCardGroupId=6 },
            new() { JobCardClassId=2, JobCardGroupId=3 },
            new() { JobCardClassId=2, JobCardGroupId=2 },
            new() { JobCardClassId=2, JobCardGroupId=7 },
            new() { JobCardClassId=3, JobCardGroupId=21 },
            new() { JobCardClassId=3, JobCardGroupId=4 },
            new() { JobCardClassId=4, JobCardGroupId=21 },
            new() { JobCardClassId=4, JobCardGroupId=4 },
            new() { JobCardClassId=5, JobCardGroupId=16 },
            new() { JobCardClassId=5, JobCardGroupId=8 },
            new() { JobCardClassId=5, JobCardGroupId=19 },
            new() { JobCardClassId=5, JobCardGroupId=18 },
            new() { JobCardClassId=5, JobCardGroupId=22 },
            new() { JobCardClassId=6, JobCardGroupId=9 },
            new() { JobCardClassId=6, JobCardGroupId=25 },
            new() { JobCardClassId=6, JobCardGroupId=26 },
            new() { JobCardClassId=6, JobCardGroupId=20 },
            new() { JobCardClassId=6, JobCardGroupId=12 },
            new() { JobCardClassId=6, JobCardGroupId=999 },
            new() { JobCardClassId=7, JobCardGroupId=1 },
            new() { JobCardClassId=7, JobCardGroupId=13 },
            new() { JobCardClassId=7, JobCardGroupId=23 },
            new() { JobCardClassId=8, JobCardGroupId=1 },
            new() { JobCardClassId=8, JobCardGroupId=13 },
            new() { JobCardClassId=8, JobCardGroupId=23 },
            new() { JobCardClassId=9, JobCardGroupId=1 },
            new() { JobCardClassId=9, JobCardGroupId=13 },
            new() { JobCardClassId=9, JobCardGroupId=23 },
        };
        await _StorageContext.JobCardClassGroups.AddRangeAsync(jobCardClassGroups);
        _StorageContext.SaveChanges();
        // Default Job Genres
        var jobCardGenres = new JobCardGenre[]
        {
            new() { JobCardGenreID=1, Name="1002-4WD", Description="1002-4WD" },
            new() { JobCardGenreID=2, Name="240XTRA", Description="240XTRA" },
            new() { JobCardGenreID=3, Name="275XTRA", Description="275XTRA" },
            new() { JobCardGenreID=4, Name="290XTRA", Description="290XTRA" },
            new() { JobCardGenreID=5, Name="440XTRA", Description="440XTRA" },
            new() { JobCardGenreID=6, Name="445XTRA", Description="445XTRA" },
            new() { JobCardGenreID=7, Name="45 DI - 2WD", Description="45 DI - 2WD" },
            new() { JobCardGenreID=8, Name="470XTRA", Description="470XTRA" },
            new() { JobCardGenreID=9, Name="5900-4WD", Description="5900-4WD" },
            new() { JobCardGenreID=10, Name="7502-4WD", Description="7502-4WD" },
            new() { JobCardGenreID=11, Name="8502-4WD", Description="8502-4WD" },
            new() { JobCardGenreID=12, Name="8515-4WD", Description="8515-4WD" },
            new() { JobCardGenreID=13, Name="9502-4WD", Description="9502-4WD" },
            new() { JobCardGenreID=14, Name="Agromaster", Description="Agromaster" },
            new() { JobCardGenreID=15, Name="Baldan", Description="Baldan" },
            new() { JobCardGenreID=16, Name="Beroni", Description="Beroni" },
            new() { JobCardGenreID=17, Name="Falcon", Description="Falcon" },
            new() { JobCardGenreID=18, Name="FARMALL 110", Description="FARMALL 110" },
            new() { JobCardGenreID=19, Name="JX75T", Description="JX75T" },
            new() { JobCardGenreID=20, Name="PUMA 155", Description="PUMA 155" },
            new() { JobCardGenreID=21, Name="PUMA 185", Description="PUMA 185" },
            new() { JobCardGenreID=22, Name="TATU", Description="TATU" },
        };
        await _StorageContext.JobCardGenres.AddRangeAsync(jobCardGenres);
        _StorageContext.SaveChanges();
        // Map Group to Genre
        var jobCardGroupGenres = new JobCardGroupGenre[]
        {
            new() { JobCardGroupId=21, JobCardGenreId=7 },
            new() { JobCardGroupId=21, JobCardGenreId=9 },
            new() { JobCardGroupId=21, JobCardGenreId=10 },
            new() { JobCardGroupId=21, JobCardGenreId=12 },
            new() { JobCardGroupId=21, JobCardGenreId=11 },
            new() { JobCardGroupId=21, JobCardGenreId=13 },
            new() { JobCardGroupId=21, JobCardGenreId=1 },
            new() { JobCardGroupId=4, JobCardGenreId=19 },
            new() { JobCardGroupId=4, JobCardGenreId=18 },
            new() { JobCardGroupId=4, JobCardGenreId=21 },
            new() { JobCardGroupId=4, JobCardGenreId=20 },
            new() { JobCardGroupId=11, JobCardGenreId=2 },
            new() { JobCardGroupId=11, JobCardGenreId=3 },
            new() { JobCardGroupId=11, JobCardGenreId=4 },
            new() { JobCardGroupId=11, JobCardGenreId=5 },
            new() { JobCardGroupId=11, JobCardGenreId=6 },
            new() { JobCardGroupId=11, JobCardGenreId=8 },
            new() { JobCardGroupId=16, JobCardGenreId=14 },
            new() { JobCardGroupId=16, JobCardGenreId=16 },
            new() { JobCardGroupId=16, JobCardGenreId=22 },
            new() { JobCardGroupId=16, JobCardGenreId=15 },
            new() { JobCardGroupId=8, JobCardGenreId=14 },
            new() { JobCardGroupId=8, JobCardGenreId=16 },
            new() { JobCardGroupId=8, JobCardGenreId=22 },
            new() { JobCardGroupId=8, JobCardGenreId=15 },
            new() { JobCardGroupId=19, JobCardGenreId=17 },
            new() { JobCardGroupId=18, JobCardGenreId=15 },
            new() { JobCardGroupId=22, JobCardGenreId=14 },
        };
        await _StorageContext.JobCardGroupGenres.AddRangeAsync(jobCardGroupGenres);
        _StorageContext.SaveChanges();
    }
}
