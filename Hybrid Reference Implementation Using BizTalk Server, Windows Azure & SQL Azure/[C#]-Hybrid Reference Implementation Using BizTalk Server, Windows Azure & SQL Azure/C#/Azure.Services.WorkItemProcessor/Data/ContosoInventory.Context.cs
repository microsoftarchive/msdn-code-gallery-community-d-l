//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Data
{
    
    internal partial class ContosoInventoryContainer : ObjectContext
    {
        internal const string ConnectionString = "name=ContosoInventoryContainer";
        internal const string ContainerName = "ContosoInventoryContainer";
    
        #region Constructors
    
        public ContosoInventoryContainer()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public ContosoInventoryContainer(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public ContosoInventoryContainer(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        // public ObjectSet<InventoryData_DTO> InventoryData_DTO
    	internal ObjectSet<InventoryData_DTO> InventoryData_DTO
        {
            get { return _inventoryData_DTO  ?? (_inventoryData_DTO = CreateObjectSet<InventoryData_DTO>("InventoryData_DTO")); }
        }
        private ObjectSet<InventoryData_DTO> _inventoryData_DTO;
    
        // public ObjectSet<UOMTypesData_DTO> UOMTypesData_DTO
    	internal ObjectSet<UOMTypesData_DTO> UOMTypesData_DTO
        {
            get { return _uOMTypesData_DTO  ?? (_uOMTypesData_DTO = CreateObjectSet<UOMTypesData_DTO>("UOMTypesData_DTO")); }
        }
        private ObjectSet<UOMTypesData_DTO> _uOMTypesData_DTO;
    
        // public ObjectSet<ProductData_DTO> ProductData_DTO
    	internal ObjectSet<ProductData_DTO> ProductData_DTO
        {
            get { return _productData_DTO  ?? (_productData_DTO = CreateObjectSet<ProductData_DTO>("ProductData_DTO")); }
        }
        private ObjectSet<ProductData_DTO> _productData_DTO;

        #endregion
    }
}
